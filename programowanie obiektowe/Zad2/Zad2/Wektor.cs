using System;

namespace ConsoleApp1
{
    public class Wektor
    {
        private readonly double[] współrzędne;

        public double Długość => Math.Sqrt(IloczynSkalarny(this, this));

        public byte Wymiar => (byte)współrzędne.Length;

        // Indeksator int - łatwiejszy do użycia w pętli niż byte, bo nie trzeba rzutować
        public double this[int i]
        {
            get => współrzędne[i];
            set => współrzędne[i] = value;
        }

        // Indeksator byte
        public double this[byte i]
        {
            get => współrzędne[i];
            set => współrzędne[i] = value;
        }

        // Konstruktor
        public Wektor(byte wymiar)
        {
            współrzędne = new double[wymiar];
        }

        public Wektor(params double[] wspolrzedne)
        {
            współrzędne = wspolrzedne;
        }

        // Iloczyn skalarny
        public static double IloczynSkalarny(Wektor V, Wektor W)
        {
            if (V.Wymiar != W.Wymiar)
                throw new ArgumentException("Wektory muszą mieć ten sam wymiar.");

            double suma = 0;
            for (int i = 0; i < V.Wymiar; i++)
            {
                suma += V[i] * W[i];
            }

            return suma;
        }

        // Suma wielu wektorów
        public static Wektor Suma(params Wektor[] wektory)
        {
            if (wektory.Length == 0)
                throw new ArgumentException("Podaj co najmniej jeden wektor.");

            int wymiar = wektory[0].Wymiar;

            foreach (var w in wektory)
            {
                if (w.Wymiar != wymiar)
                    throw new ArgumentException("Wszystkie wektory muszą mieć ten sam wymiar.");
            }

            double[] suma = new double[wymiar];

            foreach (var w in wektory)
            {
                for (int i = 0; i < wymiar; i++)
                {
                    suma[i] += w[i];
                }
            }

            return new Wektor(suma);
        }
        public static Wektor operator +(Wektor V, Wektor W) // Operator dodawania
        {
            if (V.Wymiar != W.Wymiar)
                throw new ArgumentException("Wektory muszą mieć ten sam wymiar.");

            double[] wynik = new double[V.Wymiar];
            for (int i = 0; i < V.Wymiar; i++)
            {
                wynik[i] = V[i] + W[i];
            }

            return new Wektor(wynik);
        }
        public static Wektor operator -(Wektor V, Wektor W) //Operator odejmowania
        {
            if (V.Wymiar != W.Wymiar)
                throw new ArgumentException("Wektory muszą mieć ten sam wymiar.");

            double[] wynik = new double[V.Wymiar];
            for (int i = 0; i < V.Wymiar; i++)
            {
                wynik[i] = V[i] - W[i];
            }

            return new Wektor(wynik);
        }

        //Mnożenie przez skalar
        public static Wektor operator *(Wektor V, double skalar)
        {
            double[] wynik = new double[V.Wymiar];
            for (int i = 0; i < V.Wymiar; i++)
            {
                wynik[i] = V[i] * skalar;
            }

            return new Wektor(wynik);
        }

        public static Wektor operator *(double skalar, Wektor V)
        {
            return V * skalar;
        }

        public static Wektor operator /(Wektor V, double skalar) //dzielenie przez skalar
        {
            if (skalar == 0)
                throw new DivideByZeroException("Nie można dzielić przez zero.");

            double[] wynik = new double[V.Wymiar];
            for (int i = 0; i < V.Wymiar; i++)
            {
                wynik[i] = V[i] / skalar;
            }

            return new Wektor(wynik);
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", współrzędne)}]";
        }
    }
}
