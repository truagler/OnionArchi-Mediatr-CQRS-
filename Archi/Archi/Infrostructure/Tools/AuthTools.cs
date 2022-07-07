using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Archi.Infrostructure.Tools
{
    public class AuthTools
    {
        public class AuthOptions
        {
            public const string ISSUER = "MyAuthServer"; 
            public const string AUDIENCE = "MyAuthClient"; 
            const string KEY = "kotiki_s_korotkimi_lapkami12345!!!";
            public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
        }
    }
}