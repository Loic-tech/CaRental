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
    public partial class AnnulerContrat : Form
    {
        OleDbConnection MyConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\yanni\Documents\Données.accdb");
        public AnnulerContrat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            MyConn.Open();
            string requete = "delete from contrats where ID = ?";
            OleDbCommand cmd = new OleDbCommand(requete, MyConn);
            cmd.Parameters.Add(new OleDbParameter ("ID", Convert.ToString(textBox1.Text)));

            try
            {
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MyConn.Close();
                MessageBox.Show("Contrat Supprimé !");
                textBox1.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Contrat contrat = new Contrat();
            contrat.Show();
            this.Hide();
        }
    }
}
