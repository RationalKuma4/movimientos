using Movimientos.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movimientos.Web.Api.MaintenanceProccesing
{
    public interface IAddClienteMaintenanceProcessor
    {
        Cliente AddCliente(NewCliente newCliente);
    }
}