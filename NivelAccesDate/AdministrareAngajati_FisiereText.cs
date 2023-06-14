using LibrarieModele;
using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;

namespace NivelAccesDate
{
    //clasa AdministrareStudenti_FisierText implementeaza interfata IStocareData
    public class AdministrareAngajati_FisiereText : IStocareAngajati
    {
        
        string NumeFisierAngajati { get; set; }
       

        public AdministrareAngajati_FisiereText(string numeFisierAngajati)
        {
            
            this.NumeFisierAngajati = numeFisierAngajati;
            

            
            Stream s1FisierText = File.Open(numeFisierAngajati, FileMode.OpenOrCreate);
          

            
            s1FisierText.Close();
            
        }
       

        #region Angajat
        public void AddAngajat(Angajat angajat)
        {
            try
            {
                using (StreamWriter swFisierText = new StreamWriter(NumeFisierAngajati, true))
                {
                    angajat.dataActulalizare = DateTime.Now;
                    swFisierText.WriteLine(angajat.ConversieLaSir_PentruScriereInFisier());
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

        public void UpdateFisierAngajati(List<Angajat> angajati)
        {
            try
            {
                using (StreamWriter swFisierText = new StreamWriter(NumeFisierAngajati, false))
                {
                    foreach (Angajat angajat in angajati)
                        swFisierText.WriteLine(angajat.ConversieLaSir_PentruScriereInFisier());
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
        public List<Angajat> GetAngajati()
        {
            List<Angajat> angajati = new List<Angajat>();

            try
            {
                // instructiunea 'using' va apela sr.Close()
                using (StreamReader sr = new StreamReader(NumeFisierAngajati))
                {
                    string line;

                    //citeste cate o linie si creaza un obiect de tip Student pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        Angajat angajatDinFisier = new Angajat(line);
                        angajati.Add(angajatDinFisier);
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

            return angajati;
        }

        public Angajat GetAngajat(string nume, string prenume)
        {
            try
            {
                // instructiunea 'using' va apela sr.close()
                using (StreamReader sr = new StreamReader(NumeFisierAngajati))
                {
                    string line;

                    //citeste cate o linie si creaza un obiect de tip student pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        Angajat angajatDinFisier = new Angajat(line);
                        if (angajatDinFisier.Nume == nume && angajatDinFisier.Prenume == prenume)
                            return angajatDinFisier;
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

  
    }
}
