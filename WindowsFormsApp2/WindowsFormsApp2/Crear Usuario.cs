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
            else if(comboBox1.SelectedItem.ToString() == "Profesor/Padre")
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO info (Usuario, Contraseña, Rol) VALUES ('" + txtUser.Text + "', '" + txtPassword.Text + "', '"+ "Admin" + "')";
                command.ExecuteNonQuery();
                MessageBox.Show("Su usuario fue creado correctamente, ahora, ahora inicia sesion");
                connection.Close();

                Form1 f1 = new Form1();
                this.Hide();
                f1.Show();
            }
            else if (comboBox1.SelectedItem.ToString() == "Estudiante")
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO info (Usuario, Contraseña, Rol) VALUES ('" + txtUser.Text + "', '" + txtPassword.Text + "', '" + "Estudiante" + "')";
                command.ExecuteNonQuery();
                MessageBox.Show("Su usuario fue creado correctamente, ahora inicia sesion");
                connection.Close();

                Form1 f1 = new Form1();
                this.Hide();
                f1.Show();
            }
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
