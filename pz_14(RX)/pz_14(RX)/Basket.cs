using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_14_RX_
{
    class Basket
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public Basket()
        {

        }

        public Basket(string name, int price , int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}
