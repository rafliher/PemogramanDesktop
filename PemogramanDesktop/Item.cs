using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PemogramanDesktop
{
    public class Item
    {
        public string Name { get; set; } = "";
        public int Price { get; set; }

        public Item(string itemName, int itemPrice)
        {
            Name = itemName;
            Price = itemPrice;
        }
    }

}
