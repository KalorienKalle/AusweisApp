using System;

namespace AusweisApp
{ 
    public abstract class Ausweis
    {
        public Inhaber Inhaber { get; set; }
        public string Ausweisnummer { get; set; }
        public DateTime Ablaufdatum { get; set; }
    }

    public class Inhaber
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Wohnort { get; set; }
        public string Augenfarbe { get; set; }
        public double Körpergröße { get; set; }
        public DateTime Geburtsdatum { get; set; }

        public override string ToString()
        {
            return $"Inhaber: {Vorname} {Nachname}, Wohnort: {Wohnort}, Augenfarbe: {Augenfarbe}, Körpergröße: {Körpergröße}, Geburtsdatum: {Geburtsdatum.ToShortDateString()}";
        }
    }

    public class Fingerabdruck
    {
        public string ID { get; set; }

        public override string ToString()
        {
            return $"Fingerabdruck ID: {ID}";
        }
    }

    // Abgeleitete Klasse Personalausweis
    public class Personalausweis : Ausweis
    {
        public Fingerabdruck Fingerabdruck { get; set; }

        public Personalausweis(Inhaber inhaber, string ausweisnummer, DateTime ablaufdatum, Fingerabdruck fingerabdruck)
        {
            Inhaber = inhaber;
            Ausweisnummer = ausweisnummer;
            Ablaufdatum = ablaufdatum;
            Fingerabdruck = fingerabdruck;
        }

        public override string ToString()
        {
            return $"Personalausweis:\n{Inhaber}\nAusweisnummer: {Ausweisnummer}, Ablaufdatum: {Ablaufdatum.ToShortDateString()}\n{Fingerabdruck}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Beispielhafte Daten für Inhaber, Personalausweis und Fingerabdruck
            Inhaber inhaber = new Inhaber
            {
                Vorname = "Max",
                Nachname = "Mustermann",
                Wohnort = "Kiel",
                Augenfarbe = "Blau",
                Körpergröße = 1.80,
                Geburtsdatum = new DateTime(1990, 1, 1)
            };

            Fingerabdruck fingerabdruck = new Fingerabdruck
            {
                ID = "FA123456"
            };

            Personalausweis personalausweis = new Personalausweis(inhaber, "PA123456", new DateTime(2030, 12, 31), fingerabdruck);

            // Ausgabe der Testergebnisse
            Console.WriteLine(personalausweis.ToString());
        }
    }
}