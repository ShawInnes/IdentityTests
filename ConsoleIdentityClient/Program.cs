using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityModel.Client;

namespace ConsoleIdentityClient
{
    class Program
    {

        static TokenResponse GetToken()
        {
            const string scopeName = "api1";
            const string clientId = "silicon";
            const string clientSecret = "F621F470-9731-4A25-80EF-67A6F7C5F4B8";

            var client = new OAuth2Client(
                new Uri("https://localhost:44302/identity/connect/token"),
                clientId,
                clientSecret);

            return client.RequestClientCredentialsAsync(scopeName).Result;
        }

        static TokenResponse GetUserToken()
        {
            const string scopeName = "api1";
            const string clientId = "carbon";
            const string clientSecret = "21B5F798-BE55-42BC-8AA8-0025B903DC3B";

            const string userName = "alice";
            const string password = "alice";

            var client = new OAuth2Client(
                new Uri("https://localhost:44302/identity/connect/token"),
                clientId,
                clientSecret);

            return client.RequestResourceOwnerPasswordAsync(userName, password, scopeName).Result;
        }

        static void CallApi(TokenResponse response)
        {
            var client = new HttpClient();
            client.SetBearerToken(response.AccessToken);

            Console.WriteLine(client.GetStringAsync("http://localhost:3928/test").Result);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hit a key to request token");
            Console.ReadKey();

            var token = GetToken();

            Console.WriteLine("Hit a key to do authenticated API call");
            Console.ReadKey();

            CallApi(token);

            Console.WriteLine("Hit a key to request a user token");
            Console.ReadKey();

            var userToken = GetUserToken();

            Console.WriteLine("Hit a key to do authenticated API call");
            Console.ReadKey();

            CallApi(userToken);

            Console.ReadLine();
        }
    }
}
