using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Product
    {
        public string TENHH { get; set; }
        public string TENTAT { get; set; }
        public string DVT { get; set; }
        public string DONGGIA { get; set; }
        public string MANCC { get; set; }
        public string XUATXU { get; set; }

        public Product(string tENHH, string tENTAT, string dVT)
        {
            TENHH = tENHH;
            TENTAT = tENTAT;
            DVT = dVT;
            
          
        }
    }
}
