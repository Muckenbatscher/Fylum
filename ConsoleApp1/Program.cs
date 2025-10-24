using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace PasswordhashCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a password: ");
            string? password = Console.ReadLine();

            Console.Write("Enter a salt (base64 encoded) or leave empty to generate one: ");
            string? saltInput = Console.ReadLine();
            byte[] salt;
            if (!string.IsNullOrEmpty(saltInput))
            {
                salt = Convert.FromBase64String(saltInput);
            }
            else
            {
                // Generate a 128-bit salt using a sequence of
                // cryptographically strong random bytes.
                salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes
                Console.WriteLine($"Generated Salt: {Convert.ToBase64String(salt)}");
            }

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            Console.WriteLine($"Hashed: {hashed}");
        }
    }
}
