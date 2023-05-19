using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Customer
    {
        public string CustomerName;
        public string CustomerAddress;
        public string CustomerContact;
        public List<Product> products = new List<Product>();
        
        public Customer(string name, string address, string contact)
        {
            CustomerName = name;
            CustomerAddress = address;
            CustomerContact = contact;
        }
        public Customer()
        {
            
        }
        public List<Product> Getallproducts()
        {
            return products;
        }
        public void addproduct(Product p)
        {
            products.Add(p);
        }
    }
}
