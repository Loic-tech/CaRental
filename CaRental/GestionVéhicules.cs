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
    public partial class GestionVéhicules : Form
    {
        public GestionVéhicules()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AjoutVehicule ajoutVehicule = new AjoutVehicule();
            ajoutVehicule.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SupprimerVehicule supprimerVehicule = new SupprimerVehicule();
            supprimerVehicule.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();
        }
    }
}
