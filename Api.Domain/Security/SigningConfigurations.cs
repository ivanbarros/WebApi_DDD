using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace Api.Domain.Security
{
    public class SigningConfigurations
    {
        public SecurityKey SecurityKey { get; set; }
        public SigningCredentials SigningCredentials { get; set; }

        public SigningConfigurations()
        {
            using (var provider  = new RSACryptoServiceProvider(2048))
            {
                SecurityKey =  new RsaSecurityKey(provider.ExportParameters(true));
            }
            SigningCredentials =  new SigningCredentials(SecurityKey, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}
