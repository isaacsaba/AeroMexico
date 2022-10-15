using ApiAeroMexico.Model;
using ApiAeroMexico.Utilidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiAeroMexico.Controllers
{
    public class LoginController : Controller
    {
       ILoginService _loginService;
       public IConfiguration _configuration;

        public LoginController(ILoginService loginService, IConfiguration config)
        {
            _loginService = loginService;
            _configuration = config;

        }


        [HttpPost]
        [Route("Login/")]
        public async Task<IActionResult> Login([FromBody] User _userData)
        {
            if (_userData != null && _userData.UserName != null && _userData.Password != null)
            {
                _userData.Password = Encriptador.Encrypt(_userData.Password);
                User user =  _loginService.GetUser( _userData);

                if (user != null)
                {

                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.UserId.ToString()),
                        new Claim("UserName", user.UserName),
                        new Claim("Password", user.Password)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return Unauthorized("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }      
        
        [HttpPost]
        [Route("Login/Registro")]
        public IActionResult CreateUser([FromBody] User user)
        {
            try{
                user.Password = Encriptador.Encrypt(user.Password);
                _loginService.CreateUser(user);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
                 
        }
    }
}
