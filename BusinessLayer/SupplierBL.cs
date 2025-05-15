using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;
using DataLayer;
using TransferObject;

namespace BusinessLayer
{
    public class SupplierBL
    {
        private SupplierDL supplierDL;

        public SupplierBL()
        {
            supplierDL = new SupplierDL();
        }

        public List<Supplier> GetAllSuppliers()
        {
            return supplierDL.GetSuppliers();
        }

        public int InsertSupplier(Supplier supplier) 
        {
            try
            {
                return (supplierDL.InsertSupplier(supplier));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int UpdateSupplier(Supplier supplier)
        {
            try
            {
                return supplierDL.UpdateSupplier(supplier);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int DeleteSupplier(int mancc)
        {
            try
            {
                return supplierDL.DeleteSupplier(mancc);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public List<Supplier> SearchSupplier(string keyword)
        {
            return supplierDL.SearchSupplier(keyword);
        }

    }
}
