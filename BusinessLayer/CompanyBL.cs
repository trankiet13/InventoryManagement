using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using TransferObject;

namespace BusinessLayer
{
    public class CompanyBL
    {
        private CompanyDL companyDL = new CompanyDL();

        public bool SaveBranch(BranchTO branch)
        {
            // Kiểm tra mã đơn vị đã tồn tại
            if (companyDL.IsBranchIDExists(branch.MADVI))
            {
                branch.MADVI = companyDL.GetNextBranchID(); // Tạo lại mã mới nếu bị trùng
            }

            return companyDL.InsertBranch(branch) > 0;
        }
        public bool IsBranchIDExists(string madvi)
        {
            return companyDL.IsBranchIDExists(madvi);
        }
        public string GetNextBranchID()
        {
            CompanyDL companyDL = new CompanyDL();
            return companyDL.GetNextBranchID();
        }
        // Phương thức lưu công ty và đơn vị
        public bool SaveCompany(CompanyTO company, List<BranchTO> branches)
        {
            if (companyDL.IsCompanyIDExists(company.MACTY))
            {
                company.MACTY = companyDL.GetNextCompanyID(); // Tạo lại mã mới nếu bị trùng
            }

            // Lưu công ty
            int result = companyDL.InsertCompany(company);
            if (result <= 0) return false;

            // Lưu các đơn vị (branches)
            foreach (var branch in branches)
            {
                if (IsBranchIDExists(branch.MADVI)) // Kiểm tra trùng mã đơn vị
                {
                    branch.MADVI = GetNextBranchID();
                }
                branch.MACTY = company.MACTY;
                companyDL.InsertBranch(branch);
            }

            return true;
        }



        public List<BranchTO> GetBranches(string macty)
        {
            var dt = companyDL.GetBranchesByCompany(macty);
            var branches = new List<BranchTO>();
            foreach (DataRow row in dt.Rows)
            {
                branches.Add(new BranchTO
                {
                    MADVI = row["MADVI"].ToString(),
                    TENDVI = row["TENDVI"].ToString(),
                    DIENTHOAI = row["DIENTHOAI"].ToString(),
                    FAX = row["FAX"].ToString(),
                    EMAIL = row["EMAIL"].ToString(),
                    DIACHI = row["DIACHI"].ToString(),
                    MACTY = row["MACTY"].ToString(),
                    DISABLED = Convert.ToBoolean(row["DISABLED"])
                });
            }
            return branches;
        }
    }
}
