using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public  class SaleDL
    {
        public class SaleDAL
        {
            public int DeleteMainRecord(int id)
            {
                string qry = "DELETE FROM tblMian WHERE MainID = @id";
                Hashtable ht = new Hashtable
        {
            { "@id", id }
        };
                return DataProvider.SQL(qry, ht);
            }

            public int DeleteDetailsByMainId(int id)
            {
                string qry = "DELETE FROM tblDetails WHERE dMainID = @id";
                Hashtable ht = new Hashtable
        {
            { "@id", id }
        };
                return DataProvider.SQL(qry, ht);
            }
        }

    }
}
