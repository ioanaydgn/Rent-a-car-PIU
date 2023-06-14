using LibrarieModele;
using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;

namespace NivelAccesDate
{
    //clasa AdministrareStudenti_FisierText implementeaza interfata IStocareData
    public class AdministrareMasini_FisiereText : IStocareMasini
    {
      
        string NumeFisierMasini { get; set; }
       

        public AdministrareMasini_FisiereText(string numeFisierMasini)
        {
           
            this.NumeFisierMasini = numeFisierMasini;
           

            
            Stream s2FisierText = File.Open(numeFisierMasini, FileMode.OpenOrCreate);
            
          
            s2FisierText.Close();
           
        }
     

        #region Masina
        public void AddMasina(Masina masina)
        {
            try
            {
                using (StreamWriter swFisierText = new StreamWriter(NumeFisierMasini, true))
                {
                    swFisierText.WriteLine(masina.ConversieLaSir_PentruScriereInFisier());
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

        public void UpdateFisierMasini(List<Masina> masini)
        {
            try
            {
                using (StreamWriter swFisierText = new StreamWriter(NumeFisierMasini, false))
                {
                    foreach (Masina masina in masini)
                        swFisierText.WriteLine(masina.ConversieLaSir_PentruScriereInFisier());
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
        public List<Masina> GetMasini()
        {
            List<Masina> masini = new List<Masina>();

            try
            {
                // instructiunea 'using' va apela sr.Close()
                using (StreamReader sr = new StreamReader(NumeFisierMasini))
                {
                    string line;

                    //citeste cate o linie si creaza un obiect de tip Student pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        Masina masinaDinFisier = new Masina(line);
                        masini.Add(masinaDinFisier);
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

            return masini;
        }

        public Masina GetMasina(string serie)
        {
            try
            {
                // instructiunea 'using' va apela sr.close()
                using (StreamReader sr = new StreamReader(NumeFisierMasini))
                {
                    string line;

                    //citeste cate o linie si creaza un obiect de tip student pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        Masina masinaDinFisier = new Masina(line);
                        if (masinaDinFisier.Serie == serie)
                            return masinaDinFisier;
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
