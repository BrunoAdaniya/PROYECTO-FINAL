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
    public partial class Iniciar_Sesionn : Form
    {
        OleDbConnection connection = new OleDbConnection();
        string Rol2;
        public Iniciar_Sesionn()
        {
            InitializeComponent();
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
                OleDbCommand query = new OleDbCommand("SELECT Usuario, Contraseña, Id, Rol FROM info WHERE Usuario= '" + txtUser.Text + "' AND Contraseña= '" + txtPassword.Text + "'", connection);
                string dato = Convert.ToString(query);

                OleDbDataReader Reader = query.ExecuteReader();

                int i = 0;

                
                while (Reader.Read())
                {
                    Rol2 = Reader.GetString(3);
                    i++; 
                    if(Rol2 == "Estudiante")
                    {
                        MessageBox.Show("Este usuario no tiene el permiso para ingresar");
                    }
                    else if (Rol2 == "Admin")
                    {
                        MessageBox.Show("Has ingresado correctamente");
                        Progreso prg = new Progreso();
                        this.Hide();
                        prg.Show(); 
                    }
                }
                connection.Close();
            }
        }
    }
}
