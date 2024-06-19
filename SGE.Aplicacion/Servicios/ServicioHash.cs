namespace SGE.Aplicacion;
using System.Security.Cryptography;
using System.Text;

public class HashService : IHashService
{
    public (string Hash, string Salt) CreateHash(string password)
    {
        // Generate a salt
        byte[] salt = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        // Combine password and salt
        var combined = Combine(Encoding.UTF8.GetBytes(password), salt);

        // Hash the combined password and salt
        using (var sha256 = SHA256.Create())
        {
            byte[] hash = sha256.ComputeHash(combined);
            return (Convert.ToBase64String(hash), Convert.ToBase64String(salt));
        }
    }

    public bool VerifyHash(string password, string hash, string salt)
    {
        byte[] saltBytes = Convert.FromBase64String(salt);
        var combined = Combine(Encoding.UTF8.GetBytes(password), saltBytes);

        using (var sha256 = SHA256.Create())
        {
            byte[] computedHash = sha256.ComputeHash(combined);
            return Convert.ToBase64String(computedHash) == hash;
        }
    }

    private byte[] Combine(byte[] first, byte[] second)
    {
        byte[] ret = new byte[first.Length + second.Length];
        Buffer.BlockCopy(first, 0, ret, 0, first.Length);
        Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
        return ret;
    }
}
