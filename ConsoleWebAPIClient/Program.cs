using EnergyCompanyManager.ConsoleClient.Helpers;
using EnergyCompanyManager.ConsoleClient.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;

using HttpClient client = new();
const string basePath = "https://localhost:7083/endpoint";
ConsoleKeyInfo key = new();

do
{
    PrintHelper.PrintMenuText();
    key = Console.ReadKey();
    Console.Clear();

    switch (key.KeyChar)
    {
        case '1':
            await InsertEndpointAsync();
            break;

        case '2':
            await EditEndpointAsync();
            break;

        case '3':
            await DeleteEndpointAsync();
            break;

        case '4':
            await GetAllEndpointsAsync();
            break;

        case '5':
            await GetEndpointBySerialNumberAsync();
            break;

        default:
            break;
    }

    if (key.KeyChar == '6')
    {
        ConfirmExit();
    }
} while (key.KeyChar != '6');

async Task InsertEndpointAsync()
{
    Console.WriteLine("  Type endpoint serial number: ");
    var serialNumber = ReaderHelper.ReadTextInput();

    Console.WriteLine("  Type meter model id: ");
    var meterModelId = ReaderHelper.ReadIntegerInput();

    Console.WriteLine("  Type meter number: ");
    var meterNumber = ReaderHelper.ReadIntegerInput();

    Console.WriteLine("  Type firmware version: ");
    var meterFirmwareVersion = ReaderHelper.ReadTextInput();

    Console.WriteLine("  Type switch state: ");
    var switchState = ReaderHelper.ReadIntegerInput();

    var endpoint = new Endpoint(
        serialNumber!,
        meterModelId,
        meterNumber,
        meterFirmwareVersion!,
        switchState);

    var jsonContent = JsonConvert.SerializeObject(endpoint);
    var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

    var httpResponse = await client.PostAsync($"{basePath}", contentString);

    if (httpResponse.StatusCode == HttpStatusCode.Created)
    {
        Console.WriteLine("  Endpoint created with success!");
    }
    else
    {
        string responseBody = await httpResponse.Content.ReadAsStringAsync();
        Console.WriteLine($"  {responseBody}");
    }

    PrintHelper.PrintPauseText();
}

async Task EditEndpointAsync()
{
    Console.WriteLine("  Type endpoint serial number: ");
    var serialNumber = ReaderHelper.ReadTextInput();

    Console.WriteLine("  Type the new switch state: ");
    var switchState = ReaderHelper.ReadIntegerInput();

    var httpResponse = await client
        .PatchAsync($"{basePath}?serialNumber={serialNumber}&switchState={switchState}", null);

    if (httpResponse.StatusCode == HttpStatusCode.OK)
    {
        Console.WriteLine("  Endpoint edited with success!");
    }
    else
    {
        string responseBody = await httpResponse.Content.ReadAsStringAsync();
        Console.WriteLine($"  {responseBody}");
    }

    PrintHelper.PrintPauseText();
}

async Task DeleteEndpointAsync()
{
    Console.WriteLine("  Type endpoint serial number: ");
    var serialNumber = ReaderHelper.ReadTextInput();

    var getHttpResponse = await client.GetAsync($"{basePath}?serialNumber={serialNumber}");

    if (getHttpResponse.StatusCode == HttpStatusCode.OK)
    {
        string getResponseBody = await getHttpResponse.Content.ReadAsStringAsync();
        var endpoint = JsonConvert.DeserializeObject<Endpoint>(getResponseBody);

        ConsoleKeyInfo confirmationKey = new();

        while (confirmationKey.KeyChar != 'y' && confirmationKey.KeyChar != 'n')
        {
            Console.WriteLine($"  Do you really want to delete?\n{endpoint}\n  y or n?");

            confirmationKey = Console.ReadKey();
        }

        if (confirmationKey.KeyChar == 'y')
        {
            var deleteHttpResponse = await client.DeleteAsync($"{basePath}?serialNumber={serialNumber}");

            if (deleteHttpResponse.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("  Endpoint deleted with success!");
            }
            else
            {
                string deleteResponseBody = await deleteHttpResponse.Content.ReadAsStringAsync();
                Console.WriteLine($"  {deleteResponseBody}");
            }
        }
    }
    else
    {
        Console.WriteLine($"  Not found!");
    }

    PrintHelper.PrintPauseText();
}

async Task GetAllEndpointsAsync()
{
    var jsonResponse = await client.GetStringAsync($"{basePath}/get-all");
    var endpoints = JsonConvert.DeserializeObject<List<Endpoint>>(jsonResponse);

    foreach (var endpoint in endpoints!)
    {
        Console.WriteLine(endpoint);
    }

    PrintHelper.PrintPauseText();
}

async Task GetEndpointBySerialNumberAsync()
{
    Console.WriteLine("  Type endpoint serial number: ");
    var serialNumber = ReaderHelper.ReadTextInput();

    var httpResponse = await client.GetAsync($"{basePath}?serialNumber={serialNumber}");

    if (httpResponse.StatusCode == HttpStatusCode.OK)
    {
        string responseBody = await httpResponse.Content.ReadAsStringAsync();
        var endpoint = JsonConvert.DeserializeObject<Endpoint>(responseBody);
        Console.WriteLine($"{endpoint}");
    }
    else
    {
        Console.WriteLine($"  Not found!");
    }

    PrintHelper.PrintPauseText();
}

void ConfirmExit()
{
    ConsoleKeyInfo confirmationKey = new();

    while (confirmationKey.KeyChar != 'y' && confirmationKey.KeyChar != 'n')
    {
        Console.WriteLine($"  Do you really want to exit?\n  y or n?");

        confirmationKey = Console.ReadKey();
    }

    if (confirmationKey.KeyChar == 'n')
    {
        PrintHelper.PrintMenuText();
        key = Console.ReadKey();
        Console.Clear();
    }
}