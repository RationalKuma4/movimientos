using Movimientos.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movimientos.Data.QueryProcessors
{
    public interface IAddClienteQueryProcessor
    {
        void AddCliente(Cliente cliente);
    }
}
