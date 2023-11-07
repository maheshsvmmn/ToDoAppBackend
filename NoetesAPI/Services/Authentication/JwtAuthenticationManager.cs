using Microsoft.IdentityModel.Tokens;
using NoetesAPI.Context;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NoetesAPI.Services.Authentication
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly string key;
        private readonly NotesDbContext _db;

        public JwtAuthenticationManager(){  }

        public JwtAuthenticationManager( NotesDbContext db)
        {
            this.key = Environment.GetEnvironmentVariable("jwtSecretKey");
            Console.WriteLine(key);
            this._db = db;
        }

        public string Authenticate(string email, string password)
        {
            var user = _db.Users.FirstOrDefault(x => x.Email == email);

            if (user == null)
            {
                return null;
            }
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                }),
                //set duration of token here
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature) //setting sha256 algorithm
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
