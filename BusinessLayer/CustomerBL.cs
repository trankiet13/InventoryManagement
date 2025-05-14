using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static DataLayer.CustomerDL;

namespace BusinessLayer
{
    public  class CustomerBL
    {
        CustomerDAL dal = new CustomerDAL();

        public bool SaveCustomer(int id, string name, string phone, string email)
        {
            Hashtable ht = new Hashtable
            {
                { "@id", id },
                { "@name", name },
                { "@phone", phone },
                { "@Email", email }
            };

            if (id == 0)
                return dal.InsertCustomer(ht) > 0;
            else
                return dal.UpdateCustomer(ht) > 0;
        }

        public bool DeleteCustomer(int id)
        {
            return dal.DeleteCustomer(id) > 0;
        }

        public void LoadCustomers(string searchText, DataGridView dgv, System.Windows.Forms.ListBox lb)
        {
            dal.LoadCustomers(searchText, dgv, lb);
        }
    }
}

