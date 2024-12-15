namespace homeworks
{
    class Motorcycle : Vehicle, IDriveable
    {
       

        public Motorcycle(int id, string brand, int year, bool sidecar) : base (id, brand, year)
        { 
           // ?? 
        }

        public override void StartEngine()
        {
            Console.WriteLine("Motorka " + Id + "Startuse motor");
        }

        public void Drive()
        {
            Console.WriteLine("Motorka " + Id + " jede po silnici");
        }
    }

}

