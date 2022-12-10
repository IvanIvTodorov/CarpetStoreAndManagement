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
        }
    }
}
