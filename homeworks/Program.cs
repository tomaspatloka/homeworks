namespace Lekce7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Vytvoření a testování objektů třídy Car
            Car car1 = new Car("Toyota", "Corolla", 2020, 15000);
            Car car2 = new Car("Škoda", "Octavia", 2022, 5000);

            car1.Drive(100);
            car2.Drive(250);

            car1.DisplayCarInfo();
            car2.DisplayCarInfo();

            Console.WriteLine();

            // Vytvoření a testování objektů třídy Book
            Book book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", 180);
            Book book2 = new Book("1984", "George Orwell", 328);

            book1.Read(50);
            book2.Read(100);

            book1.DisplayProgress();
            book2.DisplayProgress();

            // Zkouška přečtení více stránek než kniha obsahuje
            book1.Read(200);
            book1.DisplayProgress();
        }
    }
}
