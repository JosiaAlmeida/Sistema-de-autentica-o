using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AuthAPIMVC.Models;

using Microsoft.IdentityModel.Tokens;

namespace AuthAPIMVC.Services
{
    public static class TokenService
    {
        // metodo para gerar o token
        public static string GenerateToken(User user){
            //Uma classe para gerar o token
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            //Criptografar a chave secreta e transformando em array de bytes
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            //Gera as informações essencias para o token funcionar
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor{
                //Cria uma lista de usuario
                Subject = new ClaimsIdentity(new []{
                    //Mapea a classe User.Identity.Name
                    new Claim(ClaimTypes.Name, user.userName),
                    //Mapea a classe User.Identity.IsInRole
                    new Claim(ClaimTypes.Role, user.role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                //Credenciais para Criptografar e reverso, com criptografia sha256
                SigningCredentials = new SigningCredentials( new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            //Cria o token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}