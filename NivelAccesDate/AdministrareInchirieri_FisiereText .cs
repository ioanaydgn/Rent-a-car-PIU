using LibrarieModele;
using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;

namespace NivelAccesDate
{
    //clasa AdministrareStudenti_FisierText implementeaza interfata IStocareData
    public class AdministrareInchirieri_FisiereText : IStocareInchirieri
    {
        private const int ID_PRIMA_INCHIRIERE = 1;
        private const int INCREMENT = 1;
        string NumeFisierInchirieri { get; set; }

        public AdministrareInchirieri_FisiereText(string numeFisierInchirieri)
        {
         
            this.NumeFisierInchirieri = numeFisierInchirieri;

           
            Stream s3FisierText = File.Open(numeFisierInchirieri, FileMode.OpenOrCreate);

           
            s3FisierText.Close();
        }

        #region Inchiriere
        public void AddInchiriere(Inchiriere inchiriere)
        {
            inchiriere.ID_inchiriere = GetId();
            try
            {
                using (StreamWriter swFisierText = new StreamWriter(NumeFisierInchirieri, true))
                {
                    swFisierText.WriteLine(inchiriere.ConversieLaSir_PentruScriereInFisier());
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
        }


        public void UpdateFisierInchirieri(List<Inchiriere> inchirieri)
        {
            try
            {
                using (StreamWriter swFisierText = new StreamWriter(NumeFisierInchirieri, false))
                {
                    foreach (Inchiriere inchiriere in inchirieri)
                        swFisierText.WriteLine(inchiriere.ConversieLaSir_PentruScriereInFisier());
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
        }

        public List<Inchiriere> GetInchirieri()
        {
            List<Inchiriere> inchirieri = new List<Inchiriere>();

            try
            {
                // instructiunea 'using' va apela sr.Close()
                using (StreamReader sr = new StreamReader(NumeFisierInchirieri))
                {
                    string line;

                    //citeste cate o linie si creaza un obiect de tip Student pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        Inchiriere inchiriereDinFisier = new Inchiriere(line);
                        inchirieri.Add(inchiriereDinFisier);
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }

            return inchirieri;
        }

        public Inchiriere GetInchiriere(int ID_inchiriere)
        {
            try
            {
                // instructiunea 'using' va apela sr.close()
                using (StreamReader sr = new StreamReader(NumeFisierInchirieri))
                {
                    string line;

                    //citeste cate o linie si creaza un obiect de tip student pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        Inchiriere inchiriereDinFisier = new Inchiriere(line);
                        if (inchiriereDinFisier.ID_inchiriere == ID_inchiriere)
                            return inchiriereDinFisier;
                    }
                }
            }
            catch (IOException eio)
            {
                throw new Exception("eroare la deschiderea fisierului. mesaj: " + eio.Message);
            }
            catch (Exception egen)
            {
                throw new Exception("eroare generica. mesaj: " + egen.Message);
            }

            return null;
        }
        #endregion

        private int GetId()
        {
            int IdInchiriere = ID_PRIMA_INCHIRIERE;
            try
            {
                // instructiunea 'using' va apela sr.Close()
                using (StreamReader sr = new StreamReader(NumeFisierInchirieri))
                {
                    string LinieDinFisier;
                    Inchiriere ultimaInchiriereDinFisier = null;

                    //citeste cate o linie si creaza un obiect de tip Student pe baza datelor din linia citita
                    while ((LinieDinFisier = sr.ReadLine()) != null)
                    {
                        ultimaInchiriereDinFisier = new Inchiriere(LinieDinFisier);
                    }

                    if (ultimaInchiriereDinFisier != null)
                    {
                        IdInchiriere = ultimaInchiriereDinFisier.ID_inchiriere + INCREMENT;
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
            return IdInchiriere;
        }
    }
}
