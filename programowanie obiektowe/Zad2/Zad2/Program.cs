using ConsoleApp1;
using System;
using System.Numerics;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Wektor w1 = new Wektor(6, 4);
            Wektor w2 = new Wektor(1, 0);

            Wektor suma = w1 + w2;
            Console.WriteLine($"Suma: {suma}");

            double iloczyn = Wektor.IloczynSkalarny(w1, w2);
            Console.WriteLine($"Iloczyn skalarny: {iloczyn}");

            Wektor w3 = w1 * 5;
            Console.WriteLine($"Mnożenie przez 5: {w3}");

            Wektor w4 = w1 / 2;
            Console.WriteLine($"Dzielenie przez 2: {w4}");

            Wektor w5 = Wektor.Suma(w1, w2, w3); //suma kilku wektorów
            Console.WriteLine($"Suma wielu: {w5}");

            Console.WriteLine($"w1[0] (int): {w1[0]}");
            Console.WriteLine($"w1[1] (byte): {w1[(byte)1]}");
        }
    }
}