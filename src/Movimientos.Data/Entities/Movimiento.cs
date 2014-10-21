using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movimientos.Data.Entities
{
    public class Movimiento : Fianza
    {
        public virtual int MovimientoId { get; set; }
    }
}
