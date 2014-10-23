using Movimientos.Common;
using Movimientos.Common.TypeMapping;
using Movimientos.Data.QueryProcessors;
using Movimientos.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Movimientos.Web.Api.MaintenanceProccesing
{
    public class AddClienteMaintenanceProcessor : IAddClienteMaintenanceProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IAddClienteQueryProcessor _qProcessor;

        public AddClienteMaintenanceProcessor(IAddClienteQueryProcessor queryProcessor, IAutoMapper autoMapper)
        {
            _autoMapper = autoMapper;
            _qProcessor = queryProcessor;
        }

        public Models.Cliente AddCliente(Models.NewCliente newCliente)
        {
            var clienteEntity = _autoMapper.Map<Data.Entities.Cliente>(newCliente);
            _qProcessor.AddCliente(clienteEntity);
            var cliente = _autoMapper.Map<Models.Cliente>(clienteEntity);

            cliente.AddLink(new Link {
                Method = HttpMethod.Get.Method,
                Href = "http://localhost:22522/api/v1/clientes/"+ cliente.ClienteId,
                Rel = Constants.CommonLinkRelValues.Self
            });

            return cliente;
        }
    }
}