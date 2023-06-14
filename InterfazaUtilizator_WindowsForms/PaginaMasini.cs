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
    public partial class PaginaMasini : UserControl
    {
        private const int LUNGIME_SERIE = 17;

        OptiuniMasina optiuniSelectate = new OptiuniMasina();
        IStocareMasini adminMasini = StocareFactory.GetAdministratorStocareMasini();
        List<Masina> masini;

        public PaginaMasini()
        {
            InitializeComponent();
            masini = adminMasini.GetMasini();
            btnStergere.Enabled = false;
        }

        private void btnAdaugare_Click(object sender, EventArgs e)
        {
            ModelMasina? modelSelectat = GetModelSelectat();
            //set optiuni
            
            if(DateValide())
            {
                
                string infoMasina = txtSerieMasina.Text.ToUpper() + "," + (int)modelSelectat +  "," + txtPretMasina.Text + "," + (int)optiuniSelectate;
                masini.Add(new Masina(infoMasina));
                adminMasini.AddMasina(new Masina(infoMasina));
                lblMesaj.Text = "Adaugare realizata\ncu succes!";
            }
        }

        private ModelMasina? GetModelSelectat()
        {
            if (rdbOpel.Checked)
                return ModelMasina.Opel;
            if (rdbRenault.Checked)
                return ModelMasina.Renault;
            if (rdbBMW.Checked)
                return ModelMasina.BMW;
            if (rdbAudi.Checked)
                return ModelMasina.Audi;
            if (rdbDacia.Checked)
                return ModelMasina.Dacia;
            if (rdbFord.Checked)
                return ModelMasina.Ford;
            if (rdbVolkswagen.Checked)
                return ModelMasina.Volkswagen;
            if (rdbMercedes.Checked)
                return ModelMasina.Mercedes;
            if (rdbTesla.Checked)
                return ModelMasina.Tesla;

            return null;
        }

        private void ckbDiscipline_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBoxControl = sender as CheckBox; //operator 'as'
                                                           //sau
                                                           //CheckBox checkBoxControl = (CheckBox)sender; //operator cast

            int optiuneSelectata = (int)Enum.Parse(typeof(OptiuniMasina), checkBoxControl.Text);
            //verificare daca checkbox-ul asupra caruia s-a actionat este selectat
            if (checkBoxControl.Checked == true)
                optiuniSelectate = (OptiuniMasina)((int)optiuniSelectate + optiuneSelectata);
            else
                optiuniSelectate = (OptiuniMasina)((int)optiuniSelectate - optiuneSelectata);
        }
        private void btnAfisare_Click(object sender, EventArgs e)
        {
            ResetareMesaje();
            btnStergere.Enabled = true;
            lsbAfisareMasini.Items.Clear();
            string antetTabel = String.Format("{0,-20}{1,-13}{2,5}  {3,-30}\n", "Serie sasiu", "Model", "Pret", "Facilitati");
            lsbAfisareMasini.Items.Add(antetTabel);

            foreach (Masina _masina in masini)
            {
                lsbAfisareMasini.Items.Add(_masina.ConversieLaSir());
            }
        }


        private void btnCautare_Click(object sender, EventArgs e)
        {
            
            Masina masina_cautata;
            if(DateValide1())
            {
                ResetareMesaje();
                masina_cautata = adminMasini.GetMasina( txtCautareSerieMasina.Text.ToUpper());
                if (masina_cautata == null)
                {
                    lblMesaj2.Text = "Masina nu a fost gasita!";
                }
                else
                {
                    lsbAfisareMasini.Items.Clear();              
                    string antetTabel = String.Format("{0,-20}{1,-13}{2,5}  {3,-30}\n", "Serie sasiu", "Model", "Pret", "Facilitati");
                    lsbAfisareMasini.Items.Add(antetTabel);
                    lsbAfisareMasini.Items.Add(masina_cautata.ConversieLaSir());
                    lblMesaj2.Text = "Masina a fost gasita!";
                }
            }
        }

        private void btnModificare_Click(object sender, EventArgs e)
        {
            
            Masina masina_cautata;
            if(DateValide1())
            {
                masina_cautata = adminMasini.GetMasina(txtCautareSerieMasina.Text.ToUpper());
                if (masina_cautata == null)
                {
                    lblMesaj2.Text = "Masina nu a fost gasita!";
                }
                else
                {
                    int i = 0;
                    while (masini[i].Serie != masina_cautata.Serie)
                    {
                        i++;
                    }
                    ModelMasina? modelSelectat = GetModelSelectat();
                    masini[i].Model = (ModelMasina)modelSelectat;
                    if (txtSerieMasina.Text.ToUpper() != string.Empty)
                        masini[i].Serie = txtSerieMasina.Text.ToUpper();
                    if (txtPretMasina.Text != string.Empty)
                        masini[i].Pret = Convert.ToInt32(txtPretMasina.Text);
                    masini[i].Optiuni = optiuniSelectate;
                    adminMasini.UpdateFisierMasini(masini);
                    ResetareMesaje();
                    lblMesaj2.Text = "Modificare realizata cu succes!";
                }
            }
        }
        
        bool DateValide()
        {
            lblMesaj.ForeColor = Color.Red;
            if(txtSerieMasina.Text == string.Empty)
            {
                lblMesaj.Text = "Completati casuta \ntext serie..";
                return false;
            }
            if(txtPretMasina.Text == string.Empty)
            {
                lblMesaj.Text = "Completati casuta \ntext pret..";
                return false;
            }
            else if (!int.TryParse(txtPretMasina.Text, out _))
            {
                lblMesaj.Text = "Pret incorect";
                return false;
            }
            lblMesaj.ForeColor = Color.Green;
            return true;

        }

        bool DateValide1()
        {
            lblMesaj2.ForeColor = Color.Red;
            if(txtCautareSerieMasina.Text == string.Empty)
            {
                lblMesaj2.Text = "Completati casuta text serie..";
                return false;
            }
            else if(txtCautareSerieMasina.Text.Length != LUNGIME_SERIE)
            {
                lblMesaj2.Text = "Serie invalida!";
                return false;
            }
            lblMesaj2.ForeColor = Color.Green;
            return true;
        }
        public void ResetareMesaje()
        {
            lblMesaj.Text = string.Empty;
            lblMesaj2.Text  = string.Empty;
            txtSerieMasina.Text = string.Empty;
            txtPretMasina.Text = string.Empty;
            ckbAerConditionat.Checked = false;
            ckbCutieAutomata.Checked = false;
            ckbDecapotabila.Checked = false;
            ckbGeamuriElectrice.Checked = false;
            ckbNavigatie.Checked = false;
            ckbNiciuna.Checked = true;
        }

        private void btnStergere_Click(object sender, EventArgs e)
        {
          
                string sir = lsbAfisareMasini.SelectedItem.ToString();
                string[] date = sir.Split(' ');
                masini.RemoveAll(m => m.Serie == date[0]); //functie anonima ce returneaza masina pentru care seria = date[0]
                adminMasini.UpdateFisierMasini(masini);
                btnAfisare.PerformClick();
            
        }
    }
}
