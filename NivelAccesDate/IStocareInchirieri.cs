using LibrarieModele;
using System.Collections;
using System.Collections.Generic;

namespace NivelAccesDate
{
    //definitia interfetei
    public interface IStocareInchirieri
    { 
        #region Inchirieri
        void AddInchiriere(Inchiriere inchiriere);
        void UpdateFisierInchirieri(List<Inchiriere> inchirieri);
        Inchiriere GetInchiriere(int ID_inchiriere);
        List<Inchiriere> GetInchirieri();
        #endregion
        
    }
}
