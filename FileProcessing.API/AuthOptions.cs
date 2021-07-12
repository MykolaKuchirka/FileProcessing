using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FileProcessing.API
{
	public class AuthOptions
	{
        public const string ISSUER = "MadebyMykola";
        public const string AUDIENCE = "SomeAdmin";
        const string KEY = "qwertysecretpassword";
        public const int LIFETIME = 2;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
