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
    }
}
