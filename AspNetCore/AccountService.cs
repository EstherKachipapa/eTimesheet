using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore;

public class AccountService : IAccountService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly TokenSettings _tokenSettings;
    public AccountService(ApplicationDbContext dbContext,
    IOptions<TokenSettings> tokenSettings)
    {
        _dbContext = dbContext;
        _tokenSettings = tokenSettings.Value;
    }
    private string CreateJwtToken(User user)
    {
        var symmetricSecurityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_tokenSettings.SecretKey)
        );
        var credentials = new SigningCredentials(
            symmetricSecurityKey,
            SecurityAlgorithms.HmacSha256
        );

        var userCliams = new Claim[]{
        new Claim("username", user.Username),
    };

        var jwtToken = new JwtSecurityToken(
            issuer: _tokenSettings.Issuer,
            expires: DateTime.Now.AddMinutes(20),
            signingCredentials: credentials,
            claims: userCliams,
            audience: _tokenSettings.Audience
        );

        string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        return token;
    }
    public async Task<TokenDto> GetAuthTokens(LoginDto login)
    {
        //Note: demo purpose saved plain password to the database
        // checking the plain password
        // In real time application please make sure to save the hash password into the database
        // need to hash the password while comparing also
        User user = await _dbContext.Users
        .Where(_ => _.Username.ToLower() == login.Username.ToLower() &&
        _.Password == login.Password).FirstOrDefaultAsync();

        if (user != null)
        {
            var token = new TokenDto
            {
                AccessToken = CreateJwtToken(user)
            };
            return token;
        }
        return null;
    }
}