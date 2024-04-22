using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestSystem.Core.Entities;
using TestSystem.Infrastructure.Data;
using TestSystem.WebApi.Models;

namespace TestSystem.WebApi.Controllers
{
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly TestSystemDbContext _testSystemDbContext;

        public TokenController(TestSystemDbContext testSystemDbContext)
        {
            _testSystemDbContext = testSystemDbContext;
        }
        [HttpGet("token/get")]
        public async Task<TokenModel?> Get()
        {
            var token = await _testSystemDbContext.Tokens.LastOrDefaultAsync();
            if (token != null)
            {

            }

        }
        [HttpPost("token/edit")]
        public async Task Edit()
        {
            var token = await _testSystemDbContext.Tokens.LastOrDefaultAsync();
            if (token == null)
            {

            }

        }
    }
}
