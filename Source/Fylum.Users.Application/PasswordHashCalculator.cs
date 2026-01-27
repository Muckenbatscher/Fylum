using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;

namespace Fylum.Users.Application;

public class PasswordHashCalculator : IPasswordHashCalculator
{
    private readonly PasswordHashSettings _settings;

    public PasswordHashCalculator(IOptions<PasswordHashSettings> settings)
    {
        _settings = settings.Value;
    }

    public string CreateRandomSalt()
    {
        int saltSizeBytes = _settings.SaltBitsCount / 8; // bits to bytes
        var saltBytes = RandomNumberGenerator.GetBytes(saltSizeBytes);
        return Convert.ToBase64String(saltBytes);
    }

    public string Hash(string password, string saltInput)
    {
        byte[] salt = Convert.FromBase64String(saltInput);

        int hashLengthBytes = _settings.HashedBitsCount / 8; // bits to bytes
        var hashBytes = KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: GetPseudoRandomFunctionFromSettings(),
            iterationCount: _settings.IterationCount,
            numBytesRequested: hashLengthBytes);

        string hashed = Convert.ToBase64String(hashBytes);
        return hashed;
    }
    private KeyDerivationPrf GetPseudoRandomFunctionFromSettings()
    {
        return _settings.PseudoRandomFunction switch
        {
            "HMACSHA1" => KeyDerivationPrf.HMACSHA1,
            "HMACSHA256" => KeyDerivationPrf.HMACSHA256,
            "HMACSHA512" => KeyDerivationPrf.HMACSHA512,
            _ => throw new InvalidOperationException($"Unsupported PseudoRandomFunction: {_settings.PseudoRandomFunction}"),
        };
    }

    public bool Verify(string password, string hash, string salt)
    {
        var calculatedHash = Hash(password, salt);
        return calculatedHash == hash;
    }
}