using IdentityServer3.Core.Models;
using System.Collections.Generic;

namespace IdServer
{
    internal static class Scopes
    {
        public static List<Scope> Get()
        {
            return new List<Scope>
            {
                new Scope
                {
                    Name = "api1"
                }
            };
        }
    }
}
