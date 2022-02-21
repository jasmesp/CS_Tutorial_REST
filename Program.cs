using System.Net.Http.Headers;
using System.Text.Json;

namespace ConsoleApp1
{
    class Program
    {
        private static readonly HttpClient Client = new HttpClient();

        private static async Task<List<Repository>?> ProcessRepositories()
        {
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            Client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = Client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);
            return repositories;
        }

        private static async Task Main()
        {
            var repositories = await ProcessRepositories();

            if (repositories != null)
                foreach (var repo in repositories)
                    Console.WriteLine(repo.Name);
        }
    }
}