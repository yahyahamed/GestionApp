using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.BusinessLogic
{
    interface InterfaceUI
    {
        //This interface is to be used by UI to call business operations
        Boolean emailPassValidation();
        void populateDGV();
        void openConnexion();
        void closeConnexion();
        void insertCompte();
        void updateCompte();
        void deleteCompte();
    }
}
