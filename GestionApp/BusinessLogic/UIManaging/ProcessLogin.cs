using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.BusinessLogic
{
    class ProcessLogin : InterfaceUI
    {
        //cree conneion au mysql
        MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;database=cmpta");
        MySqlCommand command;
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

        public void deleteCompte(int id)
        {
            string deleteQuery = "DELETE FROM compte WHERE id = " + id;
            executeRequest(deleteQuery);
        }

        public bool emailPassValidation()
        {
            throw new NotImplementedException();
        }

        public void insertCompte(String[] list)
        {
            double debiteur;
            double crediteur;
            double debitD;
            double creditD;

            //initialize variables

            debitD = double.Parse(list[3]);
            creditD = double.Parse(list[4]);
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
            string insertQuery = "INSERT INTO compte(id, NumeroDuCompte, Libelle, Debit, credit, Debiteur, Crediteur) VALUES('"+ list[0] + "','" + list[1] + "','" + list[2] + "','" + list[3] + "','" + list[4] + "','" + debiteur + "','" + crediteur + "')";
            executeRequest(insertQuery);
            
        }

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
        public Boolean executeRequest(String listOfTextBoxes)
        {
            Boolean result = false;
            try
            {
                openConnexion();
                command = new MySqlCommand(listOfTextBoxes, connection);
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                //closeConnexion();
            }
            result = command.ExecuteNonQuery() == 1;
            return result;
        }
        public DataTable populateTable()
        {
            // populate the datagridview
            string selectQuery = "SELECT * FROM compte";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection);
            adapter.Fill(table);
            return table;
        }

        public void updateCompte(String[] list)
        {
            double debiteur;
            double crediteur;
            double debitD;
            double creditD;

            //initialize variables

            debitD = double.Parse(list[3]);
            creditD = double.Parse(list[4]);
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
            string updateQuery = "UPDATE compte SET id='" + list[0] + "', NumeroDuCompte='" + list[1] + "', Libelle='" + list[2] + "', Debit='" + list[3] + "', credit='" + list[4] + "', Debiteur='" + debiteur + "', Crediteur='" + crediteur + "' WHERE ID=" + int.Parse(list[0]);
            executeRequest(updateQuery);
        }
        public String[] search(int numCompte)
        {
            String[] list = new String[7];
            MySqlDataReader mdr;
            string select = "SELECT * FROM compte WHERE  NumeroDuCompte = " + numCompte;

            command = new MySqlCommand(select, connection);
            openConnexion();
            mdr = command.ExecuteReader();
            if (mdr.Read())
            {
                list[0] = mdr.GetString("id");
                list[1] = mdr.GetString("NumeroDuCompte");
                list[2] = mdr.GetString("Libelle");
                list[3] = mdr.GetString("Debit");
                list[4] = mdr.GetString("credit");
                list[5] = mdr.GetString("Debiteur");
                list[6] = mdr.GetString("Crediteur");
            }
            else
            {
                list = null;
            }
            closeConnexion();
            return list;
        }
    }
}
