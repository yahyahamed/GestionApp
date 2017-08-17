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
    public partial class Form5 : Form
    {
        public Form5()
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

            //populate the datagridview
            string selectQuery = "SELECT * FROM compte";


            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection);
            adapter.Fill(table);
            dataGridView_compte.DataSource = table;
           

        }

    

        private void dataGridView_compte_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView_compte.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView_compte.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView_compte.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView_compte.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView_compte.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView_compte.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView_compte.CurrentRow.Cells[6].Value.ToString();
            
        }
        public void openConnection()
        {
            if(connection.State == ConnectionState.Closed)
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
                } else
                {
                    MessageBox.Show("query Not executed");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }finally
            {

                closeConnection();
            }
        }
        // ajouter numero du comptes

        private void button1_Click(object sender, EventArgs e)
        {
            double debiteur;
            double crediteur;
            double debitD;
            double creditD;

            //initialize variables

            debitD = double.Parse(textBox4.Text);
            creditD = double.Parse(textBox5.Text);
            if (debitD > creditD)
            {
                debiteur = debitD - creditD;
                crediteur = 0;
            }
            else if (creditD > debitD)
            {
                debiteur = 0;
                crediteur = creditD - debitD;

            }
            else
            {
                debiteur = 0;
                crediteur = 0;
            }
           
            string insertQuery = "INSERT INTO compte(id, NumeroDuCompte, Libelle, Debit, credit, Debiteur, Crediteur) VALUES('"+textBox1.Text+ "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + debiteur + "','" + crediteur + "')";
            executeMyQuery(insertQuery);
            populateDGV();
        }
       

          // modifier numero du compte
        private void button3_Click(object sender, EventArgs e)
        {
            double debiteur;
            double crediteur;
            double debitD;
            double creditD;

            //initialize variables

            debitD = double.Parse(textBox4.Text);
            creditD = double.Parse(textBox5.Text);
            if (debitD > creditD)
            {
                debiteur = debitD - creditD;
                crediteur = 0;
            }else if (creditD > debitD)
            {
                debiteur = 0;
                crediteur = creditD -debitD;

            }
            else
            {
                debiteur = 0;
                crediteur = 0;
            }
           
            string updateQuery = "UPDATE compte SET id='" + textBox1.Text + "', NumeroDuCompte='" + textBox2.Text + "', Libelle='" + textBox3.Text + "', Debit='" + textBox4.Text + "', credit='" +textBox5.Text + "', Debiteur='" + debiteur + "', Crediteur='" +crediteur + "' WHERE ID="+int.Parse(textBox1.Text);
            executeMyQuery(updateQuery);
            populateDGV();
        }
          
         // supprimer numero du compte
        private void button2_Click(object sender, EventArgs e)
        {
            string deleteQuery = "DELETE FROM compte WHERE id = " + int.Parse(textBox1.Text);
            executeMyQuery(deleteQuery);
            populateDGV();
        }

           // chercher numero du compte
        private void button4_Click(object sender, EventArgs e)
        {
            MySqlDataReader mdr;
            string select = "SELECT * FROM compte WHERE  NumeroDuCompte = " + int.Parse(textBox2.Text) ;
           
            command = new MySqlCommand(select, connection);
            openConnection();
            mdr = command.ExecuteReader();
            if (mdr.Read())
            {
                textBox1.Text = mdr.GetString("id");
                textBox2.Text = mdr.GetString("NumeroDuCompte");
                textBox3.Text = mdr.GetString("Libelle");
                textBox4.Text = mdr.GetString("Debit");
                textBox5.Text = mdr.GetString("credit");
                textBox6.Text = mdr.GetString("Debiteur");
                textBox7.Text = mdr.GetString("Crediteur");
            }
            else
            {
                MessageBox.Show("User Not found");
            }

            closeConnection();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            {
                Form2 frm = new Form2();



                frm.Show();
                // base.Hide();

            }
       
    
            
               
            }
        
    }
}
