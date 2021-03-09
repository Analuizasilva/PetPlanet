using System;

namespace Business.OperationResult
{
    public class OperationResult<T>
    {
        public bool Success { get; set; }
        public Exception Exception { get; set; }
        public T Result { get; set; }
    }
}
