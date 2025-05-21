namespace Coontrera.Helpers
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyPassword(string storedHash, string passwordToCheck);
    }
}
