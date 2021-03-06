﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movimientos.Web.Api.Models
{
    public class Fianza : ObjectBase
    {
        public virtual int FianzaId { get; set; }
        public virtual int EndosoId { get; set; }
        public virtual int FiadoId { get; set; }
        public virtual int BeneficiarioId { get; set; }
        public virtual string Estatus { get; set; }
        public virtual decimal Total { get; set; }

    }
}
