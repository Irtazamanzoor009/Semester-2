using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Product
    {
        public string Name;
        public string Category;
        public int Price;

        public Product(string name, string category, int price)
        {
            Name = name;
            Category = category;
            Price = price;
        }

        public Product()
        {

        }
        
        public float calculateTax()
        {
            float tax = Price * 0.1F;
            return tax;
        }
    }
}
