namespace homeworks
{
    abstract class Vehicle
    {
        public int Id;
        public string Brand;
        public int Year;

        public Vehicle(int id, string brand, int year)
        {
            Id = id;
            Brand = brand;
            Year = year;
        }

        public abstract void StartEngine();

        public virtual void DisplayInfo()
        {
            Console.WriteLine("ID: " + Id + ", Značka: " + Brand + ", Rok: " + Year);

        } 
        

    }
    
}
