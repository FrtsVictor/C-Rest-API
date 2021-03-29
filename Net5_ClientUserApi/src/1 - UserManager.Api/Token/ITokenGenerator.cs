namespace UserManager.Api.Token
{
    public interface ITokenGenerator
    {
        string GenerateToken();
    }
}