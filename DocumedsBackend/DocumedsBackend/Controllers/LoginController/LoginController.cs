using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using DocumedsBackend.Authentication;
using DocumedsBackend.Controllers;

namespace DocumedsBackend
{
	[ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly documeds_dbContext _db;
        public LoginController(documeds_dbContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Возвращает токен авторизации и информацию о текущем пользователе, если пройдена авторизация.
        /// </summary>
        /// <returns>Информация о текущем пользователе</returns>
        [HttpPost]
        public async Task<IActionResult> Token(InDto dto)
        {
            var user = await _db.Users.Where(x => x.IdOrg == 1).FirstOrDefaultAsync(x => x.Login == dto.Login && x.Password == dto.Password);
            if (user == null)
            {
                ModelState.AddModelError(nameof(dto.Login), "Вы ввели неверные имя пользователя или пароль!");
                return BadRequest(ModelState);
            }


            var identity = GetIdentity(user);

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new 
            {
                Id = user?.Id ?? 0,
                Fullname = user.Login,
               // IdOrg = user.Login,
                // Post = currentPerson?.PersonPositions?.FirstOrDefault()?.IdPositionNavigation.Name,
                //Roles = identity.Claims.Where(c => c.Type == ClaimsIdentity.DefaultRoleClaimType).Select(c => c.Value).ToList(),
                Token = encodedJwt,
                Tokenexpires = now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
            };


            return Ok(response);
        }

        private ClaimsIdentity GetIdentity(User user)
        {

            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
                };

            claims.Add(new Claim(ClaimTypes.Actor, user.IdOrg.ToString()));
           // claims.AddRange(user.UserRoles.Select(r => new Claim(ClaimsIdentity.DefaultRoleClaimType, r.IdUserRoleTypeNavigation.Code)));
            return new ClaimsIdentity(claims, "Token"); ;
        }
    }
}

