using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzayPlise
{
    public class Malzeme
    {
        public Malzeme() { }
        public Malzeme(int id , string product, string type , double price)
        {
            Id = id;
            Product = product;
            Type = type;
            Price = price;
        }

        public int Id { get; set; }
        public string Product { get; set; }

        public string Type { get; set; }
        public double Price { get; set; }

        public string PriceString { get; set; }
    }
}
