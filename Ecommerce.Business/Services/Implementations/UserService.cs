
using AutoMapper;
using Ecommerce.Business.Helpers.DTOs.UserDto;
using Ecommerce.Business.Services.Interfaces;
using Ecommerce.Core.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Ecommerce.Business.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccesor;
        public UserService(IConfiguration config, UserManager<User> userManager, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _userManager = userManager;
            _mapper = mapper;
            _httpContextAccesor = httpContextAccessor;
        }

        private string GenerateAccessToken(User user, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(20),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        private string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
        public async Task<TokenDto> LoginAsync(LoginDto login)
        {
            User? user = await _userManager.FindByEmailAsync(login.UserNameOrEmail) ??
                        await _userManager.FindByNameAsync(login.UserNameOrEmail);
            if (user == null) throw new InvalidOperationException("Istifadeci adi ve ya sifre yanlisdir");
            var checkPassword = await _userManager.CheckPasswordAsync(user, login.Password);
            if (!checkPassword) throw new InvalidOperationException("Istifadeci adi ve ya sifre yanlisdir");
            var roles = await _userManager.GetRolesAsync(user);
            var accessToken = GenerateAccessToken(user, roles);
            var refreshToken = GenerateRefreshToken();
            Token token = new Token
            {
                RefreshToken = refreshToken,
                RefreshTokenExpiration = DateTime.UtcNow.AddDays(7)
            };

            _httpContextAccesor.HttpContext.Response.Cookies.Append("RefreshToken", refreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddDays(7)
            });
            return new TokenDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        public async Task RegisterAsync(RegisterDto register)
        {
            if (await _userManager.FindByEmailAsync(register.Email) != null)
                throw new InvalidOperationException("Bu email artiq movcuddur");
            if (await _userManager.FindByNameAsync(register.UserName) != null)
                throw new InvalidOperationException("Bu username artiq movcuddur");
            var mapRegister = _mapper.Map<User>(register);
            var createRegister = await _userManager.CreateAsync(mapRegister, register.Password);
            if (!createRegister.Succeeded)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var error in createRegister.Errors)
                {
                    sb.AppendLine(error.Description);
                }
                throw new InvalidOperationException(sb.ToString());
            }
            await _userManager.UpdateAsync(mapRegister);
        }
    }
}
