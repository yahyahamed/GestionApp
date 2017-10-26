using System;
using System.Data;
using System.Windows.Forms;
using GestionApp.BusinessLogic;
namespace GestionApp
{
    public partial class Form5 : Form
    {
        InterfaceUI uiInterface = new ProcessForm5();
        DataTable table;

        public Form5()
        {
            InitializeComponent();
        }

        /***************************************************************/
        private void Form5_Load(object sender, EventArgs e)
        {
            table = uiInterface.populateTable();
            dataGridView_compte.DataSource = table;
           
        }

        /***************************************************************/
        public void populateDGV()
        {
            table = uiInterface.populateTable();
            dataGridView_compte.DataSource = table;
        }

        /***************************************************************/
        private void dataGridView_compte_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView_compte.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView_compte.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView_compte.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dataGridView_compte.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView_compte.CurrentRow.Cells[6].Value.ToString();
            textBox6.Text = dataGridView_compte.CurrentRow.Cells[7].Value.ToString();
            textBox7.Text = dataGridView_compte.CurrentRow.Cells[8].Value.ToString();
            
        }

        /***************************************************************/
        public void executeMyQuery(string query)
        {
            try
            {
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

        /***************************************************************/
        private void button1_Click(object sender, EventArgs e)
        {
            //inserer
            String[] list= new String[] { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text };
            uiInterface.insertCompte(list);
            populateDGV();
        }

        /***************************************************************/
        // modifier numero du compte
        private void button3_Click(object sender, EventArgs e)
        {
            String[] list = new String[7];

            list[0] = textBox1.Text;
            list[1] = textBox2.Text;
            list[2] = textBox3.Text;
            list[3] = textBox4.Text;
            list[4] = textBox5.Text;
            uiInterface.updateCompte(list);
            populateDGV();
        }

        /***************************************************************/
        // supprimer numero du compte
        private void button2_Click(object sender, EventArgs e)
        {
            //string deleteQuery = "DELETE FROM compte WHERE id = " + int.Parse(textBox1.Text);
            //executeMyQuery(deleteQuery);
            uiInterface.deleteCompte(int.Parse(textBox1.Text));
            populateDGV();
        }

        /***************************************************************/
        // chercher numero du compte
        private void button4_Click(object sender, EventArgs e)
        {
            
            String[] list;
            list = uiInterface.search(int.Parse(textBox2.Text));
            if (list!=null)
            {
                textBox1.Text = list[0];
                textBox2.Text = list[1];
                textBox3.Text = list[2];
                textBox4.Text = list[3];
                textBox5.Text = list[4];
                textBox6.Text = list[5];
                textBox7.Text = list[6];
            }
            else
            {
                MessageBox.Show("User Not found");
            }
            
        }

        /***************************************************************/
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            {
                Form2 frm = new Form2();
                frm.Show();
            }
        }

        /***************************************************************/
        private void button5_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
        }
    }
}
