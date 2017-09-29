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

namespace GestionApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;database=gestion");
        MySqlCommand command;

        private void Form5_Load(object sender, EventArgs e)
        {
            populateDGV();
        }
        public void populateDGV()
        {

            // populate the datagridview
            string selectQuery = "SELECT * FROM compte";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection);
            adapter.Fill(table);
            dataGridView_compte.DataSource = table;
        }

        private void dataGridView_compte_MouseClick(object sender, MouseEventArgs e)
        {

        }
        public void openConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void closeConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public void executeMyQuery(string query)
        {
            try
            {
                openConnection();
                command = new MySqlCommand(query, connection);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("query executed");
                }
                else
                {
                    MessageBox.Show("query Not executed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeConnection();
            }
        }
        // ajouter numero du compte
        private void button1_Click(object sender, EventArgs e)
        {

        }

        // modifier numero du compte
        private void button3_Click(object sender, EventArgs e)
        {

        }

        // supprimer numero du compte
        private void button2_Click(object sender, EventArgs e)
        {

        }

        // chercher numero du compte
        private void button4_Click(object sender, EventArgs e)
        {

        }


        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            {
                Form5 frm = new Form5();



                frm.Show();
                // base.Hide();

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}