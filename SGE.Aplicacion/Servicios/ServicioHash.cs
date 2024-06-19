namespace SGE.Aplicacion;
using System.Security.Cryptography;
using System.Text;

/*El sistema toma esa contraseña, le agrega una especie de "algo" único y aleatorio (llamado sal), 
y luego convierte toda esa mezcla en una serie de letras y números que no se parece en nada a la contraseña original. 
Eso es "hash SHA-256". 
Aunque alguien acceda a la base de datos, no puede descifrar las contraseñas originales 
porque solo verá estas cadenas de caracteres aparentemente aleatorias. 
La sal garantiza que incluso contraseñas similares tengan hashes diferenteS.*/
/*El nombre "SHA-256" proviene de su diseño como parte del conjunto de algoritmos Secure Hash Algorithm (SHA), 
desarrollados por la Agencia de Seguridad Nacional (NSA) de los Estados Unidos. 
"SHA" se refiere a Secure Hash Algorithm, y el número "256" indica la longitud del hash que produce: 256 bits. */

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
