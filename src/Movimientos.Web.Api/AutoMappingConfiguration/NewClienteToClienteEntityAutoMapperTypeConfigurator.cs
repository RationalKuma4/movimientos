using AutoMapper;
using Movimientos.Common.TypeMapping;
using Movimientos.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movimientos.Web.Api.AutoMappingConfiguration
{
    public class NewClienteToClienteEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<NewCliente, Data.Entities.Cliente>()
                .ForMember(o => o.Version, x => x.Ignore())
                .ForMember(o => o.ClienteId, x => x.Ignore());
        }
    }
}