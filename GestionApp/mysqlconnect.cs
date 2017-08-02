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
    public partial class mysqlconnect : Form
    {
        internal object connectionstring;
        

        private void mysqlconnect_Load(object sender, EventArgs e)

        {
            bindData();
        }
        public void bindData()
        {
            MySqlConnection connectionstring = new MySqlConnection("server=localhost;user id=root;database=cmpta");

            connectionstring.Open();


            MySqlCommand cmd = new MySqlCommand("select ' from compte", connectionstring);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            
            cmd.Dispose();
            connectionstring.Close();
            
        
            {
               
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
