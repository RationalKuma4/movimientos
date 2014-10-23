using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using log4net.Config;
using Movimientos.Common.Logging;
using Movimientos.Data.SqlServer.Mapping;
using NHibernate;
using NHibernate.Context;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movimientos.Web.Api.App_Start
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
            ConfigureNHibernate(container);
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