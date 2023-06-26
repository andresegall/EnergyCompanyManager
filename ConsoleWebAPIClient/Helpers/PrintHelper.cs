namespace EnergyCompanyManager.ConsoleClient.Helpers;

public static class PrintHelper
{
    public static void PrintMenuText()
    {
        Console.Clear();
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

    public static void PrintPauseText()
    {
        Console.Write("  Press any key to continue... ");
        Console.ReadKey();
        Console.Clear();
    }
}
