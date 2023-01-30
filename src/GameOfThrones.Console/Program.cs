using IdentityModel.Client;
using System.Net.Http;

namespace GameOfThrones.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var token = GetClientToken();
            System.Console.WriteLine($"token {token.AccessToken}");
            CallApi(token);
            System.Console.ReadLine();
        }

        static TokenResponse GetClientToken()
        {
            var client = new HttpClient();

            var response = client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = "http://localhost:44333/connect/token",

                ClientId = "silicon",
                ClientSecret = "F621F470-9731-4A25-80EF-67A6F7C5F4B8",
                Scope = "api1"
            }).Result;

            return response;
        }


        static void CallApi(TokenResponse response)
        {
            var client = new HttpClient();
            client.SetBearerToken(response.AccessToken);

            System.Console.WriteLine($"result call resource with access token: { client.GetStringAsync("http://localhost:44318/test").Result}");
        }
    }
}
