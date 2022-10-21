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
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\48045008\Documents\GitHub\PROYECTO-FINAL\PROYECTO_FINAL.accdb;Persist Security Info=False;";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            connection.Open();
            command = new OleDbCommand("UPDATE emociones SET emocion='" + A + "' WHERE '"+Form1.User+"'",connection);
            command = new OleDbCommand("UPDATE emociones SET fecha='" + dt.ToShortDateString() + "' WHERE  '"+Form1.Password+"'",connection);
            command.ExecuteNonQuery();
            connection.Close();


        }

        private void Emociones_Load(object sender, EventArgs e)
        {

        }
    }
}
