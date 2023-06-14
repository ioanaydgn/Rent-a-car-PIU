using LibrarieModele;
using System.Collections;
using System.Collections.Generic;

namespace NivelAccesDate
{
    //definitia interfetei
    public interface IStocareClienti
    {
        #region Clienti
        void AddClient(Client client);
        void UpdateFisierClienti(List<Client> clienti);
        Client GetClient(string nume, string prenume);//aici trb schimbat cu string data
        List<Client> GetClienti();
        #endregion
        
    }
}
