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
    public partial class Form1 : Form
    {
        OleDbConnection connection;
        OleDbCommand command = new OleDbCommand();

        public static String User;
        public static String Password;
        public static DateTime TiempoInicio = DateTime.Now;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\48045008\Documents\GitHub\PROYECTO-FINAL\PROYECTO_FINAL.accdb;Persist Security Info=False;";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Los campos no estan completos, completálos");
            }
            else
            {
                connection.Open(); 
                string query = ("SELECT Usuario, Contraseña FROM info WHERE Usuario='"+txtUser.Text+"' AND Contraseña'"+txtPassword.Text+"'");
                OleDbCommand command = new OleDbCommand(query,  connection);
                OleDbDataAdapter Adapter = new OleDbDataAdapter();
                Adapter.SelectCommand = command;
                OleDbDataReader Reader = command.ExecuteReader();

                User = txtUser.Text;
                Password = txtPassword.Text;

                int i = 0;

                while (Reader.Read())
                {
                    MessageBox.Show("Bienvenido, " + Reader.GetString(0));
                    i++;

                    Emociones emoc = new Emociones();
                    this.Hide();
                    emoc.Show();
                }
                if (i == 0)
                {
                    MessageBox.Show("El usuario o la contraseña son incorrectos, intentelo de nuevo");
                }
                connection.Close();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Crear_Usuario cu = new Crear_Usuario();
            this.Hide();
            cu.Show();
        }
    }
}
