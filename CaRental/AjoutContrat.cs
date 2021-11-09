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
    public partial class AjoutContrat : Form
    {
        String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\yanni\Documents\Données.accdb";
        OleDbConnection MyConn;
        public AjoutContrat()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyConn = new OleDbConnection();
            MyConn.ConnectionString = connString;
            MyConn.Open();
            string requete = "INSERT INTO contrats (Information_client,Tarification,Vehicule_pris,Avance,Date_Location,Valeur_Compteur_Depart,Date_Retour,Valeur_Compteur_Retour,Chauffeur) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
            OleDbCommand cmd = new OleDbCommand(requete, MyConn);

            cmd.Parameters.Add(new OleDbParameter("Information_client", Convert.ToString(textBox7.Text)));
            cmd.Parameters.Add(new OleDbParameter("Tarification", Convert.ToString(textBox12.Text)));
            cmd.Parameters.Add(new OleDbParameter("Vehicule_pris", Convert.ToString(textBox11.Text)));
            cmd.Parameters.Add(new OleDbParameter("Avance", Convert.ToString(textBox10.Text)));
            cmd.Parameters.Add(new OleDbParameter("Date_Location", string.Format("{0:d/M/yyyy}", dateTimePicker3.Value)));
            cmd.Parameters.Add(new OleDbParameter("Valeur_Compteur_Depart", Convert.ToString(textBox9.Text)));
            cmd.Parameters.Add(new OleDbParameter("Date_Retour", string.Format("{0:d/M/yyyy}", dateTimePicker4.Value)));
            cmd.Parameters.Add(new OleDbParameter("Valeur_Compteur_Retour", Convert.ToString(textBox8.Text)));
            cmd.Parameters.Add(new OleDbParameter("Chauffeur", Convert.ToString(comboBox2.SelectedItem)));


            try
            {
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MyConn.Close();
                MessageBox.Show("Contrat Ajouté !");
                textBox7.Clear();
                textBox12.Clear();
                textBox11.Clear();
                textBox10.Clear();
                textBox9.Clear();
                textBox8.Clear();
                comboBox2.Text = "";
                dateTimePicker3.Value = DateTime.Now;
                dateTimePicker4.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox7.Clear();
            textBox12.Clear();
            textBox11.Clear();
            textBox10.Clear();
            textBox9.Clear();
            textBox8.Clear();
            comboBox2.Text = "";
            dateTimePicker3.Value = DateTime.Now;
            dateTimePicker4.Value = DateTime.Now;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Contrat contrat = new Contrat();
            contrat.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
