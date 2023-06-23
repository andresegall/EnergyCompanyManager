namespace EnergyCompanyManager.Models;

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

    public string SerialNumber { get; set; }

    public int MeterModelId { get; set; }

    public int MeterNumber { get; set; }

    public string MeterFirmwareVersion { get; set; }

    public int SwitchState { get; set; }
}