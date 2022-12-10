using CarpetStoreAndManagement.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.Services.Services
{
    public class ErrorService : IErrorService
    { 
        public string GetError(int statusCode)
        {
            var result = String.Empty;

            if (statusCode == 401)
            {
                result = "Unauthorized";
            }
            else if (statusCode == 403)
            {
                result = "Forbidden";
            }
            else if (statusCode == 404)
            {
                result = "Not Found";
            }
            else if (statusCode == 500)
            {
                result = "Internal Server Error";
            }
            else if (statusCode == 502)
            {
                result = "Bad Gateway";
            }
            else if (statusCode == 503)
            {
                result = "Service Unavailable";
            }
            else if (statusCode == 503)
            {
                result = "Gateway Timeout";
            }

            return result;
        }
    }
}
