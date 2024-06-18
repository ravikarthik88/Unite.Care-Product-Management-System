using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Product.API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Product.API.Controllers
{
    [EnableCors("CrossPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthController(IConfiguration configuration, 
                            UserManager<AppUser> userManager,
                            SignInManager<AppUser> signInManager) 
        {
            config = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, lockoutOnFailure: false);
                if (result.Succeeded)
                {

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,user.FirstName),
                        new Claim(ClaimTypes.Email,model.Email),
                        new Claim(ClaimTypes.NameIdentifier,user.Id),
                        new Claim("Profilepic",user.PictureUrl)
                    };

                    var roles = await _userManager.GetRolesAsync(user);
                    foreach (var role in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }
                    byte[] Keybytes = Encoding.UTF8.GetBytes(config["JWTDATA:Key"]);
                    var credentials = new SigningCredentials(new SymmetricSecurityKey(Keybytes), SecurityAlgorithms.HmacSha256Signature);
                    var claimsIdentity = new ClaimsIdentity(claims);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = claimsIdentity,
                        Expires = DateTime.UtcNow.AddHours(1), // Token expiration time
                        SigningCredentials = credentials
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var TokenString = tokenHandler.WriteToken(token);

                    return Ok(new AuthResponseViewModel
                    {
                        Token = TokenString,
                        IsSuccess = true,
                        Message = "Login Success"
                    });
                }
            }
            return Unauthorized();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            string ImageUrl = string.Empty;
            ImageUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/uploads/common/avatar.png";
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
            {
                return BadRequest("User Already Exists");
            }

            var newuser = new AppUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email,
                Email = model.Email,
                EmailConfirmed = true,
                PictureUrl = ImageUrl
            };

            var result = await _userManager.CreateAsync(newuser, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newuser, "User");
                return Ok(new AuthResponseViewModel
                {
                    IsSuccess =true,
                    Message = "The User " + newuser.UserName + " is Created successfully"
                });
            }
            return BadRequest(result.Errors);
        }
    }
}
