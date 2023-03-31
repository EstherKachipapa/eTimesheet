using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public LoginController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET api/logins
        [HttpGet]
        public async Task<ActionResult<List<LoginDto>>> Get()
        {
            return await _dbContext.LoginDtos.ToListAsync();
        }


        // POST api/logins
        [HttpPost]
        public async Task Post(LoginDto model)
        {
            await _dbContext.AddAsync(model);

            await _dbContext.SaveChangesAsync();
        }
    }
}
