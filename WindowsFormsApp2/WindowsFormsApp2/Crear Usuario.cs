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
    public partial class Crear_Usuario : Form
    {
        OleDbConnection connection = new OleDbConnection();
        OleDbCommand command = new OleDbCommand();
        public Crear_Usuario()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\48045008\Documents\GitHub\PROYECTO-FINAL\PROYECTO_FINAL.accdb;Persist Security Info=False;";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText = ("INSERT INTO info (Usuario, Contraseña) VALUES ('" + txtUser.Text + "', '" + txtPassword.Text + "')");

            OleDbDataReader Reader = command.ExecuteReader();
            int count = 0;
            while (Reader.Read())
            {
                count = count + 1;
                count++;
            }
            if (count >= 1)
            {
                MessageBox.Show("Su usuario fue creado correctamente");
                connection.Close();
                connection.Dispose();
                this.Hide();
                Form1 f1 = new Form1();
                f1.ShowDialog();
                
            }
            connection.Close();
        }
    }
}
