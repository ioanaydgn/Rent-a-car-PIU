using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazaUtilizator_WindowsForms
{
    public partial class Form1 : Form
    {
        static Form1 _obj;

        public static Form1 Instance
        {
            get 
            {
                if(_obj == null)
                {
                    _obj = new Form1();
                }
                return _obj;
            }
        }

        public Panel PnlContainer
        {
            get { return pnlContinut; }
            set { pnlContinut = value; }
        }

        public Button ButonAcasa
        {
            get { return btnAcasa; }
            set { btnAcasa = value; }
        }
        //Pentru a putea muta fereastra
        bool butonApasat;
        int movX;
        int movY;
        private const int DECALAJ = 70;

        public Form1()
        {
            InitializeComponent();
        }


        private void pictureBox2_Click(object sender, EventArgs e) // Buton iesire program
        {
            this.Close();
        }
        #region PermitereMutareFereastra
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            butonApasat = true;
            movX = e.X + DECALAJ;
            movY = e.Y;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if(butonApasat)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            butonApasat = false;
        }

        #endregion

        

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToLongDateString();
            btnAcasa.Enabled = false;
            _obj = this;

            PaginaAcasa pa = new PaginaAcasa();
            pa.Dock = DockStyle.Fill;
            pnlContinut.Controls.Add(pa);
        }

        private void btnAcasa_Click(object sender, EventArgs e)
        {
            pnlContinut.Controls["PaginaAcasa"].BringToFront();
            btnAcasa.Enabled = false;
            btnClienti.Enabled = true;
            btnAngajati.Enabled = true;
            btnInchirieri.Enabled = true;
            btnMasini.Enabled = true;
            
        }

        private void btnClienti_Click(object sender, EventArgs e)
        {
            if (!Form1.Instance.PnlContainer.Controls.ContainsKey("PaginaClienti"))
            {
                PaginaClienti pc = new PaginaClienti();
                pc.Dock = DockStyle.Fill;
                Form1.Instance.PnlContainer.Controls.Add(pc);
            }
            Form1.Instance.PnlContainer.Controls["PaginaClienti"].BringToFront();
            Form1.Instance.ButonAcasa.Enabled = true;
            Form1.Instance.btnClienti.Enabled = false;
            Form1.Instance.btnAngajati.Enabled = true;
            Form1.Instance.btnInchirieri.Enabled = true;
            Form1.Instance.btnMasini.Enabled = true;
        }

        private void btnAngajati_Click(object sender, EventArgs e)
        {
            if(!Form1.Instance.PnlContainer.Controls.ContainsKey("PaginaAngajati"))
            {
                PaginaAngajati pa = new PaginaAngajati();
                pa.Dock = DockStyle.Fill;
                Form1.Instance.PnlContainer.Controls.Add(pa);
            }
            Form1.Instance.PnlContainer.Controls["PaginaAngajati"].BringToFront();
            Form1.Instance.ButonAcasa.Enabled = true;
            Form1.Instance.btnAngajati.Enabled = false;
            Form1.Instance.btnClienti.Enabled = true;
            Form1.Instance.btnMasini.Enabled = true;
            Form1.Instance.btnInchirieri.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void btnMasini_Click(object sender, EventArgs e)
        {
            if (!Form1.Instance.PnlContainer.Controls.ContainsKey("PaginaMasini"))
            {
                PaginaMasini pm = new PaginaMasini();
                pm.Dock = DockStyle.Fill;
                Form1.Instance.PnlContainer.Controls.Add(pm);
            }
            Form1.Instance.PnlContainer.Controls["PaginaMasini"].BringToFront();
            Form1.Instance.ButonAcasa.Enabled = true;
            Form1.Instance.btnClienti.Enabled = true;
            Form1.Instance.btnAngajati.Enabled = true;
            Form1.Instance.btnInchirieri.Enabled = true;
            Form1.Instance.btnMasini.Enabled = false;
        }

        private void btnInchirieri_Click(object sender, EventArgs e)
        {
            if (!Form1.Instance.PnlContainer.Controls.ContainsKey("PaginaInchirieri"))
            {
                PaginaInchirieri pi = new PaginaInchirieri();
                pi.Dock = DockStyle.Fill;
                Form1.Instance.PnlContainer.Controls.Add(pi);
            }
            Form1.Instance.PnlContainer.Controls["PaginaInchirieri"].BringToFront();
            Form1.Instance.ButonAcasa.Enabled = true;
            Form1.Instance.btnClienti.Enabled = true;
            Form1.Instance.btnAngajati.Enabled = true;
            Form1.Instance.btnMasini.Enabled = true;
            Form1.Instance.btnInchirieri.Enabled = false;
        }
    }
}
