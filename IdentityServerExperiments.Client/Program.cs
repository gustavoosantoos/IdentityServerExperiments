using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IdentityServerExperiments.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                var discovery = await client.GetDiscoveryDocumentAsync("http://localhost:5000");
                if (discovery.IsError)
                {
                    Console.WriteLine("Error while discovering authority:" + discovery.Error);
                    Console.ReadKey();
                    return;
                }

                var token = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    ClientId = "test",
                    ClientSecret = "test",
                    Address = discovery.TokenEndpoint
                });

                if (token.IsError)
                {
                    Console.WriteLine("Error while loading token: " + token.Error);
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine(token.AccessToken);
                Console.WriteLine("\n\n");

                client.SetBearerToken(token.AccessToken);
                var response = await client.GetStringAsync("http://localhost:7000/api/values");

                Console.WriteLine(response);

                Console.ReadKey();
            }
        }
    }
}
