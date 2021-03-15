using AuthenticateAndRequest.Models;
using Microsoft.Extensions.Options;
using System;

namespace AuthenticateAndRequest.Services.Payload
{
    public class Json : IPayload
    {
        private readonly IAuthentication authentication;
        private readonly RequestProperties requestProperties;

        public Json(IAuthentication authentication, IOptions<RequestProperties> requestProperties)
        {
            this.authentication = authentication;
            this.requestProperties = requestProperties.Value;
        }

        public void SendRequest()
        {
            var token = authentication.GetToken();
            var type = requestProperties.RequestType;
            throw new NotImplementedException();
        }
    }
}
