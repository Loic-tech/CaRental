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
    public partial class SupprimerTarif : Form
    {
        OleDbConnection MyConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\yanni\Documents\Données.accdb");
        public SupprimerTarif()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyConn.Open();
            OleDbCommand cmd = MyConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM DGTarifs WHERE Categorie = '" + comboBox1.SelectedItem+ "'";
            cmd.ExecuteNonQuery();
            MyConn.Close();
            MessageBox.Show(" Tarif Supprimé !");
            comboBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
