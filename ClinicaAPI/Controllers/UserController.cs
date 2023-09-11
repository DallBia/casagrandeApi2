using ClinicaAPI.DataContext;
using ClinicaAPI.DTO;
using ClinicaAPI.Models;
using ClinicaAPI.Service.ClienteService;
using ClinicaAPI.Service.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ClinicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Login([FromBody] LoginDTO loginDetalhes)
        {
            var user = ValidarUsuario(loginDetalhes);
            if (user != null)
            {
                var tokenString = GerarTokenJWT(user);
                HttpContext.Response.Headers.Add("Baerer", tokenString);
                return Ok(new { token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
     
        private UserModel ValidarUsuario(LoginDTO loginDetalhes)
        {
            var smartUser = _context.Users.Where(user =>
            user.Email == loginDetalhes.Usuario && user.SenhaHash == loginDetalhes.Senha
            ).FirstOrDefault();
            if (smartUser == null) return null; else return smartUser;
        }
        private string GerarTokenJWT(UserModel smartUser)
        {     //Incluir informa;óes de usuário

            var _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim("valid", smartUser.Ativo.ToString()));
            permClaims.Add(new Claim("userid", smartUser.Id.ToString()));
            permClaims.Add(new Claim("name", smartUser.Nome));
            permClaims.Add(new Claim("email", smartUser.Email));
            permClaims.Add(new Claim("area", smartUser.AreaSession));
            permClaims.Add(new Claim("perfil", smartUser.IdPerfil.ToString()));

            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                permClaims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credentials
            );
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}
