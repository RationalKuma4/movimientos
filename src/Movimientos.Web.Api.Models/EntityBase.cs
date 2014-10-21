﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movimientos.Web.Api.Models
{
    public abstract class ObjectBase
    {
        private List<Link> links;

        public List<Link> Links
        {
            get { return links ?? (links = new List<Link>()); }
            set { links = value; }
        }

        public void AddLink(Link link)
        {
            Links.Add(link);
        }

    }
}
