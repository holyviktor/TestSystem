using Microsoft.AspNetCore.Mvc;
using TestSystem.Infrastructure.Data;
using TestSystem.WebApi.Models;

namespace TestSystem.WebApi.Controllers
{
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpPost("test/create")]
        public void Create(Test test)
        {
            
        }
    }
}