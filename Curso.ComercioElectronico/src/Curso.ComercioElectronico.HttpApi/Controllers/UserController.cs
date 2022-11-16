using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Curso.ComercioElectronico.HttpApi.Autenticacion;
using Curso.ECommerce.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Curso.ComercioElectronico.HttpApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly JwtConfiguration options;

        private readonly List<Usuario> listaUsuarios;
        public UserController(IOptions<JwtConfiguration> options, IOptions<List<Usuario>> listaUsuarios)
        {
            this.options=options.Value;
            this.listaUsuarios=listaUsuarios.Value;
        }

        [HttpPost]
        public string Login(string User,string Password ){
            
            var usuario = listaUsuarios.Where(x=>x.User.Equals(User) && x.Password.Equals(Password)).SingleOrDefault();
            //1. Validar User.
            if(usuario == null){
                
                throw new ArgumentNullException("No exite ese Usuario ");
            }
            //2. Generar claims
            //create claims details based on the user information
            var claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, usuario.User));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()));
            //Roles
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new JwtSecurityToken(
                options.Issuer,
                options.Audience,
                claims,
                expires: DateTime.UtcNow.Add(options.Expires),
                signingCredentials: signIn);

            var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
            return jwt;
        }
    }
}