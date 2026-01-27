namespace Fylum.Users.Application;

public class PasswordHashSettings
{
    public int SaltBitsCount { get; set; }
    public int HashedBitsCount { get; set; }
    public int IterationCount { get; set; }
    public string PseudoRandomFunction { get; set; } = string.Empty;
}