using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT_Security.Services.ResultStructure
{
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}
