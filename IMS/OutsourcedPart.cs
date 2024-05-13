using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS
{
    public class OutsourcedPart : Part
    {

        public string CompanyName { get; set; }

        public OutsourcedPart() { }
        public OutsourcedPart(int partID, string name, int inStock, decimal price, int min, int max)
        {
            PartID = partID;
            Name = name;
            InStock = inStock;
            Price = price.ToString();
            Min = min;
            Max = max;
        }

        public OutsourcedPart(int partID, string name, int inStock, decimal price, int min, int max, string compName)
        {
            PartID = partID;
            Name = name;
            InStock = inStock;
            Price = price.ToString();
            Min = min;
            Max = max;
            CompanyName = compName;
        }
    }
}
