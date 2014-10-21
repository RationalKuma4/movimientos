using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movimientos.Data.Entities
{
    public class Cliente : EntityBase
    {
        public virtual int ClienteId { get; set; }
        public virtual string Nombre { get; set; }
        

    }
}
