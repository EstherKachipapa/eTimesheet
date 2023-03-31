using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        // private object _dbContext;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> GetLoginToken(LoginDto login)
        {
            var result = await _accountService.GetAuthTokens(login);
            if (result == null)
            {
                return ValidationProblem("invalid credentials");
            }
            return Ok(result);
        }
        // GET api/login
        [HttpGet]
        [Route("test-auth")]
        [Authorize]
        public IActionResult GetTest()
        {
            return Ok("Only authenticated user can consume this endpoint");
        }
    }
}