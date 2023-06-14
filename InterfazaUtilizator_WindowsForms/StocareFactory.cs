using NivelAccesDate;
using System.Configuration;

namespace InterfazaUtilizator_WindowsForms
{
    class StocareFactory
    {
        private const string FORMAT_SALVARE = "FormatSalvare";
        private const string NUME_FISIER_CLIENTI = "NumeFisierClienti";
        private const string NUME_FISIER_ANGAJATI = "NumeFisierAngajati";
        private const string NUME_FISIER_MASINI = "NumeFisierMasini";
        private const string NUME_FISIER_INCHIRIERI = "NumeFisierInchirieri";

        public static IStocareClienti GetAdministratorStocareClienti()
        {
            var formatSalvare = ConfigurationManager.AppSettings[FORMAT_SALVARE];
            var numeFisierClienti = ConfigurationManager.AppSettings[NUME_FISIER_CLIENTI];
            if(formatSalvare != null)
            {
                return new AdministrareClienti_FisiereText(numeFisierClienti + "." + formatSalvare);
            }
            return null;
        }
        public static IStocareAngajati GetAdministratorStocareAngajati()
        {
            var formatSalvare = ConfigurationManager.AppSettings[FORMAT_SALVARE];
            var numeFisierAngajati = ConfigurationManager.AppSettings[NUME_FISIER_ANGAJATI];
           
            if (formatSalvare != null)
            {
                return new AdministrareAngajati_FisiereText( numeFisierAngajati + "." + formatSalvare);
            }
            return null;
        }
        public static IStocareMasini GetAdministratorStocareMasini()
        {
            var formatSalvare = ConfigurationManager.AppSettings[FORMAT_SALVARE];
            var numeFisierMasini = ConfigurationManager.AppSettings[NUME_FISIER_MASINI];
            if (formatSalvare != null)
            {
                return new AdministrareMasini_FisiereText(numeFisierMasini + "." + formatSalvare);
            }
            return null;
        }
        public static IStocareInchirieri GetAdministratorStocareInchirieri()
        {
            var formatSalvare = ConfigurationManager.AppSettings[FORMAT_SALVARE];
            var numeFisierInchirieri = ConfigurationManager.AppSettings[NUME_FISIER_INCHIRIERI];
            if (formatSalvare != null)
            {
                return new AdministrareInchirieri_FisiereText(numeFisierInchirieri + "." + formatSalvare);
            }
            return null;
        }
    }
}
