using HttpClient client = new();

var json = await client.GetStringAsync("https://localhost:7083/endpoint/get-all");

Console.Write(json);