using Movimientos.Web.Api.MaintenanceProccesing;
using Movimientos.Web.Api.Models;
using Movimientos.Web.Common;
using Movimientos.Web.Common.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Movimientos.Web.Api.Controllers.V1
{
    [ApiVersion1RoutePrefix("clientes")]
    [UnitOfWorkActionFilter]
    public class ClientesController : ApiController
    {
        private readonly IAddClienteMaintenanceProcessor _addClienteMP;

        public ClientesController(IAddClienteMaintenanceProcessor addClienteMaintenanceProcessor)
        {
            _addClienteMP = addClienteMaintenanceProcessor;
        }

        [Route("", Name = "AddClienteV1")]
        [HttpPost]
        public Cliente AddCliente(HttpRequestMessage requestMessage, Models.NewCliente newCliente)
        {
            return _addClienteMP.AddCliente(newCliente);
        }

    }
}