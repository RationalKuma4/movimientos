using log4net.Config;
using Movimientos.Common.Logging;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movimientos.Web.Api.App_Start
{
    public class NinjectConfigurator
    {
        public void Configure( IKernel container )
        {
            AddBindings( container );
        }

        private void AddBindings(IKernel container)
        {
            //throw new NotImplementedException();
            ConfigureLog4Net(container);
        }

        private void ConfigureLog4Net(IKernel container)
        {
            XmlConfigurator.Configure();

            var logManager = new LogManagerAdapter();
            container.Bind<ILogManager>().ToConstant(logManager);
        }

        private void ConfigureNHibernate()
        {

        }


    }
}