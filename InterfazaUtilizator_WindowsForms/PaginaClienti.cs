using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NivelAccesDate;
using LibrarieModele;
using System.Windows.Forms;

namespace InterfazaUtilizator_WindowsForms
{
    public partial class PaginaClienti : UserControl
    {
        private const int LUNGIME_CNP = 13;
        private const int CNP_ = 3;
        IStocareClienti adminClienti = StocareFactory.GetAdministratorStocareClienti();    
        List<Client> clienti = new List<Client>();
       
        public PaginaClienti()
        {
            InitializeComponent();
            clienti = adminClienti.GetClienti();
            btnStergere.Enabled = false;
        }

        private void btnAdaugare_Click(object sender, EventArgs e)
        {
            
            if(DateValide())
            {
                string numeComplet;
                
                numeComplet = ","+txtNumeClient.Text + "," + txtPrenumeClient.Text + "," + txtCNPClient.Text;  
                Client _client = new Client(numeComplet);
                clienti.Add(_client);
                //Adaugare client in fisier
                adminClienti.AddClient(_client);
                ResetareMesaje();
                lblMesaj.Text = "Adaugare realizata cu succes!";
            }
            
        }

        private void btnAfisare_Click(object sender, EventArgs e)
        {
            ResetareMesaje();
            btnStergere.Enabled = true;
            dgvClienti.DataSource = clienti.Select(a => new { a.ID_Client,a.Nume,a.Prenume, a.CNP}).ToList();
            
        }

        private void btnCautare_Click(object sender, EventArgs e)
        {
            
           
           if(DateValide1())
            {
                Client client_cautat = adminClienti.GetClient(txtCautareNumeClient.Text, txtCautarePrenumeClient.Text);
                if (client_cautat == null)
                {
                    lblMesaj2.ForeColor = Color.White;
                    lblMesaj2.Text = "Clientul nu a fost gasit!";
                }
                else
                {
                    dgvClienti.DataSource = client_cautat.ConversieLaSir();
                    lblMesaj2.Text = "Clientul a fost gasit!";                  
                }
            }
        }

        private void btnModificare_Click(object sender, EventArgs e)
        {
            

            if(DateValide1())
            {

                Client client_cautat = adminClienti.GetClient(txtCautareNumeClient.Text, txtCautarePrenumeClient.Text);
                if (client_cautat == null)
                {
                    lblMesaj2.Text = "Clientul nu a fost gasit!";
                }
                else
                {
                    int i = 0;
                    while (clienti[i].CNP != client_cautat.CNP)
                    {
                        i++;
                    }
                    if(txNume.Text != string.Empty)
                        clienti[i].Nume = txNume.Text;
                    if(txPrenume.Text != string.Empty)
                        clienti[i].Prenume = txPrenume.Text;
                    if(txCNP.Text != string.Empty)
                        clienti[i].CNP = txCNP.Text;
                    adminClienti.UpdateFisierClienti(clienti);
                    lblMesaj3.Text = "Modificare realizata cu succes!";
                    ResetareMesaje2();
                }
            }
            
        }
       
        bool DateValide()
        {
            lblMesaj.ForeColor = Color.Red;
            if(txtNumeClient.Text == string.Empty)
            {
                lblMesaj.Text = "Completati caseta text nume..";
                return false;
            }
            if(txtPrenumeClient.Text == string.Empty)
            {
                lblMesaj.Text = "Completati caseta text prenume..";
                return false;
            }
            if(txtCNPClient.Text.Length != LUNGIME_CNP)
            {
                lblMesaj.Text = "CNP invalid";
                return false;
            }
            
            lblMesaj.ForeColor = Color.Green;
            return true;
        }

        bool DateValide1()
        {
            lblMesaj2.ForeColor = Color.Red;
            if(txtCautareNumeClient.Text == string.Empty)
            {
                lblMesaj2.Text = "Completati caseta text nume..";
                return false;
            }
            if(txtCautarePrenumeClient.Text == string.Empty)
            {
                lblMesaj2.Text = "Completati caseta text prenume..";
                return false;
            }
            lblMesaj2.ForeColor = Color.Green;
            return true;
        }
        public void ResetareMesaje2()
        {
            txtCautareNumeClient.Text = string.Empty;
            txtCautarePrenumeClient.Text = string.Empty;
        }
        public void ResetareMesaje()
        {
            lblMesaj.Text = string.Empty; 
            lblMesaj2.Text = string.Empty; 
            lblMesaj3.Text = string.Empty;
            txtNumeClient.Text = string.Empty;
            txtPrenumeClient.Text = string.Empty;
            txtCNPClient.Text = string.Empty;
            txNume.Text = string.Empty;
            txPrenume.Text = string.Empty;
            txCNP.Text = string.Empty;

        }

        private void btnStergere_Click(object sender, EventArgs e)
        {

            string index = dgvClienti.CurrentRow.Cells[CNP_].Value.ToString();
            clienti.RemoveAll(m => m.CNP == index);
            adminClienti.UpdateFisierClienti(clienti);
            btnAfisare.PerformClick();
        }
    }
}
