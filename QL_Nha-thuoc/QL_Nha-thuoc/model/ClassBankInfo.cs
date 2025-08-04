using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Nha_thuoc.model
{
    public class ClassBankInfo
    {
        public string Code { get; set; }   // Vd: "VCCB"
        public string ShortName { get; set; }  // Vd: "Bản Việt"

        public override string ToString()
        {
            return $"{Code} - {ShortName}";
        }



    }
}
