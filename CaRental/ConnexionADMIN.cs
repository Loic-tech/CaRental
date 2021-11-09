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
    public partial class ConnexionADMIN : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public ConnexionADMIN()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\yanni\Documents\Données.accdb";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM admins WHERE user = '" + textBox1.Text + "' and password= '" + textBox2.Text + "' ";


            OleDbDataReader reader = command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count++;
            }

            if (count == 1)
            {
                MessageBox.Show("Accès Autorisé ! Appuyez sur OK.");
                Admin admin = new Admin();
                admin.Show();
            }
            else
            {
                MessageBox.Show("coordonnées incorrectes.");
                ConnexionADMIN connexionADMIN = new ConnexionADMIN();
                connexionADMIN.Show();
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
