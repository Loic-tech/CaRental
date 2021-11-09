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
    public partial class AjoutFacture : Form
    {
        String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\yanni\Documents\Données.accdb";
        OleDbConnection MyConn;
        public AjoutFacture()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyConn = new OleDbConnection();
            MyConn.ConnectionString = connString;
            MyConn.Open();
            string requete = "INSERT INTO Facturation (NumContrat,NumeroVehicule,Categorie,Nb_KM_parcourus,Tarif_KM_Parcourus,Tarif_Journalier,TarifsChauffeurCamion,TarifsVoiture,MontantTotal,MontantTVA,Montant_Net,MontantHorsTaxe,DateFacturation) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
            OleDbCommand cmd = new OleDbCommand(requete, MyConn);

            cmd.Parameters.Add(new OleDbParameter("NumContrat", Convert.ToString(textBox1.Text)));
            cmd.Parameters.Add(new OleDbParameter("NumeroVehicule", Convert.ToString(textBox2.Text)));
            cmd.Parameters.Add(new OleDbParameter("Categorie", Convert.ToString(textBox3.Text)));
            cmd.Parameters.Add(new OleDbParameter("Nb_KM_parcourus", Convert.ToString(textBox4.Text)));
            cmd.Parameters.Add(new OleDbParameter("MontantTotal", Convert.ToString(textBox5.Text)));
            cmd.Parameters.Add(new OleDbParameter("Tarif_KM_Parcourus", Convert.ToString(textBox6.Text)));
            cmd.Parameters.Add(new OleDbParameter("Tarif_Journalier", Convert.ToString(textBox7.Text)));
            cmd.Parameters.Add(new OleDbParameter("TarifsChauffeurCamion", Convert.ToString(textBox8.Text)));
            cmd.Parameters.Add(new OleDbParameter("TarifsVoiture", Convert.ToString(textBox9.Text)));
            cmd.Parameters.Add(new OleDbParameter("MontantHorsTaxe", Convert.ToString(textBox10.Text)));
            cmd.Parameters.Add(new OleDbParameter("MontantTVA", Convert.ToString(textBox11.Text)));
            cmd.Parameters.Add(new OleDbParameter("Montant_Net", Convert.ToString(textBox12.Text)));
            cmd.Parameters.Add(new OleDbParameter("DateFacturation", string.Format("{0:d/M/yyyy}", dateTimePicker1.Value)));


            try
            {
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MyConn.Close();
                MessageBox.Show("Facture Ajoutée avec Succès !");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox11.Clear();
                textBox12.Clear();
                dateTimePicker1.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Facture facture = new Facture();
            facture.Show();
            this.Hide();
        }
    }
}
