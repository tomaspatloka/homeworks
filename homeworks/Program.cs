namespace homeworks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDriveable[] vehicles1 = new IDriveable[150];

            //tady nejak... naplnit pole auty , moto a trucky asi ...
            for (int i = 0; i < 50; i++)
            {
                vehicles1[i] = new Car(i + 1, "Škoda", 2024, 5);
                vehicles1[i + 50] = new Motorcycle(i + 51, "Honda", 2021, false);
                vehicles1[i + 100] = new Truck(i + 101, "Volvo", 2019, 10);

            }
        }   

            /// co dál .??
    }
}
