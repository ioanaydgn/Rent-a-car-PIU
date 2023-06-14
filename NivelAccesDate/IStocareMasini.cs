using LibrarieModele;
using System.Collections;
using System.Collections.Generic;

namespace NivelAccesDate
{
    //definitia interfetei
    public interface IStocareMasini
    {
        #region Masini
        void AddMasina(Masina masina);
        void UpdateFisierMasini(List<Masina> masini);
        Masina GetMasina(string serie);

        List<Masina> GetMasini();
        #endregion


    }
}
