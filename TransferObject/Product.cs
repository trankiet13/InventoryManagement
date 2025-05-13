using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Product
    {
        public string BARCODE { get; set; }
        public string TENHH { get; set; }
        public string TENTAT { get; set; }
        public string DVT { get; set; }
        public decimal? DONGIA { get; set; }
        public int MANCC { get; set; }
        public int MAXX { get; set; }
        public string IDNHOM { get; set; }
        public string MOTA { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public int? CREATED_BY { get; set; }
        public bool? DISABLED { get; set; }
        public byte[] pImage { get; set; }
        public Product()
        {
        }
    }

    public class GroupProduct
    {
        public string IDNHOM { get; set; }
        public string TENNHOM { get; set; }
    }
}
