using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS
{
    public class Product
    {
        public BindingList<Part> AssociatedParts = new BindingList<Part>();
 
        private decimal price;
       
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int InStock { get; set; }
        public string Price
        {
            get { return price.ToString(); }
            set
            {
                    price = decimal.Parse(value);
                
            }
        }
        public int Max { get; set; }
        public int Min { get; set; }

        public Product() { }
        public Product(int prodID, string name, int inStock, decimal price, int min, int max)
        {
            ProductID = prodID;
            Name = name;
            InStock = inStock;
            Price = price.ToString();
            Max = max;
            Min = min;
        }

     
        public void AddAssociatedPart(Part part)
        {
            AssociatedParts.Add(part);   
        }

     
        public bool RemoveAssociatedPart(int partID)
        {
            bool success = false;
            foreach (Part part in AssociatedParts)
            {
                if (part.PartID == partID)
                {
                    AssociatedParts.Remove(part);
                    return success = true;
                }
                else
                {
                    success = false;
                }
            }
            return success;
        }

        public Part LookupAssociatedPart(int partID)
        {
            foreach (Part part in AssociatedParts)
            {
                if (part.PartID == partID)
                {
                    return part;
                }
            }
            InHousePart emptyInPart = new InHousePart();
            return emptyInPart;
        }
    }
}
