using Movimientos.Common.TypeMapping;
using Movimientos.Data.QueryProcessors;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return cliente;
        }
    }
}