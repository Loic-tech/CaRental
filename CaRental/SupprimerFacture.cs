using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CaRental
{
    public partial class SupprimerFacture : Form
    {

        OleDbConnection MyConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\yanni\Documents\Données.accdb");
        public SupprimerFacture()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyConn.Open();
            string requete = "delete from Facturation where NumeroFac = ?";
            OleDbCommand cmd = new OleDbCommand(requete, MyConn);
            cmd.Parameters.Add(new OleDbParameter("NumeroFac", Convert.ToString(textBox1.Text)));
            try
            {
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MyConn.Close();
                MessageBox.Show("Facture Supprimée !");
                textBox1.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Facture facture = new Facture();
            facture.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
