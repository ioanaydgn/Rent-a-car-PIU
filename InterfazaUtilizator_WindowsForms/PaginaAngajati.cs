using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibrarieModele;
using NivelAccesDate;

namespace InterfazaUtilizator_WindowsForms
{
    public partial class PaginaAngajati : UserControl
    {
        private const int LUNGIME_CNP = 13;
        private const int INDEX_CMB = -1;
        private const int CNP_ = 2;
        IStocareAngajati adminAngajati = StocareFactory.GetAdministratorStocareAngajati();
        List<Angajat> angajati;
        public PaginaAngajati()
        {
            InitializeComponent();
            angajati = adminAngajati.GetAngajati();
            btnStergere.Enabled = false;
        }

        private void btnAdaugare_Click(object sender, EventArgs e)
        {

            string numeComplet;
            if (DateValide())
            {
                numeComplet = txtNumeAngajat.Text + "," + txtPrenumeAngajat.Text + "," + txtCNPAngajat.Text + "," + cbxFunctie.Text + "," + DateTime.Now;
                Angajat _angajat = new Angajat(numeComplet);
                angajati.Add(_angajat);
                //Adaugare angajat in fisier
                adminAngajati.AddAngajat(_angajat);
                lblMesaj.Text = "Adaugare realizata cu succes!";

            }
        }

        private void btnAfisare_Click(object sender, EventArgs e)
        {
            ResetareMesaje();
            btnStergere.Enabled = true;
            dgvAngajati.DataSource = angajati.Select(a => new { a.Nume, a.Prenume, a.CNP, a.Functie, a.dataActulalizare }).ToList();
        }

        private void btnCautare_Click(object sender, EventArgs e)
        {
            
            Angajat angajat_cautat;
            if (DateValide1())
            {
                ResetareMesaje();
                angajat_cautat = adminAngajati.GetAngajat(txtCautareNumeAngajat.Text, txtCautarePrenumeAngajat.Text);
                if (angajat_cautat == null)
                {
                    lblMesaj2.ForeColor = Color.Red;
                    lblMesaj2.Text = "Angajatul nu a fost gasit!";
                }
                else
                {                    
                    dgvAngajati.DataSource = angajat_cautat.ConversieLaSir();
                    btnAfisare.PerformClick();
                    lblMesaj2.Text = "Angajatul a fost gasit!";
                }
            }
        }

        private void btnModificare_Click(object sender, EventArgs e)
        {
           
            Angajat angajat_cautat;
           if(DateValide1())
            {
                ResetareMesaje();
                angajat_cautat = adminAngajati.GetAngajat(txtCautareNumeAngajat.Text, txtCautarePrenumeAngajat.Text);
                if (angajat_cautat == null)
                {
                    lblMesaj2.ForeColor = Color.Red;
                    lblMesaj2.Text = "Angajatul nu a fost gasit!";
                }
                else if(validare())
                {
                    int i = 0;
                    while (angajati[i].CNP != angajat_cautat.CNP)
                    {
                        i++;
                    }
                    if(txNume.Text != string .Empty )
                        angajati[i].Nume = txNume.Text;
                    if(txPrenume.Text != string.Empty)
                        angajati[i].Prenume = txPrenume.Text;
                    if(txCNP.Text != string.Empty)
                        angajati[i].CNP = txCNP.Text;
                    angajati[i].dataActulalizare = DateTime.Now;
                    adminAngajati.UpdateFisierAngajati(angajati);
                    lblMesaj3.Text = "Modificare realizata cu succes!";
                    btnAfisare.PerformClick();
                    ResetareMesaje2();
                }
            }
        }

        bool validare()
        {
            lblMesaj3.ForeColor = Color.Red;
            if(txCNP.Text == string.Empty && txNume.Text == string.Empty && txPrenume.Text == string.Empty)
            {
                lblMesaj3.Text = "Completati minim un camp";
                return false;
            }
            lblMesaj3.ForeColor = Color.Green;
            return true;
        }
        public void ResetareMesaje()
        {
            lblMesaj.Text = lblMesaj2.Text = lblMesaj3.Text = string.Empty;
            txtNumeAngajat.Text = string.Empty;
            txtPrenumeAngajat.Text = string.Empty;
            txtCNPAngajat.Text = string.Empty;
            cbxFunctie.SelectedIndex = INDEX_CMB;
        }
        public void ResetareMesaje2()
        {
            txNume.Text = string.Empty;
            txPrenume.Text = string.Empty;
            txCNP.Text = string.Empty;
            txtCautareNumeAngajat.Text = string.Empty;
            txtCautarePrenumeAngajat.Text = string.Empty;
        }
        private void btnStergere_Click(object sender, EventArgs e)
        {
            string index = dgvAngajati.CurrentRow.Cells[CNP_].Value.ToString();
            angajati.RemoveAll(m => m.CNP == index);
            adminAngajati.UpdateFisierAngajati(angajati);
            btnAfisare.PerformClick();
        }

        bool DateValide()
        {
            lblMesaj.ForeColor = Color.Red;
            if (txtNumeAngajat.Text == string.Empty)
            {
                lblMesaj.Text = "Completati casuta text nume..";
                return false;
            }
            if (txtPrenumeAngajat.Text == string.Empty)
            {
                lblMesaj.Text = "Completati casuta text prenume..";
                return false;
            }
            if (txtCNPAngajat.Text == string.Empty)
            {
                lblMesaj.Text = "Completati casuta text CNP..";
                return false;
            }
            else if (txtCNPAngajat.Text.Length != LUNGIME_CNP)
            {
                lblMesaj.Text = "CNP invalid";
                return false;
            }
            if (cbxFunctie.SelectedIndex == INDEX_CMB)
            {
                lblMesaj.Text = "Alegeti o functie!";
                return false;
            }
            lblMesaj.ForeColor = Color.Green;
            return true;
        }

        bool DateValide1()
        {
            lblMesaj2.ForeColor = Color.Red;
            if(txtCautareNumeAngajat.Text == string.Empty)
            {
                lblMesaj2.Text = "Completati castuta text nume..";
                return false;
            }
            if(txtCautarePrenumeAngajat.Text == string.Empty)
            {
                lblMesaj2.Text = "Completati casuta text prenume..";
                return false;
            }
            lblMesaj2.ForeColor = Color.Green;
            return true;
        }

    }
}
