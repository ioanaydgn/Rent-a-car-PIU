

namespace LibrarieModele
{
    public class Inchiriere
    {
        //Constante
        private const char SEPARATOR_PRINCIPAL_FISIER = ',';
        private const int ID = 0;
        private const int CNP = 1;
        private const int DATA_INC = 2;
        private const int DATA_TER = 3;
        private const int SERIE = 4;

        public int ID_inchiriere { get; set; }
        public string CNP_client { get; set; }
        public string Serie_Masina { get; set; }
        public string dataIncepere { get; set; }
        public string dataTerminare { get; set; }

        public Inchiriere(string _date)
        {
            string[] date = _date.Split(',');
            CNP_client = date[CNP];
            int.TryParse(date[ID], out int id);
            ID_inchiriere = id;
            dataIncepere = date[DATA_INC];
            dataTerminare = date[DATA_TER];
            Serie_Masina = date[SERIE];
        }

        public string ConversieLaSir()
        {
            string dateForDisplay = $"ID inchiriere: {ID_inchiriere}\nCNP client: {CNP_client}\nSerie masina: {Serie_Masina}\nInterval inchiriere: {dataIncepere} - {dataTerminare}";
            return dateForDisplay;
        }

        public string ConversieLaSir_PentruScriereInFisier()
        {
            string s = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}",
                SEPARATOR_PRINCIPAL_FISIER, ID_inchiriere,(CNP_client ?? " NECUNOSCUT "),  (dataIncepere ?? " NECUNOSCUT "), (dataTerminare ?? " NECUNOSCUT "),(Serie_Masina ?? " NECUNOSCUT"));
            return s;
        }
    }
}
