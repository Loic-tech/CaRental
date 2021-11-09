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
    public partial class AjoutGerant : Form
    {
        String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\yanni\Documents\Données.accdb";
        OleDbConnection MyConn;
        public AjoutGerant()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyConn = new OleDbConnection();
            MyConn.ConnectionString = connString;
            MyConn.Open();
            string requete = "insert into Gerants (identifiant,mot_de_passe) values (?, ?)";
            OleDbCommand cmd = new OleDbCommand(requete, MyConn);

            cmd.Parameters.Add(new OleDbParameter("identifiant", Convert.ToString(textBox1.Text)));
            cmd.Parameters.Add(new OleDbParameter("mot_de_passe", Convert.ToString(textBox2.Text)));


            try
            {
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MyConn.Close();
                MessageBox.Show("Gérant ajouté!");
                textBox1.Clear();
                textBox2.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GestionGerants gestionGerants = new GestionGerants();
            gestionGerants.Show();
            this.Hide();
        }
    }
}
