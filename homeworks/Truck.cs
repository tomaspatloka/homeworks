
namespace homeworks
{
    class Truck : Vehicle, IDriveable
    {
        public int LoadCapacity;

        public Truck(int id, string brand, int year, int capacity) : base(id, brand, year)
        {
            LoadCapacity = capacity;
        }

        public override void StartEngine()
        {
            Console.WriteLine("Nákladní auto " + Id + " startuje motor");
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Nákladní auto - ID: " + Id + ", Značka: " + Brand + ", Kapacita: " + LoadCapacity + " tun");
        }

        public void Drive()
        {
            Console.WriteLine("Nákladní auto " + Id + " jede po silnici");
        }
    }
}
