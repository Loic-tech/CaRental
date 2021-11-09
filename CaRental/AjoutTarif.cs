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
    public partial class AjoutTarif : Form
    {
        String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\yanni\Documents\Données.accdb";
        OleDbConnection MyConn;
        public AjoutTarif()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyConn = new OleDbConnection();
            MyConn.ConnectionString = connString;
            MyConn.Open();
            string requete = "INSERT INTO DGTarifs (Categorie,locationparjour,locationheure,locationchauffeur) VALUES (?, ?, ?, ?)";
            OleDbCommand cmd = new OleDbCommand(requete, MyConn);


            cmd.Parameters.Add(new OleDbParameter("Categorie", Convert.ToString(comboBox1.SelectedItem)));
            cmd.Parameters.Add(new OleDbParameter("locationparjour", Convert.ToString(textBox1.Text)));
            cmd.Parameters.Add(new OleDbParameter("locationheure", Convert.ToString(textBox2.Text)));
            cmd.Parameters.Add(new OleDbParameter("locationchauffeu", Convert.ToString(textBox3.Text)));



            try
            {
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MyConn.Close();
                MessageBox.Show("Tarification Ajoutée avec Succès !");
                textBox1.Clear();
                textBox3.Clear();
                textBox2.Clear();
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
            textBox3.Clear();
            textBox2.Clear();
            comboBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GestionTarifs gestionTarifs = new GestionTarifs();
            gestionTarifs.Show();
            this.Hide();
        }
    }
}
