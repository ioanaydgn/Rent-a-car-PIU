using System;

namespace LibrarieModele
{
    public class Angajat : Persoana
    {
        //Constante
        private const char SEPARATOR_PRINCIPAL_FISIER = ',';   
        private const int FUNCTIE = 3;
        private const int DATA = 4;

        public string Functie { get; set; }

        public DateTime dataActulalizare { get; set; }

        public Angajat(string _date):base(_date)
        {
            string[] Date = _date.Split(',');
            Functie = Date[FUNCTIE];
            dataActulalizare = DateTime.Parse(Date[DATA]);
        }

        public override string ConversieLaSir()
        {
            string dateForDiplay = $"Nume: {Nume} {Prenume}\nCNP: {CNP}\nFunctie: {Functie}";

            return dateForDiplay;
        }

        public string ConversieLaSir_PentruScriereInFisier()
        {
            string s = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}",
                SEPARATOR_PRINCIPAL_FISIER, (Nume ?? " NECUNOSCUT "), (Prenume ?? " NECUNOSCUT "), (CNP ?? " NECUNOSCUT "),(Functie ?? " NECUNOSCUT "),(dataActulalizare));
            return s;
        }
    }
}
