namespace homeworks
{
    public class InvalidProductException : Exception
    {
        public InvalidProductException(string message) : base(message)
        {
            Console.WriteLine("chyba neplATNY PRODUKT");
        }
    }
}
