using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestSystem.Application.Services;
using TestSystem.Infrastructure.Data;
using TestSystem.WebApi.Models;

namespace TestSystem.WebApi.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TestSystemDbContext _testSystemDbContext;
        private readonly UserService _userService;

        public UserController(TestSystemDbContext testSystemDbContext)
        {
            _testSystemDbContext = testSystemDbContext;
            _userService = new UserService(_testSystemDbContext);
        }

        [HttpPost("/signin")]
        public async Task<string> SignIn(SignInModel signInModel)
        {
            if (!ModelState.IsValid)
            {
                throw new InvalidOperationException("Input value is not correct.");
            }
            string token = await _userService.SignInUser(signInModel.Email, signInModel.Password);
            Console.WriteLine(token);
            return token;
        }
        [HttpPost("/signup")]
        public async Task<string> SignUp(SignUpModel signUpModel)
        {
            if (!ModelState.IsValid)
            {
                throw new InvalidOperationException("Count value is not correct.");
            }
            string token = await _userService.SignUpUser(signUpModel.Email, signUpModel.Password, signUpModel.PhoneNumber);
            return token;
        }
    }
}
