using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS
{
    public class InHousePart : Part
    {

        public int MachineID { get; set; }


        public InHousePart() { }
        public InHousePart(int partID, string name, int inStock, decimal price, int min, int max)
        {
            PartID = partID;
            Name = name;
            InStock = inStock;
            Price = price.ToString();
            Min = min;
            Max = max;

        }

        public InHousePart(int partID, string name, int inStock, decimal price, int min, int max, int machineID)
        {
            PartID = partID;
            Name = name;
            InStock = inStock;
            Price = Convert.ToString(price);
            Min = min;
            Max = max;
            MachineID = machineID;
        }
    }
}
