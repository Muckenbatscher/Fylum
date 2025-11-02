using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Shared
{
    public class EndpointRoutes
    {
        public static string FileBaseRoute => "files";
        public static string TagsBaseRoute => "tags";
        public static string UsersBaseRoute => "users";
        public static string UserGroupsBaseRoute => $"{UsersBaseRoute}/groups";
        public static string LoginRoute => "login";
        public static string RegisterRoute => "register";

    }
}
