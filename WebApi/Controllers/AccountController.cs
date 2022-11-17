using Domain.Dtos;
using Infrastructure.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes ="Bearer")]
public class AccountController : ControllerBase
{

   private readonly AccountService _accountService;

    public AccountController(AccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var result = await _accountService.Login(loginDto);
        if(result == null)
        {
            return BadRequest(loginDto);
        }
        else return Ok(result);
    }
    
    //register
    [HttpPost("register")]
    //[Authorize(Roles = "Administrator")]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        var result = await _accountService.Register(registerDto);
        if(result == null )
        {
            return BadRequest(registerDto);
        }
        else return Ok(result);
    }
}
