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
        [Route("", Name = "GetClientesV1")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "version1", "value2" };
        }

        [Route("", Name = "AddClienteV1")]
        [HttpPost]
        public Cliente AddCliente(HttpRequestMessage requestMessage, Models.Cliente cliente)
        {
            return new Cliente { Nombre = "V1" };
        }

    }
}