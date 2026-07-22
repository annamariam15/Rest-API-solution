using AnnaMariaSolution.Server.DTOs;
using AnnaMariaSolution.Server.Models;
using AnnaMariaSolution.Server.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AnnaMariaSolution.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly TokenService _tokenService;
    private readonly IConfiguration _configuration;

    public AuthController(
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    IConfiguration configuration,
    TokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _tokenService = tokenService;
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterDTO dto)
    {
        var user = new User
        {
            UserName = dto.Username,
            Email = dto.Email
        };

        var result = await _userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok(new
        {
            user.Id,
            user.UserName,
            user.Email
        });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO dto)
    {
        // Find the user
        var user = await _userManager.FindByNameAsync(dto.Username);

        if (user == null)
            return Unauthorized("Invalid username or password.");

        // Check the password
        var result = await _signInManager.CheckPasswordSignInAsync(
            user,
            dto.Password,
            false);

        if (!result.Succeeded)
            return Unauthorized("Invalid username or password.");


        var token = _tokenService.CreateToken(user);

        return Ok(new
        {
            token
        });

    }

}
