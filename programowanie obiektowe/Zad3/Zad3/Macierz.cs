using System;

public class Macierz<T> : IEquatable<Macierz<T>>
{
    private T[,] dane;

    public int Wiersze { get; }
    public int Kolumny { get; }

    public Macierz(int wiersze, int kolumny)
    {
        if (wiersze <= 0 || kolumny <= 0)
            throw new ArgumentException("Wymiary macierzy muszą być większe od zera.");

        if (!typeof(IEquatable<T>).IsAssignableFrom(typeof(T)) && typeof(T) != typeof(string)) 
            //sprawdzenie, czy T implementuje IEquatable<T> + dodany został wyjątek dla stringa, bo nie pasuje do Iequatable<T>
        {
            throw new ArgumentException($"Typ {typeof(T).Name} powinien implementować IEquatable<{typeof(T).Name}>");
        }

        Wiersze = wiersze;
        Kolumny = kolumny;
        dane = new T[wiersze, kolumny];
    }

    public T this[(int, int) indeks]
    {
        get
        {
            var (i, j) = indeks;
            SprawdzZakres(i, j);
            return dane[i, j];
        }
        set
        {
            var (i, j) = indeks;
            SprawdzZakres(i, j);
            dane[i, j] = value;
        }
    }

    private void SprawdzZakres(int i, int j)
    {
        if (i < 0 || i >= Wiersze || j < 0 || j >= Kolumny)
            throw new IndexOutOfRangeException("Indeks poza zakresem macierzy.");
    }

    public static bool operator ==(Macierz<T> a, Macierz<T> b) //przeciążęnie operatorów
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        if (a.Wiersze != b.Wiersze || a.Kolumny != b.Kolumny) return false;

        for (int i = 0; i < a.Wiersze; i++)
        {
            for (int j = 0; j < a.Kolumny; j++)
            {
                if (!Equals(a.dane[i, j], b.dane[i, j])) //porównanie za pomocą Equals
                    return false;
            }
        }

        return true;
    }

    public static bool operator !=(Macierz<T> a, Macierz<T> b)
    {
        return !(a == b);
    }

    public bool Equals(Macierz<T> other)
    {
        return this == other;
    }
}

