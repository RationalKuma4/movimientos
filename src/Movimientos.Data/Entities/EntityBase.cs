﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movimientos.Data.Entities
{
    public abstract class EntityBase : IVersionedEntity
    {
        public virtual byte[] Version { get; set; }
    }
}
