using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    public class ServiceResult<T> 
    {
        public String Message { get; set; }
        public bool IsSucceed { get; set; }
        public T Data { get; set; }
    }
}
