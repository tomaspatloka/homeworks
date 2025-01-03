using System.Text.Json;

namespace homeworks
{
    internal class Catalog
    {

        private List<Product> Products;

        public Catalog()
        {
            Products = new List<Product>();
        }

        // přidání nového produktu
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        // serializace produktů 
        public List<string> SerializeProducts()
        {
            var jsonProducts = new List<string>();
            foreach (var product in Products)
            {
                var jsonString = JsonSerializer.Serialize(product);
                jsonProducts.Add(jsonString);
            }
            return jsonProducts;
        }



        // deserializace produktu
        public void DeserializeProducts(List<string> jsonProducts)
        {
            foreach (var jsonProduct in jsonProducts)
            {
                try
                {
                    var product = JsonSerializer.Deserialize<Product>(jsonProduct);
                    if (product != null)
                    {
                        
                        if (product.Price < 0)
                        {
                            throw new InvalidProductException("Produkt "+ product.Name + "má neplatnou cenu.");
                        }
                        Products.Add(product);
                    }
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Chyba při deserializaci produktu: {ex.Message}");
                }
                catch (InvalidProductException ex)
                {
                    Console.WriteLine($"Neplatný produkt: {ex.Message}");
                }
            }
        }


        
        public void PrintProducts()
        {
            foreach (var product in Products)
            {
                Console.WriteLine("Product: " + product.Name + "Cena: " + product.Price + "Kč", "Množství" + product.Quantity + "ks");
               
            }
        }




    }
}
