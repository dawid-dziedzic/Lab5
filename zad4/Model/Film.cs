using System;

namespace zad4.Model
{
    public class Film
    {
        public int id { get; set; }
        public string Tytul { get; set; }
        public string Kategoria { get; set; } 
        public DateTime Rok { get; set; }
        public decimal Koszt { get; set; }
        public string Kraj { get; set; }

    }
}
