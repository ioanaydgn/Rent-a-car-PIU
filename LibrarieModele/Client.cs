using System;

namespace LibrarieModele
{
    public class Client : Persoana
    {
        //Constante
        private const char SEPARATOR_PRINCIPAL_FISIER = ',';
        private const int ID = 0;
        private const int NUME = 1;
        private const int PRENUME = 2;
        private const int CNP_ = 3;

        public int ID_Client { get; set; }


        public Client(string data) : base(data)
        {
            string[] _date = data.Split(',');
            Nume = _date[NUME];
            Prenume = _date[PRENUME];
            CNP = _date[CNP_];
            int.TryParse(_date[ID], out int id);
            ID_Client = id;

        }

        public override string ConversieLaSir()
        {
            string dateForDisplay = $"ID: {ID_Client}\nNume: {Nume} {Prenume}\nCNP: {CNP}";
            return dateForDisplay;
        }

        public string ConversieLaSir_PentruScriereInFisier()
        {
            string s = string.Format("{1}{0}{2}{0}{3}{0}{4}",
                SEPARATOR_PRINCIPAL_FISIER, ID_Client, (Nume ?? " NECUNOSCUT "), (Prenume ?? " NECUNOSCUT "), (CNP ?? " NECUNOSCUT "));

            return s;
        }
    }
}
