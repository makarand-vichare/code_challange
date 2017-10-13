using System;

namespace Exercise2
{
    public class ServiceResult
    {
        public String Message { get; set; }
        public bool IsSucceed { get; set; }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T Data { get; set; }
    }
}
