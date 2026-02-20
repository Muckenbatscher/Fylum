namespace Fylum.Users.SharedModels;

public class EndpointRoutes
{
    public static string UsersBaseRoute => "users";
    public static string UserGroupsBaseRoute => $"{UsersBaseRoute}/groups";

    public static string AuthBaseRoute => "auth";
    public static string LoginRoute => $"{AuthBaseRoute}/login";
    public static string LogoutRoute => $"{AuthBaseRoute}/logout";
    public static string RegisterRoute => $"{AuthBaseRoute}/register";
    public static string TokenRefreshRoute => $"{AuthBaseRoute}/token-refresh";
}