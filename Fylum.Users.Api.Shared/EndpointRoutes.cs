namespace Fylum.Users.Api.Shared;

public class EndpointRoutes
{
    public static string UsersBaseRoute => "users";
    public static string UserGroupsBaseRoute => $"{UsersBaseRoute}/groups";
    public static string LoginRoute => "auth/login";
    public static string RegisterRoute => "auth/register";
    public static string TokenRefreshRoute => "auth/token-refresh";
}