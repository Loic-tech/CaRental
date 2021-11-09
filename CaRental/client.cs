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
    public partial class client : Form
    {
        String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\yanni\Documents\Données.accdb";
        OleDbConnection MyConn;
        public client()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AjoutClient ajoutClient = new AjoutClient();
            ajoutClient.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        

        private void button2_Click_1(object sender, EventArgs e)
        {
            SupprimerClient supprimerClient = new SupprimerClient();
            supprimerClient.Show();
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
                string query = "SELECT * FROM Clients";
                command.CommandText = query;


                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                MyConn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erreur : " + ex);
            }
        }
    }
}
