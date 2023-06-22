using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyApiClient : ControllerBase
    
        
    {
        private readonly ApicallController _myService;

        public MyApiClient(ApicallController myService)
        {
            _myService = myService;
        }

        public async Task<string> GetDataFromApiB()
        {
            try
            {
                var data = await _myService.GetDataFromApiB();
                return data;
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                return ex.Message;
            }
        }
    }

}

