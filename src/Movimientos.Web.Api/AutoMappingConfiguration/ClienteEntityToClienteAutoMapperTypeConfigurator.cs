using AutoMapper;
using Movimientos.Common.TypeMapping;
using Movimientos.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movimientos.Web.Api.AutoMappingConfiguration
{
    public class ClienteEntityToClienteAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Cliente, Models.Cliente>()
                .ForMember(O => O.Links, X => X.Ignore());
        }
    }
}