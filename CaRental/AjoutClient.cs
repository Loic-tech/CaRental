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
    public partial class AjoutClient : Form
    {
        String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\yanni\Documents\Données.accdb";
        OleDbConnection MyConn;
        public AjoutClient()
        {
            InitializeComponent();
        }

        private void AjoutClient_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            MyConn = new OleDbConnection();
            MyConn.ConnectionString = connString;
            MyConn.Open();
            string requete = "INSERT INTO Clients (Nom,Prenom,NumeroCIN,NumeroPasseport,Pays,CodeFiscal,RaisonSociale,Categorie) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
            OleDbCommand cmd = new OleDbCommand(requete, MyConn);

            cmd.Parameters.Add(new OleDbParameter("Nom", Convert.ToString(textBox1.Text)));
            cmd.Parameters.Add(new OleDbParameter("Prenom", Convert.ToString(textBox2.Text)));
            cmd.Parameters.Add(new OleDbParameter("NumeroCIN", Convert.ToString(textBox3.Text)));
            cmd.Parameters.Add(new OleDbParameter("NumeroPasseport", Convert.ToString(textBox7.Text)));
            cmd.Parameters.Add(new OleDbParameter("Pays", Convert.ToString(textBox4.Text)));
            cmd.Parameters.Add(new OleDbParameter("CodeFiscal", Convert.ToString(textBox5.Text)));
            cmd.Parameters.Add(new OleDbParameter("RaisonSociale", Convert.ToString(textBox6.Text)));
            cmd.Parameters.Add(new OleDbParameter("Categorie", Convert.ToString(comboBox1.SelectedItem)));



            try
            {
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MyConn.Close();
                MessageBox.Show("Client ajouté!");
                textBox1.Clear();
                comboBox1.Text = "";
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
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
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            client client = new client();
            client.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
