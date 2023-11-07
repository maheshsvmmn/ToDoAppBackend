using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoetesAPI.Context;
using NoetesAPI.Models;
using NoetesAPI.Models.Dtos;
using NoetesAPI.Services.Authentication;
using System.Security.Claims;

namespace NoetesAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly JwtAuthenticationManager _jwtAuthenticationManager;
        readonly NotesDbContext _db;

        public UserController(JwtAuthenticationManager jwtAuthenticationManager , NotesDbContext db)
        {
            _jwtAuthenticationManager = jwtAuthenticationManager;
            _db = db;
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto usr)
        {
            var token = _jwtAuthenticationManager.Authenticate(usr.Email, usr.Password);

            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(new { success = true, authToken = token });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            var UserAlreadyExist = _db.Users.Any(u => u.Email == user.Email);

            if (UserAlreadyExist)
            {
                return Ok(new { message = "User already exists" });
            }

            user.CreatedAt = DateTime.Now;
            
            _db.Users.Add(user);
            _db.SaveChanges();

            var token = _jwtAuthenticationManager.Authenticate(user.Email, user.Password);

            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(new { success = true, authToken = token});
        }

        [Authorize]
        [Route("TestRoute")]
        [HttpGet]
        public IActionResult test()
        {
            HttpContext context = HttpContext;

            var user = context.User;
            return Ok(new {status = "authorized" , user = new {id = user.FindFirstValue(ClaimTypes.NameIdentifier), email =  user.FindFirstValue(ClaimTypes.Email)  } });
        }
    }
}
