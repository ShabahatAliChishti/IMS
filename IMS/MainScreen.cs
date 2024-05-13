using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
            MainScreenFormLoad();
        }

        public void MainScreenFormLoad()
        {
            Inventory.PopulateDummyLists();

            var bsPart = new BindingSource();
            bsPart.DataSource = Inventory.Parts;
            mainPartsGrid.DataSource = bsPart;
            var bsProd = new BindingSource();
            bsProd.DataSource = Inventory.Products;
            mainProductsGrid.DataSource = bsProd;
          
        }

        private void btnAddPart_Click(object sender, EventArgs e)
        {   
            new AddPartScreen().ShowDialog();
        }

        private void btnModifyPart_Click(object sender, EventArgs e)
        {
            if(mainPartsGrid.CurrentRow.DataBoundItem.GetType() == typeof(IMS.InHousePart))
            {
                InHousePart inPart = (InHousePart)mainPartsGrid.CurrentRow.DataBoundItem;
                new ModifyPartScreen(inPart).ShowDialog();
            }
            else
            {
                OutsourcedPart outPart = (OutsourcedPart)mainPartsGrid.CurrentRow.DataBoundItem;
                new ModifyPartScreen(outPart).ShowDialog();

            }


        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            Product selectedProduct = (Product)mainProductsGrid.CurrentRow.DataBoundItem;
            new AddProductScreen().ShowDialog();
        }

        private void btnModifyProduct_Click(object sender, EventArgs e)
        {
            Product selectedProduct = (Product)mainProductsGrid.CurrentRow.DataBoundItem;
            new ModifyProductScreen(selectedProduct).ShowDialog();
        }

        private void btnDeletePart_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in mainPartsGrid.SelectedRows)
            {
                mainPartsGrid.Rows.RemoveAt(row.Index);
            }
        }
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            Product prod = (Product)mainProductsGrid.CurrentRow.DataBoundItem;
            if (prod.AssociatedParts.Count > 0)
            {
                MessageBox.Show("Cannot delete a Product with a part assigned to it.\nPlease removed assigned parts.");
                return;
            }

            foreach (DataGridViewRow row in mainProductsGrid.SelectedRows)
            {
                mainProductsGrid.Rows.RemoveAt(row.Index);
            }
        }

        private void btnPartsSearch_Click(object sender, EventArgs e)
        {
            if (searchBoxPartsText < 1)
                return;

            Part match = Inventory.LookupPart(searchBoxPartsText);

            foreach(DataGridViewRow row in mainPartsGrid.Rows)
            {
                Part part = (Part)row.DataBoundItem;

                if(part.PartID == match.PartID)
                {
                    row.Selected = true;
                    break;
                }
                else
                {
                    row.Selected = false;
                }
            }
        }

        private void btnProductsSearch_Click(object sender, EventArgs e)
        {
            if (searchBoxProductsText < 1)
                return;

            Product match = Inventory.LookupProduct(searchBoxProductsText);

            foreach (DataGridViewRow row in mainProductsGrid.Rows)
            {
                Product prod = (Product)row.DataBoundItem;

                if (prod.ProductID == match.ProductID)
                {
                    row.Selected = true;
                    break;
                }
                else
                {
                    row.Selected = false;
                }
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
