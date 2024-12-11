namespace Lekce7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Vytvoření objektů třídy Car
            Car car1 = new Car("Toyota", "Corolla", 2020, 15000);
            Car car2 = new Car("Škoda", "Octavia", 2022, 5000);
            Car car3 = new Car("Tesla", "S3", 2024, 1000);

            car1.Drive(100);
            car2.Drive(250);
            car3.Drive(500);

            car1.DisplayCarInfo();
            car2.DisplayCarInfo();
            car3.DisplayCarInfo();

            Console.WriteLine();

            // Vytvoření a objektů třídy Book
            Book book1 = new Book("The Great Gatsby", "F. Scott Fizgerald", 180);
            Book book2 = new Book("1984", "George Orwell", 328);
            Book book3 = new Book("To", "Stephen King", 1000);
            book1.Read(50);
            book2.Read(100);
           // book3.Read(350);

            book1.DisplayProgress();
            book2.DisplayProgress();
           // book3.DisplayProgress();

            // Přečtení více stránek než ná kniha
            book1.Read(200);
            book1.DisplayProgress();
            // book3.Read(1200);
        }
    }
}
