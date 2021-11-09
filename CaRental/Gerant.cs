using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaRental
{
    public partial class Gerant : Form
    {
        public Gerant()
        {
            InitializeComponent();
        }

        private void Gerant_Load(object sender, EventArgs e)
        {

        }

            private void button1_Click(object sender, EventArgs e)
            {
                Contrat contrat = new Contrat();
                contrat.Show();
                this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            client client = new client();
            client.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            Facture facture = new Facture();
            facture.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConnexionGERANT connexionGERANT = new ConnexionGERANT();
            connexionGERANT.Show();
            this.Hide();
        }
    }
}
   
