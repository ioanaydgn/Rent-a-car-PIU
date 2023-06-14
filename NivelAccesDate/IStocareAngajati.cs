using LibrarieModele;
using System.Collections;
using System.Collections.Generic;

namespace NivelAccesDate
{
    //definitia interfetei
    public interface IStocareAngajati
    {
        #region Angajati
        void AddAngajat(Angajat angajat);

        void UpdateFisierAngajati(List<Angajat> angajati);

        Angajat GetAngajat(string nume, string prenume);

        List<Angajat> GetAngajati();
        #endregion
       
    }
}
