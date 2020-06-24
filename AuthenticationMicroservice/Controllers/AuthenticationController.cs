using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuthenticationMicroservice.Database;
using AuthenticationMicroservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        DatabaseContext db;
        IConfiguration config;
        public AuthenticationController(DatabaseContext _db, IConfiguration _config)
        {
            db = _db;
            config = _config;
        }

        // Método utilizado para generar el token del usuario 
        private string GenerateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //For JWT Cliams help : https://tools.ietf.org/html/rfc7519#section-5
            var claims = new Claim[] {
                             new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.UPCCode),
                             new Claim(JwtRegisteredClaimNames.Sub, userInfo.Names + " " + userInfo.FirstName + " " + userInfo.LastName),
                             new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),                             
                             new Claim("FechaCreacion", DateTime.Now.ToString()),
                             };

            var token = new JwtSecurityToken(config["Jwt:Issuer"],
                                            config["Jwt:Audience"],
                                            claims,
                                            expires: DateTime.Now.AddMinutes(120),
                                            signingCredentials: credentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(token);
            return encodedJwt;
        }

        [HttpPost("login")]
        // Parámetros que se deben enviar en el body-request: LoginModel => Username y Password
        public IActionResult ValidateUser(LoginModel model)
        {
            UserModel data = (from user in db.Users
                                  where user.UPCCode == model.Username && user.Password == model.Password
                                  select new UserModel
                                  {
                                      Id = user.UserId,
                                      UPCCode = user.UPCCode,
                                      FirstName = user.FirstName,
                                      LastName = user.LastName,
                                      Names = user.Names,
                                      Email = user.Email,                                      
                                      Career = user.Career,
                                      Modality = user.Modality
                                  }).FirstOrDefault();

            // Genera el token en base a la data obtenida de BD
            data.Token = GenerateJSONWebToken(data);

            // Retorna la estructura UserInfoModel en el body-response
            return Ok(data);
        }

        [HttpPost("loginInfo")]
        // Parámetros que se deben enviar en el body-request: LoginInfoModel => UPCCode, FirstName, LastName, Names, Career, Modality, CreationDate y CreationUser
        public void RegisterLoginInfo(LoginInfoModel model)
        {            
            UserLogins userLogin = new UserLogins {
                UPCCode = model.UPCCode,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Names = model.Names,
                Career = model.Career,
                Modality = model.Modality,
                CreationDate = DateTime.Now,
                CreationUser = model.UPCCode
            };            

            db.UserLogins.Add(userLogin);
            db.SaveChanges();
        }
    }
}