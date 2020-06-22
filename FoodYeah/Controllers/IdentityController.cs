using FoodYeah.Dto;
using FoodYeah.Model.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FoodYeah.Controllers
{
    [ApiController]
    [Route("identity")]
    public class IdentityController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        public IdentityController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public string Index()
        {
            return "";
        }
        [HttpPost("register")]
        public async Task<IActionResult> Create(ApplicationUserRegisterDto model)
        {
            var user = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };
            //El createAsync directamente encripta el password(solito)
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                throw new Exception("No se pudo crear el usuario");
            }
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(ApplicationUserLoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            var check = await _signInManager.CheckPasswordSignInAsync(user,model.Password,false);
            if (check.Succeeded)
            {
                //Return token 
                return Ok(await GenerateToken(user));
            }
            else return BadRequest("Acceso no valido a la aplicación");
        }
        private async Task<string> GenerateToken(ApplicationUser user)
        {
            //Definir un secretKey:
            var secretKey = _configuration.GetValue<string>("SecretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);
            //Los Claims contiene información relevante de nuestro usuario(La información que lleva el token)
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),//Asociar el id del usuario
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName)
            };
            ////Roles
            //var roles = await _userManager.GetRolesAsync(user);
            //foreach (var role in roles)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role,role))
            //};
            //Convtiene la información del token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //Los Claims contiene información relevate de nuestro usuario
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),//Duración de un día a partir de hoy (Este debería de durar milisegundos)
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(createdToken);
        }
    }
}
