namespace Fylum.Client.Auth.Token;

public class InitialLoginMissingException : Exception
{
    public InitialLoginMissingException() : base("Initial login is required before using the client.")
    {
    }
}
