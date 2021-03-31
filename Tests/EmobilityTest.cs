using System.Threading.Tasks;

using System.Net.Http;
using Microsoft.Extensions.Logging;
using hello.net;
using System.Linq;
using System.Text.Json;
using Xunit;
using Moq;
using hello.net.Controllers;
using System.Net;
using Moq.Protected;
using System.Threading;
using System.Net.Http.Json;

namespace hello.net.Tests
{
    
    public class EmobilityTest
    {
        [Fact]
        public async Task GetEmobilityData_WhenRequestIsGeneral(){
            
            var mockHttpClientFactory = new Mock<IHttpClientFactory>();
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"data\":[{\"pcode\":\"ASM_00000131\",\"pmetadata\":{\"city\": \"BOLZANO - BOZEN\", \"state\": \"ACTIVE\", \"address\": \"Via Alessandro Volta 17\", \"capacity\": 2, \"provider\": \"Neogy\", \"accessInfo\": \"FREE_PUBLICLY_ACCESSIBLE\", \"accessType\": \"PUBLIC\", \"reservable\": true, \"paymentInfo\": \"https://www.neogy.it/rete-di-ricarica/stazioni-di-ricarica.html\"}}],\"limit\":1}"),
                });
            var client = new HttpClient(mockHttpMessageHandler.Object);
            mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);
            var mocklogger = new Mock<ILogger<EMobilityController>>();
            var controller = new EMobilityController(mocklogger.Object,mockHttpClientFactory.Object);
            var jsonData = await controller.Get();
            Assert.NotNull(@object: jsonData);
        } 
    }
}