using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgCrmCore.Response
{
    public class DbResponse<T>
    {
        public int ReturnCode { get; set; }
        public string ReturnDescription { get; set; }
        public T ReturnData { get; set; }
    }
}
