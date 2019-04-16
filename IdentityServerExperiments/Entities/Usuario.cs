using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace IdentityServerExperiments.Entities
{
    public class Usuario
    {
        protected Usuario()
        {
        }

        public Usuario(string subjectId, string username, string password, List<JurifyClaim> claims)
        {
            SubjectId = subjectId;
            Username = username;
            Password = password;
            Claims = claims;
        }

        public string SubjectId { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public List<JurifyClaim> Claims { get; private set; }

        [JsonIgnore]
        public List<Claim> StandartClaims => Claims?
            .Select(c => new Claim(c.Type, c.Value, c.ValueType))
            .ToList();
    }
}
