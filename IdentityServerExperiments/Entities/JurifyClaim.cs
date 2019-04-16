using System.Security.Claims;

namespace IdentityServerExperiments.Entities
{
    public class JurifyClaim
    {
        public JurifyClaim(string type, string value, string valueType = ClaimValueTypes.String)
        {
            Type = type;
            ValueType = valueType;
            Value = value;
        }

        public string Type { get; }
        public string ValueType { get; }
        public string Value { get; }
    }
}
