using Movimientos.Common.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movimientos.Web.Common.Security
{
    public interface IWebUserSession : IUserSession
    {
        string ApiVersion { get; }
        Uri RequestUri { get; }
        string HttpRequestMethod { get; }
    }
}
