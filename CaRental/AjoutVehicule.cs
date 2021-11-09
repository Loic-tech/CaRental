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
    public partial class AjoutVehicule : Form
    {
        String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\yanni\Documents\Données.accdb";
        OleDbConnection MyConn;
        public AjoutVehicule()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyConn = new OleDbConnection();
            MyConn.ConnectionString = connString;
            MyConn.Open();
            string requete = "INSERT INTO vehicules (Marque,Categorie,Etat,Nbr_Hrs,Caracteristiques,Nbr_Km) VALUES (?, ?, ?, ?, ?, ?)";
            OleDbCommand cmd = new OleDbCommand(requete, MyConn);

            cmd.Parameters.Add(new OleDbParameter("Marque", Convert.ToString(textBox1.Text)));
            cmd.Parameters.Add(new OleDbParameter("Categorie", Convert.ToString(comboBox1.SelectedItem)));
            cmd.Parameters.Add(new OleDbParameter("Etat", Convert.ToString(comboBox2.SelectedItem)));
            cmd.Parameters.Add(new OleDbParameter("Nbr_Hrs", Convert.ToString(textBox4.Text)));
            cmd.Parameters.Add(new OleDbParameter("Caracteristiques", Convert.ToString(textBox5.Text)));
            cmd.Parameters.Add(new OleDbParameter("Nbr_Km", Convert.ToString(textBox6.Text)));

            try
            {
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MyConn.Close();
                MessageBox.Show("Véhicule Ajouté avec Succès");
                textBox1.Clear();
                comboBox1.Text = "";
                comboBox2.Text = "";
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
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
            comboBox2.Text = "";
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GestionVéhicules gestionVéhicules = new GestionVéhicules();
            gestionVéhicules.Show();
            this.Hide();
        }
    }
}
