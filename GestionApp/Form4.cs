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
using GestionApp.BusinessLogic.UIManaging;
using GestionApp.BusinessLogic;

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

        /***************************************************************/
        private bool openConnexion()
        {
            Boolean result;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            result = connection.State == ConnectionState.Open;
            return result;
        }

        /***************************************************************/
        private Boolean closeConnexion()
        {
            Boolean result;
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            result = connection.State == ConnectionState.Closed;
            return result;
        }

        /***************************************************************/
        private void populateDGV()
        {
            openConnexion();
            string selectQuery = "select e.id,e.NumeroDuCompte,e.Libelle,e.Debit,e.credit,e.Debiteur,e.crediteur from souscompte e inner join compte m ON m.id=e.id where m.id=" + comboBox1.SelectedItem;
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            closeConnexion();
        }

        /***************************************************************/
        private void label9_Click(object sender, EventArgs e)
        {

        }

        /***************************************************************/
        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                MessageBox.Show("selectionner un numero du compte");
            else
            {
                populateDGV();
            }
        }//*********afficher*********//

        /***************************************************************/
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

        /***************************************************************/
        private void dataGridView1_MouseClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

        }

        /***************************************************************/
        private void label10_Click(object sender, EventArgs e)
        {

        }

        /***************************************************************/
        public void executeMyQuery(string query)
        {
            try
            {
                openConnexion();
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
                closeConnexion();
            }
        }

        /***************************************************************/
        private void button1_Click(object sender, EventArgs e)
        {
            //insert
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

            string insertQuery = "INSERT INTO souscompte(id, NumeroDuCompte, Libelle, Debit, credit, Debiteur, Crediteur) VALUES('"+ comboBox1.SelectedItem + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + debiteur + "','" + crediteur + "')";
            executeMyQuery(insertQuery);
            populateDGV();
        }//*********insert******//

        /***************************************************************/
        private void button2_Click(object sender, EventArgs e)
        {
            string deleteQuery = "DELETE FROM souscompte WHERE NumeroDuCompte = " + int.Parse(textBox2.Text);
            executeMyQuery(deleteQuery);
            populateDGV();
        }//*********delete*****//

        /***************************************************************/
        private void button3_Click(object sender, EventArgs e)
        {
            //update
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
            string updateQuery = "UPDATE souscompte SET NumeroDuCompte='" + textBox2.Text + "', Libelle='" + textBox3.Text + "', Debit='" + textBox4.Text + "', credit='" + textBox5.Text + "', Debiteur='" + debiteur + "', Crediteur='" + crediteur + "' WHERE NumeroDuCompte=" + int.Parse(textBox2.Text);
            executeMyQuery(updateQuery);
            populateDGV();
        }//********update*******//

        /***************************************************************/
        private void button4_Click(object sender, EventArgs e)
        {
            //search
            MySqlDataReader mdr;
            string select = "SELECT * FROM souscompte WHERE  NumeroDuCompte = " + int.Parse(textBox2.Text) ;

            command = new MySqlCommand(select, connection);
            openConnexion();
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

            closeConnexion();
        }//*********search*******//
    }
}
