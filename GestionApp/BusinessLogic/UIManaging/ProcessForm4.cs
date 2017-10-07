using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.BusinessLogic.UIManaging
{
    class ProcessForm4 : InterfaceUI
    {
        //cree conneion au mysql
        MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;database=gestionc");
        MySqlCommand command;

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

        public Boolean emailPassValidation()
        {
            return false;
        }
        public DataTable populateTable()
        {
            return null;
        }
        public Boolean executeRequest(String listOfTextBoxes)
        {
            return false;
        }
        public void insertCompte(String[] list)
        {

        }
        public void updateCompte(String[] list)
        {

        }
        public void deleteCompte(int id)
        {

        }
        public String[] search(int id)
        {
            return null;
        }
    }
}
