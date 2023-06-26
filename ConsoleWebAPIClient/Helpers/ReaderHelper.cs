namespace EnergyCompanyManager.ConsoleClient.Helpers;

public static class ReaderHelper
{
    public static int ReadIntegerInput()
    {
        var isValid = false;
        var input = 0;

        while (!isValid)
        {
            isValid = int.TryParse(Console.ReadLine()!, out input);

            if (!isValid)
            {
                Console.WriteLine("  Invalid input number. Try again: ");
            }
        }

        return input;
    }

    public static string ReadTextInput()
    {
        var isValid = false;
        var text = "";

        while (!isValid)
        {
            text = Console.ReadLine();
            isValid = !string.IsNullOrEmpty(text);

            if (!isValid)
            {
                Console.WriteLine("  Invalid input text. Try again: ");
            }
        }

        return text!;
    }
}
