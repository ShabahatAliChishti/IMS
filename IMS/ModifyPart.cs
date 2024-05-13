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
    public partial class ModifyPartScreen : Form
    {
        MainScreen MainForm = (MainScreen)Application.OpenForms["MainScreen"];

        public ModifyPartScreen(InHousePart inPart)
        {
            InitializeComponent();

            ModPartIDBoxText = inPart.PartID;
            ModPartNameBoxText = inPart.Name;
            ModPartInvBoxText = inPart.InStock;
            ModPartPriceBoxText = decimal.Parse(inPart.Price);
            ModPartMaxBoxText = inPart.Max;
            ModPartMinBoxText = inPart.Min;
            ModPartMachComBoxText = inPart.MachineID.ToString();
        }
        public ModifyPartScreen(OutsourcedPart outPart)
        {
            InitializeComponent();

            ModPartIDBoxText = outPart.PartID;
            ModPartNameBoxText = outPart.Name;
            ModPartInvBoxText = outPart.InStock;
            ModPartPriceBoxText = decimal.Parse(outPart.Price);
            ModPartMaxBoxText = outPart.Max;
            ModPartMinBoxText = outPart.Min;
            ModPartMachComBoxText = outPart.CompanyName;

            radioModOutsourced.Checked = true;
        }

        private void btnModPartSave_Click(object sender, EventArgs e)
        {

        
            if (ModPartMaxBoxText < ModPartMinBoxText)
            {
                MessageBox.Show("Minimum cannot be greateR than the Maximum.");
                return;
            }

            if (radioModInhouse.Checked)
            {
                InHousePart inHouse = new InHousePart(ModPartIDBoxText, ModPartNameBoxText, ModPartInvBoxText, ModPartPriceBoxText, ModPartMaxBoxText, ModPartMinBoxText, int.Parse(ModPartMachComBoxText));
                Inventory.UpdateInHousePart(ModPartIDBoxText, inHouse);
                radioModInhouse.Checked = true;
            }
            else
            {
              
                OutsourcedPart outSourced = new OutsourcedPart(ModPartIDBoxText, ModPartNameBoxText, ModPartInvBoxText, ModPartPriceBoxText, ModPartMaxBoxText, ModPartMinBoxText, ModPartMachComBoxText);
                Inventory.UpdateOutsourcedPart(ModPartIDBoxText, outSourced);
                radioModOutsourced.Checked = true;
            }

            this.Close();

            MainForm.mainPartsGrid.Update();
            MainForm.mainPartsGrid.Refresh();
        }

        private void radioModOutsourced_CheckedChanged(object sender, EventArgs e)
        {
            label7.Text = "Company Name";
        }
        private void radioModInhouse_CheckedChanged(object sender, EventArgs e)
        {
            label7.Text = "Machine ID";
        }

        private void btnModPartCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
