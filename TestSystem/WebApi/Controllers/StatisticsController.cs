using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestSystem.WebApi.Controllers
{
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        [HttpGet("statistics/date")]
        public void StatisticsDate()
        {

        }
        [HttpGet("statistics/usage")]
        public void StatisticsUsage()
        {

        }
    }
}
