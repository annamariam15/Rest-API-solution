using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using AnnaMariaSolution.Server.Models;

namespace AnnaMariaSolution.Server.Services;

public class TokenService
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<User> _userManager;

    public TokenService(
        IConfiguration configuration,
        UserManager<User> userManager)
    {
        _configuration = configuration;
        _userManager = userManager;
    }

    public async Task<string> CreateToken(User user)
    {
        var roles = await _userManager.GetRolesAsync(user);


        var claims = new List<Claim>
        {
            new Claim(
                JwtRegisteredClaimNames.Sub,
                user.Id),

            new Claim(
                JwtRegisteredClaimNames.UniqueName,
                user.UserName ?? ""),

            new Claim(
                JwtRegisteredClaimNames.Email,
                user.Email ?? "")
        };


        foreach (var role in roles)
        {
            claims.Add(
                new Claim(
                    ClaimTypes.Role,
                    role));
        }

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(
                _configuration["Jwt:Key"]!));


        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256);


        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(
                Convert.ToDouble(
                    _configuration["Jwt:ExpireMinutes"])),
            signingCredentials: credentials);


        return new JwtSecurityTokenHandler()
            .WriteToken(token);
    }
}