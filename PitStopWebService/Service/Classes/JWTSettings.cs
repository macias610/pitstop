using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Classes
{
    public class JWTSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }
        public DateTime IssuedAt { get; set; } = DateTime.UtcNow;
        public DateTime NotBefore { get; set; } = DateTime.UtcNow;
        public Func<Task<string>> JtiGenerator =>
         () => Task.FromResult(Guid.NewGuid().ToString());
        public DateTime Expiration => IssuedAt.Add(ValidFor);
        public TimeSpan ValidFor { get; set; } = TimeSpan.FromMinutes(10);
        public SigningCredentials SigningCredentials { get; set; }

    }
}
