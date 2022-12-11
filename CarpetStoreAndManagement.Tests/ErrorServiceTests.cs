using CarpetStoreAndManagement.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.Tests
{
    public class ErrorServiceTests
    {
        [Fact]
        public async void TestErrorMessage()
        {
            var service = new ErrorService();

            int statusCode = 404;
            var result = service.GetError(statusCode);

            Assert.Equal(result, "Not Found");

            int statusCode2 = 401;
            var result2 = service.GetError(statusCode2);

            Assert.Equal(result2, "Unauthorized");

            int statusCode3 = 403;
            var result3 = service.GetError(statusCode3);

            Assert.Equal(result3, "Forbidden");

            int statusCode4 = 500;
            var result4 = service.GetError(statusCode4);

            Assert.Equal(result4, "Internal Server Error");

            int statusCode5 = 502;
            var result5 = service.GetError(statusCode5);

            Assert.Equal(result5, "Bad Gateway");

            int statusCode6 = 502;
            var result6 = service.GetError(statusCode6);

            Assert.Equal(result6, "Bad Gateway");

            int statusCode7 = 503;
            var result7 = service.GetError(statusCode7);

            Assert.Equal(result7, "Service Unavailable");

        }
    }
}
