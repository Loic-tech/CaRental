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
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            ConnexionADMIN connexionADMIN = new ConnexionADMIN();
            connexionADMIN.Show();
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            ConnexionGERANT connexionGERANT = new ConnexionGERANT();
            connexionGERANT.Show();
            Visible = false;

        }
    }
}
