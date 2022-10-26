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
    public partial class Progreso : Form
    {
        OleDbConnection connection = new OleDbConnection();
        int ID2;
        int puntos;
        int tiempo;
        public Progreso()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\48045008\Documents\GitHub\PROYECTO-FINAL\PROYECTO_FINAL.accdb;Persist Security Info=False";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string[] EmocionesRecibidas = new string[5];// Este array sirve para guardar la emocion de cada registro
            string[] FechasRecibidas = new string[5];// Este array sirve para guardar la fecha de cada registro

            connection.Open();
            OleDbCommand query = new OleDbCommand("SELECT Id FROM info WHERE Usuario= '"+textBox1.Text+"'", connection);
            string dato = Convert.ToString(query);
            OleDbDataReader Reader = query.ExecuteReader();

            int i = 0;
            while (Reader.Read())
            {
                ID2 = Reader.GetInt32(0);
                i++;
            }
            connection.Close();

            connection.Open();
            OleDbCommand Emocion_Fecha  = new OleDbCommand ("SELECT TOP 5 Emocion, Fecha FROM ConsultaEmociones WHERE Id_user=" + ID2 + " ORDER BY Fecha DESC", connection);
            string datardo = Convert.ToString(Emocion_Fecha);
            OleDbDataReader Reader2 = Emocion_Fecha.ExecuteReader();

            int i2 = 0;
            while (Reader2.Read())
            {
                EmocionesRecibidas[i2] = Reader2.GetString(0);
                FechasRecibidas[i2] = Reader2.GetString(1);

                i2++;
            }
            connection.Close();
            connection.Open();
            OleDbCommand Puntos_Tiempo = new OleDbCommand("SELECT Puntos, TiempoEnPantalla FROM info WHERE Usuario='" + textBox1.Text + "' AND Id=" + ID2 + "",connection);
            string datardo2 = Convert.ToString(Puntos_Tiempo);
            OleDbDataReader Reader3 = Puntos_Tiempo.ExecuteReader();

            int i3 = 0;
            while (Reader3.Read())
            {
                puntos = Reader3.GetInt32(0);
                tiempo = Reader3.GetInt32(1);
                i3++;
            }

            foreach(string s in FechasRecibidas)
                label2.Text = label2.Text + " " + s + "  "; //esto lo que hace es concatenar strings= mecanicamente o que hace es agarrar el label + un espacion dedspues le suma la fecha + suma un espacio y despues hace los mismo con el otro registro (osea la primera vez agarra el primer registro, la segunda el segundo registro y asi suecisvamente hasta llegar al numeror del array)

            label4.Text = label4.Text + " " + tiempo;

            foreach(string s in EmocionesRecibidas)
                label3.Text = label3.Text + " " + s + " ";// aca hace lo mismo que el de arriba

            label1.Text = label1.Text + " " + puntos;

            connection.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            /*connection.Open();
            OleDbCommand query = new OleDbCommand("SELECT Id FROM InformacionUsuarios WHERE User= '" + Form1.User + "'", connection);
            string dato = Convert.ToString(query);
            OleDbDataReader Reader = query.ExecuteReader();

            while (Reader.Read())
            {
               MessageBox.Show("El ID del usuario ingresado es " + Reader.GetInt32(0));
            }

            connection.Close();*/

        }

        private void Progreso_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
