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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public static int ID;

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
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\48045008\Documents\GitHub\PROYECTO-FINAL\PROYECTO_FINAL.accdb;Persist Security Info=False";
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
                OleDbCommand query = new OleDbCommand("SELECT User, Password, Id FROM InformacionUsuarios WHERE User= '" + txtUser.Text + "' AND Password= '" + txtPassword.Text + "'", connection);
                string dato = Convert.ToString(query);

                OleDbDataReader Reader = query.ExecuteReader();

                int i = 0;

                while (Reader.Read())
                {
                    MessageBox.Show("Bienvenido, " + Reader.GetString(0));
                    ID = Reader.GetInt32(2);
                    i++;

                    Emociones emoc = new Emociones();
                    this.Hide();
                    emoc.Show();

                    User = txtUser.Text;
                    Password = txtPassword.Text;
                }
                connection.Close();

                /*connection.Open();
                OleDbCommand query2 = new OleDbCommand("SELECT Id FROM InformacionUsuarios WHERE User= '" + Form1.User + "'", connection);
                string dato2 = Convert.ToString(query2);
                OleDbDataReader Reader2 = query2.ExecuteReader();

                if (Reader2.Read())
                {
                    ID = Reader2.GetInt32(0);

                    Emociones emoc = new Emociones();
                    this.Hide();
                    emoc.Show();
                }

                connection.Close();
                */

                if (i == 0)
                {
                    MessageBox.Show("El usuario o la contraseña son incorrectos, intentelo de nuevo");
                }

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
