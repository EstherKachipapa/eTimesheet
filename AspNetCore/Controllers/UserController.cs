using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public UserController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET api/users
        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return await _dbContext.Users.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        // POST api/users
        [HttpPost]
        public async Task Post(User model)
        {
            await _dbContext.AddAsync(model);

            await _dbContext.SaveChangesAsync();
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, User model)
        {
            var exists = await _dbContext.Users.AnyAsync(f => f.Id == id);
            if (!exists)
            {
                return NotFound();
            }

            _dbContext.Users.Update(model);

            await _dbContext.SaveChangesAsync();

            return Ok();

        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await _dbContext.Users.FindAsync(id);

            _dbContext.Users.Remove(entity);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
