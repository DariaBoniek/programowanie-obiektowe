using System;

class Program
{
    static void Main()
    {
        var A = StworzMacierzA();
        var B = StworzMacierzB();

        WyswietlMacierz("Macierz A", A);
        WyswietlMacierz("Macierz B", B);

        SprawdzRelacjeMacierzy(A, B);
    }

    static Macierz<int> StworzMacierzA()
    {
        var m = new Macierz<int>(2, 2);
        m[(0, 0)] = 1;
        m[(0, 1)] = 2;
        m[(1, 0)] = 0;
        m[(1, 1)] = 2;
        return m;
    }

    static Macierz<int> StworzMacierzB()
    {
        var m = new Macierz<int>(2, 2);
        m[(0, 0)] = 1;
        m[(0, 1)] = 2;
        m[(1, 0)] = 0;
        m[(1, 1)] = 0;
        return m;
    }

    static void WyswietlMacierz<T>(string nazwa, Macierz<T> macierz)
    {
        Console.WriteLine(nazwa + ":");
        for (int i = 0; i < macierz.Wiersze; i++)
        {
            for (int j = 0; j < macierz.Kolumny; j++)
            {
                Console.Write(macierz[(i, j)] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void SprawdzRelacjeMacierzy<T>(Macierz<T> a, Macierz<T> b)
    {
        if (a.Wiersze == b.Wiersze && a.Kolumny == b.Kolumny)
            Console.WriteLine("Macierze mają takie same wymiary");
        else
            Console.WriteLine("Macierze mają różne wymiary");

        if (a.Equals(b))
            Console.WriteLine("Macierze są równe");
        else
            Console.WriteLine("Macierze są różne");
    }
}

