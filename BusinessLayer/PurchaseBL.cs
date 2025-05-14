using DataLayer;
using System;
using System.Data;

namespace BusinessLayer
{
    public class PurchaseBL
    {
        private readonly PurchaseDL purchaseDL = new PurchaseDL();

        public DataTable LoadPurchases(string searchText)
        {
            return purchaseDL.GetPurchases(searchText);
        }

        public bool DeletePurchase(int mainID)
        {
            return purchaseDL.DeletePurchase(mainID) > 0;
        }
        // Lấy danh sách nhà cung cấp
        public DataTable GetSuppliers()
        {
            return purchaseDL.GetSuppliers();
        }

        // Lấy sản phẩm theo NCC
        public DataTable GetProductsBySupplier(int supplierID)
        {
            return purchaseDL.GetProductsBySupplier(supplierID);
        }

        // Lấy thông tin chi tiết sản phẩm
        public DataTable GetProductDetails(int productID)
        {
            return purchaseDL.GetProductDetails(productID);
        }

        // Lưu đơn mua hàng
        public int SavePurchase(int mainID, DateTime date, int supplierID, DataTable dtDetails)
        {
            return purchaseDL.SavePurchase(mainID, date, supplierID, dtDetails);
        }
    }
}