using Movimientos.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Movimientos.Web.Api.MaintenanceProccesing
{
    public class ClienteCreatedActionResult : IHttpActionResult
    {
        private readonly Cliente _createdCliente;
        private readonly HttpRequestMessage _requestMessage;

        public ClienteCreatedActionResult(HttpRequestMessage requestMessage,
            Cliente createdCliente)
        {
            _requestMessage = requestMessage;
            _createdCliente = createdCliente;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return System.Threading.Tasks.Task.FromResult(Execute());
        }

        public HttpResponseMessage Execute()
        {
            var acceptHeader = _requestMessage.Headers.Accept.FirstOrDefault();
            var mediaType = acceptHeader == null ? null : acceptHeader.MediaType;

            var responseMessage = string.IsNullOrWhiteSpace(mediaType)
                ? _requestMessage.CreateResponse(HttpStatusCode.Created, _createdCliente)
                : _requestMessage.CreateResponse(HttpStatusCode.Created, _createdCliente, mediaType);

            responseMessage.Headers.Location = LocationLinkCalculator.GetLocationLink(_createdCliente);

            return responseMessage;
        }
    }
}