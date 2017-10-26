using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace GestionApp
{
    public partial class Form1 : Form

    {
        private object Me;

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            Form5 frm = new Form5();

            frm.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        // base.Hide();

        // MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;database=gestionc");
        //MySqlDataAdapter da = new MySqlDataAdapter("select * from admins where NomComplet = '" + user.Text + "' and MotDepasse= '" + pass.Text + "' ", connection);
        //DataTable dt = new DataTable();
        // da.Fill(dt);
        // if 

        //(dt.Rows[0][0].ToString() == "1")

        // }
        // else
        //{
        //MessageBox.Show("le mot de passe ou le nom est incorrect", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
       
    

