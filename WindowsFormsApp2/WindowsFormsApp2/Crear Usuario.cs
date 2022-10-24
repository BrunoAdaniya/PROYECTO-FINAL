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
        OleDbConnection connection;
        public Crear_Usuario()
        {
            InitializeComponent();

        }

        private void Crear_Usuario_Load(object sender, EventArgs e)
        {
            connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\48045008\Documents\GitHub\PROYECTO-FINAL\PROYECTO_FINAL.accdb;Persist Security Info=False";
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Completa los campos");
            }
            else
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO info (Usuario, Contraseña) VALUES ('" + txtUser.Text + "', '" + txtPassword.Text + "')";
                command.ExecuteNonQuery();
                MessageBox.Show("Su usuario fue creado correctamente");
                connection.Close();
            }
        }
    }
}
