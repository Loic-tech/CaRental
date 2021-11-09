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
    public partial class Contrat : Form
    {
        String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\yanni\Documents\Données.accdb";
        OleDbConnection MyConn;
        public Contrat()
        {
            InitializeComponent();
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            ModifierContrat modifierContrat = new ModifierContrat();
            modifierContrat.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ModifierContrat modifierContrat = new ModifierContrat();
            modifierContrat.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AjoutContrat ajoutContrat = new AjoutContrat();
            ajoutContrat.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            AnnulerContrat annulerContrat = new AnnulerContrat();
            annulerContrat.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Gerant gerant = new Gerant();
            gerant.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                MyConn = new OleDbConnection();
                MyConn.ConnectionString = connString;
                MyConn.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = MyConn;
                string query = "SELECT * FROM contrats";
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
