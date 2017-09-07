using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.BusinessLogic
{
    interface InterfaceUI
    {
        //This interface is to be used by UI to call business operations
        Boolean emailPassValidation();
        DataTable populateTable();
        Boolean executeRequest(String listOfTextBoxes);
        void insertCompte(String[] list);
        void updateCompte(String[] list);
        void deleteCompte(int id);
        String[] search(int id);
    }
}
