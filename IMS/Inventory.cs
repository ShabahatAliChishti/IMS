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
    class Inventory
    {
        public static BindingList<Product> Products = new BindingList<Product>();
        public static BindingList<Part> Parts = new BindingList<Part>();

        public static void PopulateDummyLists()
        {
            Product dummyProd1 = new Product(1, "Red Bicycle", 15, 11.44m, 1, 25);
            Product dummyProd2 = new Product(2, "Yellow Bicycle", 19, 9.86m, 1, 20);
            Product dummyProd3 = new Product(3, "Blue Bicycle", 5, 12.77m, 1, 25);

            Products.Add(dummyProd1);
            Products.Add(dummyProd2);
            Products.Add(dummyProd3);

            Part dummyPart1A = new InHousePart(1, "Wheel", 15, 12.11m, 5, 25, 9001);
            Part dummyPart1B = new InHousePart(2, "Pedal", 11, 8.22m, 5, 25, 9001);
            Part dummyPart3A = new OutsourcedPart(3, "Chain", 12, 8.33m,5 , 25, "AbcCorp");
            Part dummyPart3B = new OutsourcedPart(4, "Seat", 8, 4.55m, 2, 15, "DCorp");
            Parts.Add(dummyPart1A);
            Parts.Add(dummyPart1B);
            Parts.Add(dummyPart3A);
            Parts.Add(dummyPart3B);
            

            dummyProd1.AssociatedParts.Add(dummyPart1A);
            dummyProd1.AssociatedParts.Add(dummyPart1B);
            dummyProd3.AssociatedParts.Add(dummyPart3A);
            dummyProd3.AssociatedParts.Add(dummyPart3B);

        }

        public static void AddProduct(Product prod)
        {
            Products.Add(prod);
        }

        public bool RemoveProduct(int productID)
        {
            bool success = false;
            foreach (Product prod in Products)
            {
                if (productID == prod.ProductID)
                {
                    Products.Remove(prod);
                    return success = true;
                }
                else
                {
                    MessageBox.Show("Removal failed.");
                    return false;
                }
            }
            return success;
        }

        public static Product LookupProduct(int productID)
        {
            foreach (Product prod in Products)
            {
                if (prod.ProductID == productID)
                {
                    return prod;
                }
            }
            Product emptyProd = new IMS.Product();
            return emptyProd;
        }

        public static void UpdateProduct(int productID, Product updatedProd)
        {
            foreach (Product currentProd in Products)
            {
                if (currentProd.ProductID == productID)
                {
                    currentProd.Name = updatedProd.Name;
                    currentProd.InStock = updatedProd.InStock;
                    currentProd.Price = updatedProd.Price;
                    currentProd.Max = updatedProd.Min;
                    currentProd.Min = updatedProd.Max;
                    currentProd.AssociatedParts = updatedProd.AssociatedParts;
                    return;
                }
            }

        }

        public static void AddPart(Part part)
        {
            Parts.Add(part);   
        }

        public bool DeletePart(Part part)
        {
            try
            {
                Parts.Remove(part);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Part LookupPart(int partID)
        {
            foreach (Part part in Parts)
            {
                if (part.PartID == partID)
                {
                    return part;
                }
            }
            Part emptyPart = null;
            return emptyPart;
        }

        public static void UpdateInHousePart(int partID, InHousePart inPart)
        {
            for(int i = 0; i < Parts.Count; i++)
            {
                if(Parts[i].GetType() == typeof(IMS.InHousePart))
                {
                    InHousePart newPart = (InHousePart)Parts[i];

                    if(newPart.PartID == partID)
                    {
                        newPart.Name = inPart.Name;
                        newPart.InStock = inPart.InStock;
                        newPart.Price = inPart.Price;
                        newPart.Min = inPart.Max;
                        newPart.Max = inPart.Min;
                        newPart.MachineID = inPart.MachineID;
                    }
                }
            }
        }
        public static void UpdateOutsourcedPart(int partID, OutsourcedPart outPart)
        {
            for (int i = 0; i < Parts.Count; i++)
            {
                if (Parts[i].GetType() == typeof(IMS.OutsourcedPart))
                {
                    OutsourcedPart newPart = (OutsourcedPart)Parts[i];

                    if (newPart.PartID == partID)
                    {
                        newPart.Name = outPart.Name;
                        newPart.InStock = outPart.InStock;
                        newPart.Price = outPart.Price;
                        newPart.Max = outPart.Min;
                        newPart.Min = outPart.Max;
                        newPart.CompanyName = outPart.CompanyName;
                    }
                }
            
            }
        }
    }
}
