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
    public partial class ConnexionGERANT : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public ConnexionGERANT()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\yanni\Documents\Données.accdb";
        }


        private void ConnexionGERANT_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

           

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Gerants WHERE identifiant = '" + textBox1.Text + "' and mot_de_passe = '" + textBox2.Text + "' ";


            OleDbDataReader reader = command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count++;
            }

            if (count == 1)
            {
                MessageBox.Show("Accès Autorisé ! Appuyez sur OK.");
                Gerant gerant = new Gerant();
                gerant.Show();
            }
            else
            {
                MessageBox.Show("coordonnées incorrectes");
                ConnexionGERANT connexionGERANT = new ConnexionGERANT();
                connexionGERANT.Show();
                this.Hide();
            }
                



            connection.Close();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage();
            homepage.Show();
            this.Hide();
        }
    }
}
