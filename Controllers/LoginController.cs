using AuthAPIMVC.Models;
using AuthAPIMVC.Repositories;
using AuthAPIMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPIMVC.Controllers;
[ApiController]
[Route("v1")]
public class LoginController : ControllerBase
{
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
    {
        var user = UserRepository.Get(model.userName, model.password);
        if (user == null) return NotFound(new { message = "Usuário ou senha incorreta" });
        
        //Gerar o token
        var token = TokenService.GenerateToken(user);
        user.password = "";
        return new {user, token};
    }
}