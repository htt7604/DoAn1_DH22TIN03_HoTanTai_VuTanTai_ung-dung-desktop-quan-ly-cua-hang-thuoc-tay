using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Nha_thuoc.model
{
    internal class thongtinHH
    {


        public class Thuoc
        {
            public string Ma { get; set; }
            public string Ten { get; set; }
            public decimal Gia { get; set; }
            public string hinhanhhh { get; set; }
            public decimal SoLuongTon { get; set; } // mới thêm
        }

    }
}
