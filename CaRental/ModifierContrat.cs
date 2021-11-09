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
    public partial class ModifierContrat : Form
    {
        String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\yanni\Documents\Données.accdb";
        OleDbConnection MyConn;

        public ModifierContrat()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyConn = new OleDbConnection();
            MyConn.ConnectionString = connString;
            MyConn.Open();
            string requete = "UPDATE contrats SET Regle = ? WHERE Numero_contrat = ?";
            OleDbCommand cmd = new OleDbCommand(requete, MyConn);

            cmd.Parameters.Add(new OleDbParameter("Regle", Convert.ToString(comboBox1.SelectedItem)));
            cmd.Parameters.Add(new OleDbParameter("Numero_contrat", Convert.ToString(textBox1.Text)));

            try
            {
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MyConn.Close();
                MessageBox.Show("Contrat Modifié !");
                textBox1.Clear();
                comboBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            comboBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Contrat contrat = new Contrat();
            contrat.Show();
            this.Hide();
        }
    }
}
