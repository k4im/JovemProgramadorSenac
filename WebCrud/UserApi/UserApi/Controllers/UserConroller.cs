using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace UserApi.Controllers
{
    [Route("Api")]
    public class UserConroller : ControllerBase
    {
        [HttpPost("users/create")]
        public async Task<ActionResult<User>> CreateAsync([FromBody] User model, [FromServices] ApplicationContext context)
        {

            HashPwd(model);
            await context.Users.AddAsync(model);
            await context.SaveChangesAsync();
            return Ok(model);
        }
        
        private void HashPwd (User model)
        {
            var pwdHash = new PasswordHasher<User>();
            model.Password = pwdHash.HashPassword(model, model.Password);
        }

        [HttpGet("users/get")]
        public async Task<ActionResult<List<User>>> GetAsync([FromServices] ApplicationContext context)
        {
            var users = await context.Users.AsNoTracking().ToListAsync();
            return Ok(users);
        }

        [HttpPost("login")]
        public async Task<ActionResult<dynamic>> login([FromBody] User model, [FromServices] ApplicationContext context)
        {
            var pwd = new PasswordHasher<User>();
            var user = await context.Users.Where(x => x.Id == model.Id && x.Username == model.Username).FirstOrDefaultAsync();
            if (user == null) return NotFound("Usuario não encontrado");
            if (pwd.VerifyHashedPassword(user, user.Password, model.Password) != PasswordVerificationResult.Failed)
            {
                var token = TokenService.GenerateToken(user);
                return new { user = user, token = token };
            }
            else return BadRequest("algo deu errado");
        }
    
    }
}
