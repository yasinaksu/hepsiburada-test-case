using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Results
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public static Result Ok()
        {
            return new Result { IsSuccess = true };
        }

        public static Result Error()
        {
            return new Result { IsSuccess = false };
        }
    }
}
