namespace EnergyCompanyManager.ConsoleClient.Models;

public class Endpoint
{
    public Endpoint(
        string serialNumber,
        int meterModelId,
        int meterNumber,
        string meterFirmwareVersion,
        int switchState)
    {
        SerialNumber = serialNumber;
        MeterModelId = meterModelId;
        MeterNumber = meterNumber;
        MeterFirmwareVersion = meterFirmwareVersion;
        SwitchState = switchState;
    }

    public string? SerialNumber { get; set; }

    public int MeterModelId { get; set; }

    public int MeterNumber { get; set; }

    public string? MeterFirmwareVersion { get; set; }

    public int SwitchState { get; set; }

    public override string ToString() =>
        $"\n  Endpoint {SerialNumber}\n" +
        $"    Meter model id: {MeterModelId}\n" +
        $"    Meter number: {MeterNumber}\n" +
        $"    Meter firmware version: {MeterFirmwareVersion}\n" +
        $"    Switch state: {SwitchStateToString(SwitchState)}\n";

    private static string SwitchStateToString(int switchState)
    {
        return switchState switch
        {
            0 => "Disconnected",
            1 => "Connected",
            2 => "Armed",
            _ => "",
        };
    }
}