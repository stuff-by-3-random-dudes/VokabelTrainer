using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglischAbfrage
{
    class Aufgabe
    {
        private string frage;
        private List<string> antwort;
        public int CurrentID { get; set; }
        //private string[] aBackup;
        private List<string> beantwortet = new List<string>();
        public bool Richtig { get; set; } = false;

        public Aufgabe(string frage, List<string> antwort)
        {
            this.frage = frage;
            this.antwort = antwort;
            //aBackup = new string[antwort.Count];
            //antwort.CopyTo(aBackup);
        }
        public Aufgabe(string frage, List<string> antwort, int id)
        {
            this.frage = frage;
            this.antwort = antwort;
            CurrentID = id;
            //aBackup = new string[antwort.Count];
            //antwort.CopyTo(aBackup);
        }
        public string GetFrage()
        {
            return frage;
        }
        public List<string> GetAntwort()
        {
            return antwort;
        }
        public List<string> GetBeantwortet()
        {
            return beantwortet;
        }
        public bool AllesGefragt()
        {
            bool allesGefragt = false;
            if (antwort.Count == 0)
            {
                allesGefragt = true;
            }
            return allesGefragt;
        }
        public void PruefeAntwort(string eingabe)
        {
            bool richtig = false;
            string remove = string.Empty;
            foreach (string aw in antwort)
            {
                if (eingabe.Trim() == aw || eingabe.Trim() == aw.Trim())
                {
                    richtig = true;
                    remove = aw;
                }
            }
            if (richtig)
            {
                antwort.Remove(remove);
                beantwortet.Add(remove);
            }
            this.Richtig = richtig;
        }
        public void Reset()
        {
            //antwort = aBackup.ToList();
            foreach (string s in beantwortet)
            {
                antwort.Add(s);
            }
            beantwortet.Clear();
        }
        public string GetRightAnswer()
        {
            string ausgabe = $"Frage: {frage}\n\nAntworten:";
            foreach (string aw in antwort)
            {
                ausgabe += $"\n\t{aw}";
            }
            return ausgabe;
        }
        public int GetAnzahlAntworten()
        {
            return antwort.Count() + beantwortet.Count();
        }
    }
}
