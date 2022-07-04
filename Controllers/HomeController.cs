using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AuthAPIMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace AuthAPIMVC.Controllers;

[ApiController]
[Route("v1")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Index()
    {
        return Ok("Anonimo");
    }


    [HttpGet("Management")]
    [Route("Management")]
    [Authorize(Roles ="manager")]
    public IActionResult Management()
    {
        return Ok("Management");
    }

    [HttpGet("employee")]
    [Authorize(Roles ="employee, manager")]
    public IActionResult Employee(){
        return Ok("employee");
    }

    [HttpGet("auth")]
    [Authorize]
    public IActionResult Authentication(){
        return Ok("Authentication "+User.Identity.Name);
    }
}
