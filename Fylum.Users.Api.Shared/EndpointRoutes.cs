namespace Fylum.Users.Api.Shared;

public class EndpointRoutes
{
    public static string UsersBaseRoute => "users";
    public static string UserGroupsBaseRoute => $"{UsersBaseRoute}/groups";
    public static string LoginRoute => "login";
    public static string RegisterRoute => "register";

}
