﻿using System;
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
    public partial class SupprimerVehicule : Form
    {
        OleDbConnection MyConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\yanni\Documents\Données.accdb");

        public SupprimerVehicule()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyConn.Open();
            OleDbCommand cmd = MyConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM vehicules WHERE Marque = '" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            MyConn.Close();
            MessageBox.Show(" Vehicule Supprimé !");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GestionVéhicules gestionVéhicules = new GestionVéhicules();
            gestionVéhicules.Show();
            this.Hide();
        }
    }
}
