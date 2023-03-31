namespace AspNetCore;

public interface IAccountService
{
    Task<TokenDto> GetAuthTokens(LoginDto login);
}