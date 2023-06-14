using System;
using System.Collections;
using System.Collections.Generic;
using LibrarieModele;
using NivelAccesDate;

namespace InterfataUtilizator_Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Client> clienti ;
            List<Angajat> angajati ;
            List<Masina> masini ;
            List<Inchiriere> inchirieri  ;

     
            IStocareClienti adminClienti = StocareFactory.GetAdministratorStocareClienti();
            IStocareAngajati adminAngajati = StocareFactory.GetAdministratorStocareAngajati();
            IStocareMasini adminMasini = StocareFactory.GetAdministratorStocareMasini();
            IStocareInchirieri admminInchirieri = StocareFactory.GetAdministratorStocareInchirieri();
           

            clienti = adminClienti.GetClienti();
            angajati = adminAngajati.GetAngajati();
            masini = adminMasini.GetMasini();
            inchirieri = admminInchirieri.GetInchirieri();


            while (true)
            {
                Meniu();
                string optiune;
                optiune = Console.ReadLine();

                switch (optiune.ToUpper())
                {
                    case "AC":
                        AfisareClienti(clienti);
                        break;
                    case "AA":
                        AfisareAngajati(angajati);
                        break;
                    case "AM":
                        AfisareMasini(masini);
                        break;
                    case "AI":
                        AfisareInchirieri(inchirieri);
                        break;
                    case "CC":
                        Client clientTastatura = CitireClientTastatura();
                        clienti.Add(clientTastatura);
                        //adaugare client in fisier
                        adminClienti.AddClient(clientTastatura);
                        break;
                    case "CA":
                        Angajat angajatTastatura = CitireAngajatTastatura();
                        angajati.Add(angajatTastatura);
                        //adaugare angajat in fisier
                        adminAngajati.AddAngajat(angajatTastatura);
                        break;
                    case "CM":
                        Masina masinaTastatura = CitireMasinaTastatura();
                        masini.Add(masinaTastatura);
                        //adaugare masina in fisier
                        adminMasini.AddMasina(masinaTastatura);
                        break;
                    case "CI":
                        Inchiriere inchiriereTastatura = CitireInchiriereTastatura();
                        inchirieri.Add(inchiriereTastatura);
                        //adaugare inchiriere in fisier
                        admminInchirieri.AddInchiriere(inchiriereTastatura);
                        break;
                    case "SC":
                        CautareClient(adminClienti);
                        break;
                    case "SA":
                        CautareAngajat(adminAngajati);
                        break;
                    case "SM":
                        CautareMasina(adminMasini);
                        break;
                    case "SI":
                        CautareInchiriere(admminInchirieri);
                        break;
                    case "UC":
                        updateClient(adminClienti,clienti);
                        break;
                    case "UA":
                        updateAngajat(adminAngajati, angajati);
                        break;
                    case "UM":
                        updateMasina(adminMasini, masini);
                        break;
                    case "UI":
                        updateInchiriere(admminInchirieri, inchirieri);
                        break;
                    case "X":
                        return;
                    default:
                        Console.WriteLine("Optiune inexistenta");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void Meniu()
        {
            Console.WriteLine("AC/AA/AM/AI. Afisare clienti/angajati/masini/inchirieri.");
            Console.WriteLine("CC/CA/CM/CI. Creare si adaugare client/angajat/masina/inchiriere.");
            Console.WriteLine("SC/SA/SM/SI. Cauta client/angajat/masina/inchiriere in fisier.");
            Console.WriteLine("UC/UA/UM/UI. Update client/angajat/masina/inchiriere in fisier.");
            Console.WriteLine("X. Inchidere program.");
            Console.WriteLine("Alegeti o optiune.");
        }
        public static void ListaModele()
        {
            Console.WriteLine("1 - Opel");
            Console.WriteLine("2 - Renault");
            Console.WriteLine("3 - BMW");
            Console.WriteLine("4 - Audi");
            Console.WriteLine("5 - Dacia");
            Console.WriteLine("6 - Ford");
            Console.WriteLine("7 - Volkswagen");
            Console.WriteLine("8 - Mercedes");
            Console.WriteLine("9 - Tesla");
        }

        public static void ListaOptiuni()
        {
            Console.WriteLine("\n0 - Niciuna");
            Console.WriteLine("1 - Aer conditionat");
            Console.WriteLine("2 - Navigatie");
            Console.WriteLine("4 - Cutie automata");
            Console.WriteLine("8 - Geamuri elesctice");
            Console.WriteLine("16 - Decapotabila");
        }

        #region Client
        public static void AfisareClienti(List<Client> clienti)
        {
            Console.WriteLine("Clientii sunt:");
            for (int i = 0; i < clienti.Count; i++)
            {
                Console.WriteLine(((Client)clienti[i]).ConversieLaSir());
                Console.WriteLine("\n");
            }

        }
        public static Client CitireClientTastatura()
        {
            Console.WriteLine("Introduceti numele");
            string nume = Console.ReadLine();

            Console.WriteLine("Introduceti prenumele");
            string prenume = Console.ReadLine();

            Console.WriteLine("Introduceit cnp-ul:");
            string cnp = Console.ReadLine();

            Console.WriteLine("Introduceti id:");
            string id = Console.ReadLine();

            string numeComplet = nume + "," + prenume + "," + cnp + "," + id;
            Client client = new Client(numeComplet);
            return client;
        }

        public static void CautareClient(IStocareClienti admminClienti)
        {
            string nume, prenume;
            Console.Write("Introduceti numele clientului cautat: ");
            nume = Console.ReadLine();
            Console.Write("Introduceti prenumele clientului cautat: ");
            prenume = Console.ReadLine();
            Console.WriteLine("Clientul cautat este:");
            Client client_cautat = admminClienti.GetClient(nume, prenume);
            if (client_cautat == null)
                Console.WriteLine("Acest client nu a fost gasit.");
            else
                Console.WriteLine(client_cautat.ConversieLaSir());
        }

        public static void updateClient(IStocareClienti admminClienti, List<Client> clienti)
        {
            string nume, prenume;
            Console.Write("Introduceti numele clientului ale carui informatii doresti sa le modifici : ");
            nume = Console.ReadLine();
            Console.Write("Introduceti prenumele clientului: ");
            prenume = Console.ReadLine();
            Console.WriteLine("Clientul exista in baza de date...");
            Client client_cautat = admminClienti.GetClient(nume, prenume);
            if (client_cautat == null)
                Console.WriteLine("Acest client nu a fost gasit.");
            else
            {
                Console.WriteLine("Selecteaza ceea ce doresti sa modifici (n-nume, p-prenume, c-CNP, cp = CNP+prenume,etc):");
                string update = Console.ReadLine();
                int i = 0;
                while(clienti[i].CNP!=client_cautat.CNP)
                {
                    i++;
                }
                
           
                if(update.Contains("n"))
                {
                    Console.WriteLine("Introdu noul nume: ");
                    clienti[i].Nume = Console.ReadLine();
                }
                
                if(update.Contains("p"))
                {
                    Console.WriteLine("Introdu noul prenume: ");
                    clienti[i].Prenume = Console.ReadLine();
                }

                if (update.Contains("c"))
                {
                    Console.WriteLine("Introdu noul CNP: ");
                    clienti[i].CNP = Console.ReadLine();
                }
             
                Console.WriteLine("Modificare realizata cu succes!");
            }
        }
        #endregion

        #region Angajat
        public static void AfisareAngajati(List<Angajat> angajati)
        {
            Console.WriteLine("Angajatii sunt:");
            for (int i = 0; i < angajati.Count; i++)
            {
                Console.WriteLine(((Angajat)angajati[i]).ConversieLaSir());
                Console.WriteLine("\n");
            }
        }

        public static Angajat CitireAngajatTastatura()
        {
            Console.WriteLine("Introduceti numele");
            string nume = Console.ReadLine();

            Console.WriteLine("Introduceti prenumele");
            string prenume = Console.ReadLine();

            Console.WriteLine("Introduceit cnp-ul:");
            string cnp = Console.ReadLine();

            Console.WriteLine("Introduceti functia:");
            string functie = Console.ReadLine();

            string numeComplet = nume + "," + prenume + "," + cnp + "," + functie;
            Angajat angajat = new Angajat(numeComplet);
            return angajat;
        }
        public static void CautareAngajat(IStocareAngajati admminAngajati)
        {
            string nume, prenume;
            Console.Write("Introduceti numele angajatului cautat: ");
            nume = Console.ReadLine();
            Console.Write("Introduceti prenumele angajatului cautat: ");
            prenume = Console.ReadLine();
            Console.WriteLine("Angajatul cautat este:");
            Angajat angajat_cautat = admminAngajati.GetAngajat(nume, prenume);
            if (angajat_cautat == null)
                Console.WriteLine("Acest angajat nu a fost gasit.");
            else
                Console.WriteLine(angajat_cautat.ConversieLaSir());
        }
        public static void updateAngajat(IStocareAngajati admminAngajati, List<Angajat> angajati)
        {
            string nume, prenume;
            Console.Write("Introduceti numele angajatului ale carui informatii doresti sa le modifici : ");
            nume = Console.ReadLine();
            Console.Write("Introduceti prenumele angajatului: ");
            prenume = Console.ReadLine();
            Angajat angajat_cautat = admminAngajati.GetAngajat(nume, prenume);
            if (angajat_cautat == null)
                Console.WriteLine("Acest angajat nu a fost gasit.");
            else
            {
                Console.WriteLine("Selecteaza ceea ce doresti sa modifici (n-nume, p-prenume, c-CNP, cp = CNP+prenume,etc):");
                string update = Console.ReadLine();
                int i = 0;
                while (angajati[i].CNP != angajat_cautat.CNP)
                {
                    i++;
                }


                if (update.Contains("n"))
                {
                    Console.WriteLine("Introdu noul nume: ");
                    angajati[i].Nume = Console.ReadLine();
                }

                if (update.Contains("p"))
                {
                    Console.WriteLine("Introdu noul prenume: ");
                    angajati[i].Prenume = Console.ReadLine();
                }

                if (update.Contains("c"))
                {
                    Console.WriteLine("Introdu noul CNP: ");
                    angajati[i].CNP = Console.ReadLine();
                }
                admminAngajati.UpdateFisierAngajati(angajati);
                Console.WriteLine("Modificare realizata cu succes!");
            }
        }
        #endregion

        #region Masina
        public static void AfisareMasini(List<Masina> masini)
        {
            Console.WriteLine("Masinile inscrise sunt:");
            for (int i = 0; i < masini.Count; i++)
            {
                Console.WriteLine(((Masina)masini[i]).ConversieLaSir());
                Console.WriteLine("\n");
            }

        }
        public static Masina CitireMasinaTastatura()
        {
            ListaModele();
            Console.WriteLine("Introduceti model:");
            int model = int.Parse(Console.ReadLine());

            Console.WriteLine("Introduceti seria:");
            string serie = Console.ReadLine();

            Console.WriteLine("Introduceit pretul:");
            int pret = Convert.ToInt32(Console.ReadLine());

            ListaOptiuni();
            Console.WriteLine("Introduceti optiunile masinii (sub forma x-y-z):");
            string optiuni = Console.ReadLine();
            

            string numeComplet = model + "," + serie + "," + pret + "," + optiuni;
            Masina masina = new Masina(numeComplet);
            return masina;
        }

        public static void CautareMasina(IStocareMasini admminMasini)
        {
            string serie;
            Console.Write("Introduceti seria masinii pe care o cautati: ");
            serie = Console.ReadLine();
            Console.WriteLine("Masina cautata este:");
            Masina masina_cautata = admminMasini.GetMasina(serie);
            if (masina_cautata == null)
                Console.WriteLine("Acesta masina nu a fost gasita.");
            else
                Console.WriteLine(masina_cautata.ConversieLaSir());
        }

        public static void updateMasina(IStocareMasini admminMasini, List<Masina> masini)
        {
            string serie;
            Console.Write("Introduceti seria masinii ale carui informatii doresti sa le modifici : ");
            serie = Console.ReadLine();
            Masina masina_cautata = admminMasini.GetMasina(serie);
            if (masina_cautata == null)
                Console.WriteLine("Acesta masina nu a fost gasita.");
            else
            {
                Console.WriteLine("Selecteaza ceea ce doresti sa modifici (m-model, s-serie, p-pret, o-optiuni, mp = model+pret,etc):");
                string update = Console.ReadLine();
                int i = 0;
                while (masini[i].Serie != masina_cautata.Serie)
                {
                    i++;
                }


                if (update.Contains("m"))
                {
                    ListaModele();
                    Console.WriteLine("Introdu cifra corespunzatoare noului model: ");
                     masini[i].Model = (ModelMasina)int.Parse(Console.ReadLine());
                    
                }

                if (update.Contains("s"))
                {
                    Console.WriteLine("Introdu noua serie: ");
                    masini[i].Serie = Console.ReadLine();
                }

                if (update.Contains("p"))
                {
                    Console.WriteLine("Introdu noul pret: ");
                    masini[i].Pret = Convert.ToInt32(Console.ReadLine());
                }

                if (update.Contains("o"))
                {
                    ListaOptiuni();
                    Console.WriteLine("Introdu noile optiuni: ");
                    masini[i].Optiuni = (OptiuniMasina)0;
                    string[] optiuni = Console.ReadLine().Split('-');

                    foreach (string optiune in optiuni)
                    {
                        masini[i].Optiuni |= (OptiuniMasina)int.Parse(optiune);
                    }
                }



                admminMasini.UpdateFisierMasini(masini);



                Console.WriteLine("Modificare realizata cu succes!");
            }
        }
        #endregion

        #region Inchirieri
        public static void AfisareInchirieri(List<Inchiriere> inchirieri)
        {
            Console.WriteLine("Inchirierile efectuate sunt:");
            for (int i = 0; i < inchirieri.Count; i++)
            {
                Console.WriteLine(((Inchiriere)inchirieri[i]).ConversieLaSir());
                Console.WriteLine("\n");
            }

        }
        public static Inchiriere CitireInchiriereTastatura()
        {
            Console.WriteLine("Introduceti ID-ul corespunzator inchirierii:");
            string _ID_inchiriere = Console.ReadLine();

            Console.WriteLine("Introduceti CNP corespunzator clientului:");
            string _CNP_client= Console.ReadLine();

            Console.WriteLine("Introduceit data inceperii inchirierii:");
            string _DataInc = Console.ReadLine();

            Console.WriteLine("Introduceti data terminarii inchirierii:");
            string _DataTer = Console.ReadLine();

            string Complet = _ID_inchiriere + "," + _CNP_client + "," + _DataInc + "," + _DataTer;
            Inchiriere inchiriere = new Inchiriere(Complet);
            return inchiriere;
        }

        public static void CautareInchiriere(IStocareInchirieri admminInchirieri)
        {
            Console.WriteLine("Introduceti ID-ul pe care doriti sa-l cautati:");
            string _ID_inchiriere = Console.ReadLine();

            Inchiriere inchiriere_cautata = admminInchirieri.GetInchiriere(Convert.ToInt32(_ID_inchiriere));
            if (inchiriere_cautata == null)
                Console.WriteLine("Aceasta inchiriere nu a fost gasita.");
            else
                Console.WriteLine(inchiriere_cautata.ConversieLaSir());
        }

        public static void updateInchiriere(IStocareInchirieri admminInchirieri, List<Inchiriere> inchirieri)
        {

            Console.WriteLine("Introduceti ID-ul pe care doriti sa-l cautati:");
            string _ID_inchiriere = Console.ReadLine();

            Inchiriere inchiriere_cautata = admminInchirieri.GetInchiriere(int.Parse(_ID_inchiriere));
            if (inchiriere_cautata == null)
                Console.WriteLine("Aceasta inchiriere nu a fost gasita.");
            else
            {
                Console.WriteLine("Selecteaza ceea ce doresti sa modifici (i-id, c-CNP, d-data incepere, t-data terminare, dt = data incepere + data terminare,etc):");
                string update = Console.ReadLine();
                int i = 0;
                while (inchirieri[i].ID_inchiriere != inchiriere_cautata.ID_inchiriere)
                {
                    i++;
                }


                if (update.Contains("i"))
                {
                    Console.WriteLine("Introdu noul ID: ");
                    inchirieri[i].ID_inchiriere = Convert.ToInt32(Console.ReadLine());
                }

                if (update.Contains("c"))
                {
                    Console.WriteLine("Introdu noul CNP: ");
                    inchirieri[i].CNP_client = Console.ReadLine();
                }

                if (update.Contains("d"))
                {
                    Console.WriteLine("Introdu alta data de incepere: ");
                    inchirieri[i].dataIncepere = Console.ReadLine();
                }

                if (update.Contains("t"))
                {
                    Console.WriteLine("Introdu alta data de terminare: ");
                    inchirieri[i].dataTerminare = Console.ReadLine();
                }
                admminInchirieri.UpdateFisierInchirieri(inchirieri);
                Console.WriteLine("Modificare realizata cu succes!");
            }
        }
        #endregion

    }
}

