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
        public Progreso()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\user\Documents\GitHub\PROYECTO-FINAL\PROYECTO_FINAL.accdb;Persist Security Info=False";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Ingresa un nombre");
            }
            else
            {
                OleDbCommand query = new OleDbCommand("SELECT Puntos, TiempoEnPantalla, Emocion, Fecha FROM InformacionUsuarios, EmocionesUsuarios WHERE Id='"+Form1.ID+ "' AND Id_User='" + Form1.ID+"'", connection);
                string dato = Convert.ToString(query);

                DataTable dt = new DataTable();
                connection.Open();
                OleDbDataAdapter Adapter = new OleDbDataAdapter(query);
                Adapter.Fill(dt);

                dataGridView1.DataSource = dt;
            }
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
    }
}
