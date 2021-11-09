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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Recherche recherche = new Recherche();
            recherche.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            GestionGerants gestionGérants = new GestionGerants();
            gestionGérants.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            GestionTarifs gestionTarifs = new GestionTarifs();
            gestionTarifs.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage();
            homepage.Show();
            this.Hide();
        }
    }
}
