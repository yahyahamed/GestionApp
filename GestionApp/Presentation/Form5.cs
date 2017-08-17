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
using GestionApp.BusinessLogic;
namespace GestionApp
{
    public partial class Form5 : Form
    {
        InterfaceUI uiInterface = new ProcessLogin();
        public Form5()
        {
            InitializeComponent();
        }

        //cree conneion au mysql
        //MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;database=cmpta");
        //MySqlCommand command;

        private void Form5_Load(object sender, EventArgs e)
        {
            DataTable table = uiInterface.populateDGV();
            dataGridView_compte.DataSource = table;
        }
        /*public void populateDGV()
        {

            //populate the datagridview
            string selectQuery = "SELECT * FROM compte";


            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection);
            adapter.Fill(table);
            dataGridView_compte.DataSource = table;
        }*/

    

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
        public void executeMyQuery(string query)
        {
            try
            {
                
                //openConnection();
                //command = new MySqlCommand(query, connection);
                if (uiInterface.executeRequest(query))
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
            }
        }
        // ajouter numero du comptes

        private void button1_Click(object sender, EventArgs e)
        {
            String[] list= new String[] { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text };
            //string insertQuery = "INSERT INTO compte(id, NumeroDuCompte, Libelle, Debit, credit, Debiteur, Crediteur) VALUES('"+textBox1.Text+ "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
            //executeMyQuery(insertQuery);
            //String list= "";
            uiInterface.insertCompte(list);
            uiInterface.populateDGV();
        }
       

          // modifier numero du compte
        private void button3_Click(object sender, EventArgs e)
        {
            //string updateQuery = "UPDATE compte SET id='" + textBox1.Text + "', NumeroDuCompte='" + textBox2.Text + "', Libelle='" + textBox3.Text + "', Debit='" + textBox4.Text + "', credit='" + textBox5.Text + "', Debiteur='" + textBox6.Text + "', Crediteur='" + textBox7.Text + "' WHERE ID="+int.Parse(textBox1.Text);
            //executeMyQuery(updateQuery);
            String[] list = new String[7];

            list[0] = textBox1.Text;
            list[1] = textBox2.Text;
            list[2] = textBox3.Text;
            list[3] = textBox4.Text;
            list[4] = textBox5.Text;
            uiInterface.updateCompte(list);
            uiInterface.populateDGV();
        }
          
         // supprimer numero du compte
        private void button2_Click(object sender, EventArgs e)
        {
            //string deleteQuery = "DELETE FROM compte WHERE id = " + int.Parse(textBox1.Text);
            //executeMyQuery(deleteQuery);
            uiInterface.deleteCompte(int.Parse(textBox1.Text));
            uiInterface.populateDGV();
        }

           // chercher numero du compte
        private void button4_Click(object sender, EventArgs e)
        {
            //MySqlDataReader mdr;
            //string select = "SELECT * FROM compte WHERE  NumeroDuCompte = " + int.Parse(textBox2.Text) ;
           
            //command = new MySqlCommand(select, connection);
            //openConnection();
            //mdr = command.ExecuteReader();
            String[] list;
            list = uiInterface.search(int.Parse(textBox2.Text));
            if (list!=null)//mdr.Read())
            {
                textBox1.Text = list[0];// mdr.GetString("id");
                textBox2.Text = list[1];// mdr.GetString("NumeroDuCompte");
                textBox3.Text = list[2];// mdr.GetString("Libelle");
                textBox4.Text = list[3];// mdr.GetString("Debit");
                textBox5.Text = list[4];// mdr.GetString("credit");
                textBox6.Text = list[5];// mdr.GetString("Debiteur");
                textBox7.Text = list[6];// mdr.GetString("Crediteur");
            }
            else
            {
                MessageBox.Show("User Not found");
            }

            //closeConnection();
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
