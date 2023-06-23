using HttpClient client = new();

var json = await client.GetStringAsync("https://localhost:7083/endpoint");

Console.Write(json);