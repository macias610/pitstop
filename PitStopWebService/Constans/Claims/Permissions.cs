using System;
using System.Collections.Generic;
using System.Text;

namespace Constans.Claims
{
    public static class Permissions
    {
        public static class Engines
        {
            public const string Manage = "engines.manage";
            public const string Get = "engines.get";
        }

        public static class Users
        {
            public const string Add = "users.add";
            public const string Edit = "users.edit";
            public const string Delete = "users.delete";
            public const string Get = "users.get";
            public const string EditRole = "users.edit.role";
        }
    }
}
