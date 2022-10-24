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

namespace WindowsFormsApp2
{
    public partial class Emociones : Form
    {
        OleDbConnection connection = new OleDbConnection();
        OleDbCommand command = new OleDbCommand();
        string A = "Alegre";
        string T = "Triste";
        string E = "Enojado";
        public Emociones()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\48045008\Documents\GitHub\PROYECTO-FINAL\PROYECTO_FINAL.accdb;Persist Security Info=False";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command = new OleDbCommand("INSERT INTO EmocionesUsuarios (Emocion, Fecha, id_User) VALUES ('" + A + "', '" + dt.ToShortDateString() + "', "+Form1.ID+")", connection);
            command.ExecuteNonQuery();
            connection.Close();

            Menu MN = new Menu();
            this.Hide();
            MN.Show();
        }

        private void Emociones_Load(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command = new OleDbCommand("INSERT INTO EmocionesUsuarios (Emocion, Fecha, id_User) VALUES ('" + T + "', '" + dt.ToShortDateString() + "', " + Form1.ID + ")", connection);
            command.ExecuteNonQuery();
            connection.Close();

            Menu MN = new Menu();
            this.Hide();
            MN.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command = new OleDbCommand("INSERT INTO EmocionesUsuarios (Emocion, Fecha, id_User) VALUES ('" + E + "', '" + dt.ToShortDateString() + "', " + Form1.ID + ")", connection);
            command.ExecuteNonQuery();
            connection.Close();

            Menu MN = new Menu();
            this.Hide();
            MN.Show();
        }
    }
}
