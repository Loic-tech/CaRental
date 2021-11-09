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
    public partial class Facture : Form
    {
        String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\yanni\Documents\Données.accdb";
        OleDbConnection MyConn;
        public Facture()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AjoutFacture ajouterFacture = new AjoutFacture();
            ajouterFacture.Show();
            this.Hide();
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            SupprimerFacture supprimerFacture = new SupprimerFacture();
            supprimerFacture.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Gerant gerant = new Gerant();
            gerant.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                MyConn = new OleDbConnection();
                MyConn.ConnectionString = connString;
                MyConn.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = MyConn;
                string query = "SELECT * FROM Facturation";
                command.CommandText = query;


                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                MyConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex);
            }
        }
    }
}
