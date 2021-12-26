using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Results
{
    public class DataResult<T>
    {
        public bool IsSuccess { get; set; }
        public T Body { get; set; }

        public static DataResult<T> Ok(T body)
        {
            return new DataResult<T> { Body = body, IsSuccess = true };
        }

        public static DataResult<T> Error(T body)
        {
            return new DataResult<T> { Body = body, IsSuccess = false };
        }
    }
}
