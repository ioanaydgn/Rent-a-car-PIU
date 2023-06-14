

namespace LibrarieModele
{
    public class Persoana
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string CNP { get; set; }
        public Persoana()//Constructor implicit
        {
            Nume = Prenume = CNP = string.Empty;
        }
        public Persoana(string data)
        {
            string[] _date = data.Split(',');
            Nume = _date[0];
            Prenume = _date[1];
            CNP = _date[2];
            
        }

        virtual public string ConversieLaSir()
        {
            string dateForDisplay = $"Nume: { Nume} { Prenume}\nCNP: { CNP}";


            return dateForDisplay;
        }
    }
}
