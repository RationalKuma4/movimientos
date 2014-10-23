using Movimientos.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movimientos.Data.SqlServer.Mapping
{
    public class ClienteMap : VersionedClassMap<Cliente>
    {
        public ClienteMap()
        {
            Id(x => x.ClienteId);
            Map(x => x.Nombre).Not.Nullable();
            
        }
    }
}
