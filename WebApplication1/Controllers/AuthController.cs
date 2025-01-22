
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.DTO;
using WebApplication1.Interface;

namespace JWT_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUser _userRepo;

        public AuthController(IConfiguration config, IUser userRepo)
        {
            _config = config;
            _userRepo = userRepo;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Auth([FromBody] UserLoginDTO loginDto)
        {
            IActionResult response = Unauthorized();
            var dbUser = await _userRepo.validateUser(loginDto.email, loginDto.password);

            if (dbUser != null)
            {
                var issuer = _config["Jwt:Issuer"];
                var audience = _config["Jwt:Audience"];
                var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
                var signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature);

                var subject = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, dbUser.userId.ToString()),
                    new Claim(ClaimTypes.Name, dbUser.userName)
                };

                if (dbUser.Role != null)
                {
                    subject.Add(new Claim(ClaimTypes.Role, dbUser.Role.ToString()));
                }

                var expires = DateTime.UtcNow.AddHours(1);
                var tokenDesc = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(subject),
                    Expires = expires,
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = signingCredentials
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDesc);
                var jwtToken = tokenHandler.WriteToken(token);

                return Ok(new { token = jwtToken });
            }

            return response;
        }
    }
}