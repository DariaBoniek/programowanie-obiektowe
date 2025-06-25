using System;

namespace Zad1
{
    public class Osoba
    {
        private string imię;
        private string nazwisko;

        // Konstruktor 
        public Osoba(string imięNazwisko)
        {
            ImięNazwisko = imięNazwisko;
        }

        public string Imię
        {
            get => imię;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("pole imię nie może być puste");
                imię = value;
            }
        }

        public string ImięNazwisko
        {
            get => $"{imię} {nazwisko}".Trim();
            set
            {
                var parts = value.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 0)
                {
                    throw new ArgumentException("Nie podano imienia ani nazwiska");
                }
                else if (parts.Length == 1)
                {
                    Imię = parts[0];
                    nazwisko = string.Empty;
                }
                else
                {
                    Imię = string.Join(" ", parts[..^1]);  // Wszystko oprócz ostatniego wyrazu
                    nazwisko = parts[^1];                 // Wybiera ostatni wyraz jako nazwisko
                }
            }
        }

        public string Nazwisko
        {
            get => nazwisko;
            set => nazwisko = value;
        }

        public DateTime? DataUrodzenia { get; set; } = null;
        public DateTime? DataŚmierci { get; set; } = null;

        public TimeSpan? Wiek
        {
            get
            {
                if (DataUrodzenia == null)
                    return null;

                DateTime dataKońcowa = DataŚmierci ?? DateTime.Now;
                return dataKońcowa - DataUrodzenia;
            }
        }
    }
}
