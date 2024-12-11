namespace Homework
{
    public class Lesson5
    {

        public static void Demo()
        {
            for (int i = 0; i < 2; i++)
            {
                // Získání jména.
                string firstName = GetInputAsString("Zadej své jméno: ");

                // Získání příjmení.
                string lastName = GetInputAsString("Zadej své přijmení ");

                // Získání věku jako čísla (int).
                int age = GetInputAsInt("Zadej svůj věk ");

                // Získání výšky v centimetrech jako čísla (int).
                int heightInCm = GetInputAsInt("Zadejte svou výšku (v cm): ");

                // Získání váhy v kilogramech jako desetinného čísla (float).
                float weightInKg = GetInputAsFloat("Zadejte svou váhu (v kg): ");

                // Převod výšky z centimetrů na metry (dělení hodnotou 100).
                float heightInMeters = heightInCm / 100.0f;

                // Výpočet BMI pomocí funkce `CalculateBMI`, která bere váhu a výšku jako vstup.
                float bmi = CalculateBMI(weightInKg, heightInMeters);

                Console.WriteLine($"{firstName} {lastName} je starý/á {age} let. Váží {weightInKg:F1} kg a měří {heightInCm} cm.");
                Console.WriteLine($"Vaše BMI je: {bmi:F1}");
                Console.WriteLine($"Spadáte do kategorie: {BmiCategorize(bmi)}");
            }
        }

        // Funkce pro výpočet BMI.
        private static float CalculateBMI(float weight, float height)
        {
            return weight / (height * height);
        }

        // Funkce pro získání vstupu jako textový řetězec (string).
        private static string GetInputAsString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        // Získání vstupu jako celé číslo (int).
        private static int GetInputAsInt(string message)
        {
            Console.WriteLine(message);
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    return result;
                }
                Console.WriteLine("Neplatný vstup. Zadejte prosím celé číslo.");
            }
        }

        // Získání vstupu jako desetinné číslo (float).
        private static float GetInputAsFloat(string message)
        {
            Console.WriteLine(message);
            while (true)
            {
                if (float.TryParse(Console.ReadLine(), out float result))
                {
                    return result;
                }
                Console.WriteLine("Neplatný vstup. Zadejte prosím číslo.");
            }
        }

        // Určení kategorie BMI
        private static string BmiCategorize(float bmi)
        {

            if (bmi < 18.5)
            {
                return "Podváha";
            }
            else if (bmi >= 18.5 && bmi < 24.9)
            {
                return "Normální hmotnost";
            }
            else if (bmi >= 25 && bmi < 29.9)
            {
                return "Nadváha";
            }
            else
            {
                return "Obezita";
            }
        }
    }
}
