using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT_Security.Services.ResultStructure
{
    public class Result : IResult
    {

        public Result(bool process,string message):this(process)
        {
            Message = message;
        }

        public Result(bool process)
        {
            Process = process;
        }

        public bool Process { get; }

        public string Message { get; }
    }
}
