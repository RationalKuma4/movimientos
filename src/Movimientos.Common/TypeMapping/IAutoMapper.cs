using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movimientos.Common.TypeMapping
{
    public interface IAutoMapper
    {
        T Map<T>(object toMap);
    }
}
