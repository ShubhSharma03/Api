using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApicallController : ControllerBase
    {
        private HttpClient _httpClient;

        public ApicallController()
        {
            _httpClient  = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7166");
        }

        [HttpGet]
        public async Task<IActionResult> GetDataFromApiB()
        {
            //try
            //{
                var response = await _httpClient.GetAsync("/api/Issue");
                //response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return Ok(content);
                }
                else
                {
                    return Ok("Unable to get data from API");
                } 
                
            //}
            //catch(Exception ex)
            //{
            //    ex.ToString();
            //    throw;
            //}
        }
    }

}

