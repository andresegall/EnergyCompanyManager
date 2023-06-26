using ConsoleClient.Models;
using Newtonsoft.Json;
using System.Net;

using HttpClient client = new();

PrintMenuText();
var key = Console.ReadKey();
Console.Clear();

while (key.KeyChar != '6')
{
    switch (key.KeyChar)
    {
        case '4':
            await GetAllEndpointsAsync();
            break;

        case '2':
            await EditEndpointAsync();
            break;

        default:
            PrintMenuText();
            key = Console.ReadKey();
            Console.Clear();
            break;
    }

    PrintMenuText();
    key = Console.ReadKey();
    Console.Clear();
}


static void PrintMenuText()
{
    Console.Write(
    "  *** ENERGY COMPANY MANAGER ***\n\n" +
    "  1) Insert new endpoint\n" +
    "  2) Edit existing endpoint\n" +
    "  3) Delete existing endpoint\n" +
    "  4) List all endpoints\n" +
    "  5) Find endpoint by serial number\n" +
    "  6) Exit\n\n" +
    "  Type your option number: ");
}

static void PrintPauseText()
{
    Console.Write("  Press any key to continue... ");
    Console.ReadKey();
    Console.Clear();
}

async Task GetAllEndpointsAsync()
{
    var jsonResponse = await client.GetStringAsync("https://localhost:7083/endpoint/get-all");
    var endpoints = JsonConvert.DeserializeObject<List<Endpoint>>(jsonResponse);

    foreach (var endpoint in endpoints!)
    {
        Console.WriteLine(endpoint);
    }

    PrintPauseText();
}

async Task EditEndpointAsync()
{
    Console.WriteLine("  Type endpoint serial number: ");
    var serialNumber = Console.ReadLine();

    Console.WriteLine("  Type the new switch state: ");
    var switchState = Console.ReadLine();

    var httpResponse = await client
        .PatchAsync($"https://localhost:7083/endpoint?serialNumber={serialNumber}&switchState={switchState}", null);

    if (httpResponse.StatusCode == HttpStatusCode.OK)
    {
        Console.WriteLine("  Endpoint edited with success!");
    }
    else
    {
        string responseBody = await httpResponse.Content.ReadAsStringAsync();
        Console.WriteLine($"  {responseBody}");
    }

    PrintPauseText();
}