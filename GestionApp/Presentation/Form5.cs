using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionApp
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            MySql.Data.MySqlClient.MySqlConnection db;
            mysqlconnect conn = new mysqlconnect();
            string connectionString;

            connectionString = "server=localhost;uid=root;" + "pwd=bobs1992;database=world;port=3360";

            try
            {
                db = new MySql.Data.MySqlClient.MySqlConnection();
                db.ConnectionString = connectionString;
                db.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            dataGridView1.DataSource = dt;
            




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
