using ConsoleClient.Models;
using Newtonsoft.Json;

using HttpClient client = new();

var key = Console.ReadKey();

if (key.KeyChar == '1')
{
    var jsonResponse = await client.GetStringAsync("https://localhost:7083/endpoint/get-all");
    var endpoints = JsonConvert.DeserializeObject<List<Endpoint>>(jsonResponse);

    foreach (var endpoint in endpoints)
    {
        Console.WriteLine(endpoint);
    }
}
