
using System.Net.Http;
using System.Linq;
using System.Text.Json;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace hello.net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EMobilityController : ControllerBase
    {

        private readonly ILogger<EMobilityController> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public EMobilityController(ILogger<EMobilityController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            ActionResult action = BadRequest();
            var data = await FetchData();
            if (data.IsSuccessStatusCode){
                using var responseStream = await data.Content.ReadAsStreamAsync();
                try{
                var odhResponse = await JsonSerializer.DeserializeAsync<ODHResponse>(responseStream); 
                if (odhResponse.data.Count > 0){
                    action = Ok(odhResponse.data.First());
                }else
                    action = Conflict();
                }catch(Exception ex){
                    ex.GetBaseException();
                }
            }
            return action;
        }
        private async Task<HttpResponseMessage> FetchData(){
            var request = new HttpRequestMessage(HttpMethod.Get,"https://mobility.api.opendatahub.com/v2/flat/EChargingPlug/echarging-plug-status/latest?where=pcoordinate.bbc.(11.3279685,46.4789455,11.3340417,46.4801228),mvalue.eq.1,sactive.eq.true&select=pmetadata,pcode,pcoordinate&limit=1");
            request.Headers.Add("ContentType","application/json");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            return response;
        }
    }
}
