using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using log4net.Config;
using Movimientos.Common;
using Movimientos.Common.Logging;
using Movimientos.Common.Security;
using Movimientos.Common.TypeMapping;
using Movimientos.Data.QueryProcessors;
using Movimientos.Data.SqlServer.Mapping;
using Movimientos.Data.SqlServer.QueryProcessors;
using Movimientos.Web.Api.AutoMappingConfiguration;
using Movimientos.Web.Api.MaintenanceProccesing;
using Movimientos.Web.Common;
using Movimientos.Web.Common.Security;
using NHibernate;
using NHibernate.Context;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movimientos.Web.Api
{
    public class NinjectConfigurator
    {
        public void Configure(IKernel container)
        {


            AddBindings(container);
        }

        private void AddBindings(IKernel container)
        {
            //throw new NotImplementedException();
            ConfigureLog4Net(container);
            ConfigureUserSession(container);
            ConfigureNHibernate(container);
            ConfigureAutoMapper(container);

            container.Bind<IDateTime>().To<DateTimeAdapter>().InSingletonScope();

            container.Bind<IAddClienteQueryProcessor>().To<AddClienteQueryProcessor>().InRequestScope();

            container.Bind<IAddClienteMaintenanceProcessor>().To<AddClienteMaintenanceProcessor>().InRequestScope();
        }

        private void ConfigureLog4Net(IKernel container)
        {
            XmlConfigurator.Configure();

            var logManager = new LogManagerAdapter();
            container.Bind<ILogManager>().ToConstant(logManager);
        }

        private void ConfigureNHibernate(IKernel container)
        {
            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("movsdb"))).CurrentSessionContext("web")
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ClienteMap>())
                .BuildSessionFactory();

            container.Bind<ISessionFactory>().ToConstant(sessionFactory);
            container.Bind<ISession>().ToMethod(CreateSession);
            container.Bind<IActionTransactionHelper>().To<ActionTransactionHelper>().InRequestScope();
        }

        private void ConfigureUserSession(IKernel container)
        {
            var userSession = new UserSession();
            container.Bind<IUserSession>().ToConstant(userSession).InSingletonScope();
            container.Bind<IWebUserSession>().ToConstant(userSession).InSingletonScope();
        }

        private void ConfigureAutoMapper(IKernel container)
        {
            container.Bind<IAutoMapper>().To<AutoMapperAdapter>().InSingletonScope();

            // Make IAutoMapperTypeConfigurator available for injection
            container.Bind<IAutoMapperTypeConfigurator>()
                .To<ClienteEntityToClienteAutoMapperTypeConfigurator>()
                .InSingletonScope();

            container.Bind<IAutoMapperTypeConfigurator>()
                .To<NewClienteToClienteEntityAutoMapperTypeConfigurator>()
                .InSingletonScope();
        }

        private ISession CreateSession(Ninject.Activation.IContext arg)
        {
            var sessionFactory = arg.Kernel.Get<ISessionFactory>();
            if (!CurrentSessionContext.HasBind(sessionFactory))
            {
                var session = sessionFactory.OpenSession();
                CurrentSessionContext.Bind(session);
            }
            return sessionFactory.GetCurrentSession();
        }


    }
}