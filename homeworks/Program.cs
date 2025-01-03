namespace homeworks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Katalog produktů");
            Console.WriteLine("----------------");

            try
            {

                // instance katalogu
                var catalog = new Catalog();

                catalog.AddProduct(new Product("Notebook ", 25000, 5));
                catalog.AddProduct(new Product("Mobil ", 10000, 10));
                catalog.AddProduct(new Product("Tablet ", 8000, 15));
                
                Console.WriteLine();
                Console.WriteLine("Přidány produkty:");
                Console.WriteLine();
                catalog.PrintProducts();


                // serializace produktů do JSON
                var jsonProduct = catalog.SerializeProducts();
                Console.WriteLine("Serializace produktů:");
                foreach (var item in jsonProduct)
                {
                    Console.WriteLine(item);
                }


                
                // deserializace vlastního JSON
                Console.WriteLine("Přidávám vlastní JSON produktu:");
                var customJson = new List<string>
            {
                "{\"Name\":\"Televize \",\"Price\":50000,\"Quantity\":5}",

                // Neplatný JSON pro test ošetření chyb
                "{\"Name\":\"Vadný produkt\",\"Price\":-500,\"Quantity\":1}",

                "Tohle není JSON"
            };

                catalog.DeserializeProducts(customJson);
                Console.WriteLine();
                Console.WriteLine("Aktualizovaný katalog:");
                catalog.PrintProducts();
                Console.WriteLine();



            }
            catch (Exception ex)
            {
                Console.WriteLine($"Nastala neočekávaná chyba: {ex.Message}");
            }




        }
    }

        
}
