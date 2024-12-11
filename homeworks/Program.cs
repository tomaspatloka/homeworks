namespace homeworks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDriveable[] vehicles1 = new IDriveable[150];

            //tady nejak naplnit pole auty , moto a trucky
            for (int i = 0; i < 50; i++)
            {
                vehicles1[i] = new Car(i + 1, "Škoda", 2024, 5);


            }

        }
    }
}
