using System;

namespace Zad1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Osoba osoba = new Osoba("Anna Maria Kowalska"); //Specjalnie wybrana osoba z podwójnym imieniem
            //program wybierze tylko ostatni wyraz jako nazwisko
            Console.WriteLine("Imię: {0}", osoba.Imię);
            Console.WriteLine("Nazwisko: {0}", osoba.Nazwisko);
            Console.WriteLine("Imię i nazwisko: {0}", osoba.ImięNazwisko);

            osoba.DataUrodzenia = new DateTime(1968, 2, 25);
            osoba.DataŚmierci = new DateTime(2004, 11, 8);

            // obliczenie wieku, jeżeli jest to osoba zmarła
            Console.WriteLine("Wiek (osoby zmarłej) w dniach: {0}", osoba.Wiek?.Days);

            // sprawdzenie dla osoby, która jeszcze żyje
            Osoba osoba2 = new Osoba("Maria Nowak");
            osoba2.DataUrodzenia = new DateTime(1985, 5, 12);
            Console.WriteLine("\nOsoba 2: {0}", osoba2.ImięNazwisko);
            Console.WriteLine("Wiek w dniach: {0}", osoba2.Wiek?.Days);
        }
    }
}

