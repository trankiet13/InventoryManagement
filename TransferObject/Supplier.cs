using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Supplier
    {
        public int MANCC { get; set; }
        public string TENNCC { get; set; }
        public string EMAIL { get; set; }
        public string DIENTHOAI { get; set; }
        public string FAX { get; set; }
        public string DIACHI { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public bool DISABLED { get; set; }
        public Supplier()
        {
            
        }
    }
}
