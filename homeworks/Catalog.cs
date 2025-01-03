using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeworks
{
    internal class Catalog
    {

        private List<Product> _products;

        public Catalog()
        {
            _products = new List<Product>();
        }

        // Metoda pro přidání produktu
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        // Metoda pro serializaci produktů do JSON



        // Metoda pro deserializaci produktů z JSON

        // Pomocná metoda pro výpis produktů





    }
}
