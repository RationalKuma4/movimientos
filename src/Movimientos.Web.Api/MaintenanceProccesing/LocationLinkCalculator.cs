﻿using Movimientos.Common;
using Movimientos.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movimientos.Web.Api.MaintenanceProccesing
{
    public static class LocationLinkCalculator
    {
        public static Uri GetLocationLink(ILinkContaining linkContaining)
        {
            var locationLink = linkContaining.Links.FirstOrDefault(x => x.Rel == Constants.CommonLinkRelValues.Self);
            return locationLink == null ? null : new Uri(locationLink.Href);
        }
    }
}