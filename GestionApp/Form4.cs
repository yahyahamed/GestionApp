using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace GestionApp
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;database=gestionc");
        MySqlCommand command;



        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
           // dataGridView1.Rows.Clear();
            if (comboBox1.SelectedIndex == -1)
                MessageBox.Show("selectionner un numero du compte");
            else
            {
                
                connection.Open();
                MySqlCommand command = new MySqlCommand("select e.id,e.NumeroDuCompte,e.Libelle,e.Debit,e.credit,e.Debiteur,e.crediteur from souscompte e inner join compte m ON m.id=e.id where m.id='" + comboBox1.SelectedItem + "'", connection);
                MySqlDataReader dr = command.ExecuteReader();
                dataGridView1.Columns.Add("id", "id");
                dataGridView1.Columns.Add("numCompte","Numero du compte");
                dataGridView1.Columns.Add("libel", "Libelle");
                dataGridView1.Columns.Add("debite", "Debit");
                dataGridView1.Columns.Add("credit", "Credit");
                dataGridView1.Columns.Add("debiteur", "Debiteur");
                dataGridView1.Columns.Add("crediteur", "Crediteur");

                while (dr.Read())

                {

                    dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);
                  
                }

               
                    
                dr.Close();
                connection.Close();
                
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("select Id from compte ", connection);
            MySqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            dr.Close();
           

           
            
            connection.Close();
           

        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form5 frm = new Form5();



            frm.Show();
            this.Hide();
        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            int A = 0, B = 0;
            for (A = 0; A < dataGridView1.Rows.Count; ++A)
            {
                B += Convert.ToInt32(dataGridView1.Rows[A].Cells[3].Value);

            }
            label14.Text = B.ToString();
            int c = 0, d = 0;
            for (c = 0; c < dataGridView1.Rows.Count; ++c)
            {
                d += Convert.ToInt32(dataGridView1.Rows[c].Cells[4].Value);

            }
            label15.Text = d.ToString();


            int i = 0, f = 0;
            for (i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                f += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);

            }
            label16.Text = f.ToString();

            int g = 0, h = 0;
            for (g = 0; g < dataGridView1.Rows.Count; ++g)
            {
                h += Convert.ToInt32(dataGridView1.Rows[g].Cells[6].Value);

            }
            label17.Text = h.ToString();
        }
    }
}
