using System;
using System.Collections.Generic;
using System.Text;

namespace Constans.Policies
{
    public static class PolicyTypes
    {
        public static class Users
        {
            public const string Manage = "users.manage.policy";
            public const string Edit = "users.edit.policy";
        }

        public static class Engines
        {
            public const string Manage = "engines.manage.policy";
            public const string Get = "engines.get.policy";
        }


    }
}
