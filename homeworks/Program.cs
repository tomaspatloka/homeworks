using System;
using System.Xml.Linq;


class Program
{
    static void Main(string[] args)
    {
        int[] array = new int[5];
        array[0] = 2;
        array[1] = 3;
        array[2] = 1;
        array[3] = 5;
        array[4] = 4;


        //  1.Seřazení čísel v poli
        Console.WriteLine("1.Seřazení čísel v poli:");
        Console.WriteLine("Původní pole: " + string.Join(", ", array));
        SortNumbers(array);
        Console.WriteLine("Seřazené pole: " + string.Join(", ", array));
        Console.WriteLine();  // radek navíc

        // 2.Obrácení  pořadí elementů v poli
        Console.WriteLine("2.Obrácení  pořadí elementů v poli :");
        Console.WriteLine("Původní pole: " + string.Join(", ", array));
        ReverseNumbers(array);
        Console.WriteLine("Obrácené pole: " + string.Join(", ", array));
        Console.WriteLine();

        // 3.Odebere první element v poli
        array = new int[] { 1, 2, 3, 4, 5 };
        Console.WriteLine("3.Odebere první element v poli:");
        Console.WriteLine("Původní pole: " + string.Join(", ", array));
        array = RemoveFirst(array);
        Console.WriteLine("Pole bez prvního prvku: " + string.Join(", ", array));
        Console.WriteLine();

        // 4.Odebere poslední elemennt v poli
        array = new int[] { 1, 2, 3, 4, 5 };
        Console.WriteLine("4.Odebere poslední elemennt v poli");
        Console.WriteLine("Původní pole: " + string.Join(", ", array));
        array = RemoveLast(array);
        Console.WriteLine("Pole bez posledního prvku: " + string.Join(", ", array));
        Console.WriteLine();

        //  5.Odebere element na indexu 2
        array = new int[] { 1, 2, 3, 4, 5 };
        Console.WriteLine("5.Odebere element na indexu v poli:");
        Console.WriteLine("Původní pole: " + string.Join(", ", array));
        array = RemoveAtIndex(array, 2);
        Console.WriteLine("Pole s odstraněným prvkem na indexu 2: " + string.Join(", ", array));
        Console.WriteLine();


        //6.Vloží element na začátek pole
        array = new int[] { 1, 2, 3, 4, 5 };
        Console.WriteLine("6.Vloží element na začátek pole:");
        Console.WriteLine("Původní pole: " + string.Join(", ", array));
        array = InsertAtBeginning(array, 0);
        Console.WriteLine("Pole s vloženým prvkem na začátek: " + string.Join(", ", array));
        Console.WriteLine();


        // 7.Vloží element na konec pole
        array = new int[] { 1, 2, 3, 4, 5 };
        Console.WriteLine("7.Vloží element na konec pole");
        Console.WriteLine("Původní pole: " + string.Join(", ", array));
        array = InsertAtEnd(array, 0);
        Console.WriteLine("Pole s vloženým prvkem na konec: " + string.Join(", ", array));
        Console.WriteLine();


        // 8.Přidá na index 2 prvek
        array = new int[] { 1, 2, 3, 4, 5 };
        Console.WriteLine("8.Přidá element na daný index v poli:");
        Console.WriteLine("Původní pole: " + string.Join(", ", array));
        array = InsertAtIndex(array, 2, 0);
        Console.WriteLine("Pole s vloženým prvkem na index 2: " + string.Join(", ", array));
        Console.WriteLine();
    }


    // 1.
    static void SortNumbers(int[] array)
    {
        Array.Sort(array);
    }

    // 2.
    static void ReverseNumbers(int[] array)
    {
        Array.Reverse(array);
    }

    // 3.funkce na  odebrání prvního elementu v poli
    static int[] RemoveFirst(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            return array;
        }
        // Nové pole o jedno menší než původní
        int[] newArray = new int[array.Length - 1];

        // Nakopíruje prvky kromě prvního
        for (int i = 0; i < newArray.Length; i++)
        {
            newArray[i] = array[i + 1];
        }
        return newArray;

    }
    // 4.funkce na  odebrání posledního elementu v poli
    static int[] RemoveLast(int[] array)
    {
        // Kontrola null a prázdného pole
        if (array == null || array.Length == 0)
        {
            return array;
        }
        // Nové pole o jedno menší než původní
        int[] newArray = new int[array.Length - 1];

        // Nakopíruje všechny prvky kromě posledního
        for (int i = 0; i < newArray.Length; i++)
        {
            newArray[i] = array[i];
        }
        return newArray;
    }
    // 5. Odebere element na indexu = 2
    static int[] RemoveAtIndex(int[] array, int index)
    {
        if (array == null || array.Length == 0 || index < 0 || index >= array.Length)
        {
            return array;
        }

        int[] newArray = new int[array.Length - 1];

        // kopíruje prvky před indexem
        for (int i = 0; i < index; i++)
        {
            newArray[i] = array[i];
        }

        // kopírujeme prvky za indexem
        for (int i = index; i < newArray.Length; i++)
        {
            newArray[i] = array[i + 1];
        }
        return newArray;
    }

    // 6. vloží element na začátek pole
    static int[] InsertAtBeginning(int[] array, int value)
    {
        int[] newArray = new int[array.Length + 1];

        // nova hodnota na začátek
        newArray[0] = value;

        for (int i = 0; i < array.Length; i++)
        {
            newArray[i + 1] = array[i];
        }

        return newArray;
    }

    // 7. vlozi element na konec pole
    static int[] InsertAtEnd(int[] array, int value)
    {

        int[] newArray = new int[array.Length + 1];

        for (int i = 0; i < array.Length; i++)
        {
            newArray[i] = array[i];
        }
        newArray[array.Length] = value;

        return newArray;

    }

    // 8. prida element na  index = 2  pole
    static int[] InsertAtIndex(int[] array, int index, int value)
    {
        if (array == null || index < 0 || index > array.Length)
        {
            return array;
        }

        // Vytvoříme nové pole o jedna větší
        int[] newArray = new int[array.Length + 1];

        // Zkopírujeme prvky před indexem
        for (int i = 0; i < index; i++)
        {
            newArray[i] = array[i];
        }

        // Vložíme novou hodnotu
        newArray[index] = value;

        // Zkopírujeme zbývající prvky
        for (int i = index; i < array.Length; i++)
        {
            newArray[i + 1] = array[i];
        }

        return newArray;




    }
}