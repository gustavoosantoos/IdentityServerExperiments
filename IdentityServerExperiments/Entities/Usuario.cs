using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServerExperiments.Entities
{
    public class Usuario
    {
        public string SubjectId { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public List<Claim> Claims { get; private set; }
    }
}
