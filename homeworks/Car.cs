namespace homeworks
{
    class Car : Vehicle, IDriveable
    {
        public int NumberOfDoors;

        public Car(int id, string brand, int year, int doors) : base(id, brand, year)
        {
            NumberOfDoors = doors;
        }

        public override void StartEngine()
        {
            Console.WriteLine("Auto " + Id + " startuje motor");
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("Počet dveří: " + NumberOfDoors);
        }

        public void Drive()
        {
            Console.WriteLine("Auto " + Id + " jede po silnici");
        }

    }
}
