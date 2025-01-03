using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeworks
{
    internal class Product
    {
        private string Name { get; set; }
        private decimal Price { get; set; }
        private int Quantity { get; set; }



        public Product(string name, decimal price, int quantity)
        {
            if (price < 0)
            {
                throw new InvalidProductException($"Cena produktu '{name}' nemůže být záporná.");
            }

            Name = name;
            Price = price;
            Quantity = quantity;
        }


    }




}
