namespace ConsoleClient.Models;

public class Endpoint
{
    public string? SerialNumber { get; set; }

    public int MeterModelId { get; set; }

    public int MeterNumber { get; set; }

    public string? MeterFirmwareVersion { get; set; }

    public int SwitchState { get; set; }

    public override string ToString() =>
        $"\nEndpoint {SerialNumber}\n" +
        $"  Meter model id: {MeterModelId}\n" +
        $"  Meter number: {MeterNumber}\n" +
        $"  Meter firmware version: {MeterFirmwareVersion}\n" +
        $"  Switch state: {SwitchState}\n";
}