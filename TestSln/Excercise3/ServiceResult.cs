using System;

namespace Exercise3
{
    public class ServiceResult<T> 
    {
        public String Message { get; set; }
        public bool IsSucceed { get; set; }
        public T Data { get; set; }
    }
}
