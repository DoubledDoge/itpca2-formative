namespace Hotel_Reservation_System
{
    public static class InputValidator
    {
        public static string GetValidStringInput(string prompt)
        {
            do
            {
                try
                {
                    Console.Write($"{prompt}: ");
                    string? input = Console.ReadLine()?.Trim();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        ConsoleDesign.WriteError(
                            "\nError: Input cannot be empty. \nPress Enter to try again... "
                        );
                        Console.ReadLine();
                        Console.WriteLine();
                    }
                    else if (input.Any(char.IsDigit))
                    {
                        ConsoleDesign.WriteError(
                            "\nError: Input should not contain numbers. \nPress Enter to try again... "
                        );
                        Console.ReadLine();
                        Console.WriteLine();
                    }
                    else
                    {
                        return input;
                    }
                }
                catch (Exception ex)
                {
                    ConsoleDesign.WriteError(
                        $"\nError: {ex.Message}. \nPress Enter to try again..."
                    );
                    Console.ReadLine();
                    Console.WriteLine();
                }

                Console.WriteLine();
            } while (true);
        }

        public static int GetValidIntInput(
            string prompt,
            int minValue = int.MinValue,
            int maxValue = int.MaxValue
        )
        {
            do
            {
                try
                {
                    Console.Write($"{prompt}: ");
                    string? input = Console.ReadLine()?.Trim();

                    if (
                        int.TryParse(input, out int result)
                        && result >= minValue
                        && result <= maxValue
                    )
                    {
                        return result;
                    }
                    else
                    {
                        ConsoleDesign.WriteError(
                            $"\nError: Please enter a number between {minValue} and {maxValue}. \nPress Enter to try again... "
                        );
                        Console.ReadLine();
                        Console.WriteLine();
                    }
                }
                catch (Exception ex)
                {
                    ConsoleDesign.WriteError(
                        $"\nError: {ex.Message}. \nPress Enter to try again..."
                    );
                    Console.ReadLine();
                    Console.WriteLine();
                }
            } while (true);
        }

        public static DateTime GetValidDateInput(string prompt)
        {
            do
            {
                try
                {
                    Console.Write($"{prompt} (dd/mm/yyyy): ");
                    string? input = Console.ReadLine()?.Trim();

                    if (
                        DateTime.TryParseExact(
                            input,
                            "dd/MM/yyyy",
                            null,
                            System.Globalization.DateTimeStyles.None,
                            out DateTime date
                        )
                    )
                    {
                        return date;
                    }
                    else
                    {
                        ConsoleDesign.WriteError(
                            "\nError: Please enter a valid date in the format dd/mm/yyyy. \nPress Enter to try again..."
                        );
                        Console.ReadLine();
                        Console.WriteLine();
                    }
                }
                catch (Exception ex)
                {
                    ConsoleDesign.WriteError(
                        $"\nError: {ex.Message}. \nPress Enter to try again..."
                    );
                    Console.ReadLine();
                    Console.WriteLine();
                }
            } while (true);
        }
    }
}
