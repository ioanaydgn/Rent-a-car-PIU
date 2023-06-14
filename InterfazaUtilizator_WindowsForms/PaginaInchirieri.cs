using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NivelAccesDate;
using LibrarieModele;

namespace InterfazaUtilizator_WindowsForms
{
    public partial class PaginaInchirieri : UserControl
    {
        private const int LUNGIME_CNP = 13;
        private const int LUNGIME_SERIE = 17;
        private const int ID = 0;


        IStocareInchirieri adminiInchirieri = StocareFactory.GetAdministratorStocareInchirieri();
        IStocareClienti adminiClienti = StocareFactory.GetAdministratorStocareClienti();
        IStocareMasini adminMasini = StocareFactory.GetAdministratorStocareMasini();

        List<Inchiriere> inchirieri = new List<Inchiriere>();
        List<Client> clienti = new List<Client>();
        List<Masina> masini = new List<Masina>();
        public PaginaInchirieri()
        {
            InitializeComponent();
            dtpDataInc.CustomFormat = "dd.MM.yyyy";
            dtpDataTer.CustomFormat = "dd.MM.yyyy";
            inchirieri = adminiInchirieri.GetInchirieri();
            btnStergere.Enabled = false;
        }

        private void btnAdaugare_Click(object sender, EventArgs e)
        {
            if(DateValide())
            {
                string date = ","+txtCNPClient.Text + "," +dtpDataInc.Value.ToShortDateString()+","+dtpDataTer.Value.ToShortDateString()+","+txtSerieMasina.Text.ToUpper();
                Inchiriere inchiriere = new Inchiriere(date);
                inchirieri.Add(inchiriere);
                adminiInchirieri.AddInchiriere(inchiriere);
                lblMesaj.Text = "Adaugare realizata cu succes";
            }
        }

        bool ExistaClient(string cnp)
        {
            clienti = adminiClienti.GetClienti();
            foreach (Client client in clienti)
            {
                if (txtCNPClient.Text == client.CNP)
                    return true;
            }
            return false;
        }

        bool ExistaMasina(string serie)
        {
            masini = adminMasini.GetMasini();
            foreach(Masina masina in masini)
            {
                if (txtSerieMasina.Text.ToUpper() == masina.Serie)
                    return true;
            }
            return false;
        }

        bool DateValide()
        {
            lblMesaj.ForeColor = Color.Red;
            if (txtCNPClient.Text == string.Empty)
            {
                lblMesaj.Text = "Completati caseta text CNP..";
                return false;
            }
            if (!ExistaClient(txtCNPClient.Text))
            {
                lblMesaj.Text = "CNP neinregistrat";
                return false;
            }
            if (txtSerieMasina.Text == string.Empty)
            {
                lblMesaj.Text = "Completati caseta text serie..";
                return false;
            }
            if (!ExistaMasina(txtSerieMasina.Text))
            {
                lblMesaj.Text = "Serie neinregistrata";
                return false;
            }
           
            if(txtCNPClient.Text.Length != LUNGIME_CNP)
            {
                lblMesaj.Text = "Lungime CNP incorect";
                return false;
            }
            if(txtSerieMasina.Text.Length != LUNGIME_SERIE)
            {
                lblMesaj.Text = "Lungime serie incorecta";
                return false;
            }
            if(dtpDataInc.Value >= dtpDataTer.Value) 
            {
                lblMesaj.Text = "Data ter. incorecta";
                return false;
            }
            if(dtpDataInc.Value < DateTime.Now)
            {
                lblMesaj.Text = "Data inc. incorecta";
                return false;
            }
            lblMesaj.ForeColor = Color.Green;
            return true;
                
        }

        private void ResetareControale()
        {
            txtCNPClient.Text = string.Empty;
            txtSerieMasina.Text = string.Empty;
            dtpDataInc.Value = DateTime.Now;
            dtpDataTer.Value = DateTime.Now;
            lblMesaj.Text = string.Empty;
        }
        private void btnAfisare_Click(object sender, EventArgs e)
        {
            ResetareControale();
            btnStergere.Enabled = true;
            dgvInchirieri.DataSource = inchirieri.Select(a => new {  a.ID_inchiriere, a.CNP_client,a.Serie_Masina, a.dataIncepere, a.dataTerminare}).ToList();
           
        }

        private void btnStergere_Click(object sender, EventArgs e)
        {

            int index = int.Parse(dgvInchirieri.CurrentRow.Cells[ID].Value.ToString());
            inchirieri.RemoveAll(m => m.ID_inchiriere == index);
            adminMasini.UpdateFisierMasini(masini);
            btnAfisare.PerformClick();
        }
    }
}
