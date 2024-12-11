namespace Lekce7
{
          
    public class Car
    {
        public string Brand;
        public string Model;
        public int Year;
        public int Mileage;

        public Car(string brand, string model, int year, int mileage)
        {
            Brand = brand;
            Year = year;
            Mileage = mileage;
            Model = model;
        }

        public void Drive(int kilometers)
        {
            Mileage = Mileage  + kilometers;
        }

        public void DisplayCarInfo()
        {
            Console.WriteLine("Brand:" +Brand + ", Model: " + Model + ", Year: " + Year + ", Mileage: " + Mileage + ", km" );
        }
    }
}

