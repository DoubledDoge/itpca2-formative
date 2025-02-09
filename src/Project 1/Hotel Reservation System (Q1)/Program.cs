namespace Hotel_Reservation_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        static string GetValidStringInput(string prompt)
        {
            do
            {
                try
                {
                    Console.Write($"{prompt}: ");
                    string? input = Console.ReadLine()?.Trim();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.Write(
                            "\nError: Input cannot be empty. \nPress Enter to try again... "
                        );
                        Console.ReadLine();
                        Console.WriteLine();
                        continue;
                    }

                    if (input.Any(char.IsDigit))
                    {
                        Console.Write(
                            "\nError: Input should not contain numbers. \nPress Enter to try again... "
                        );
                        Console.ReadLine();
                        Console.WriteLine();
                        continue;
                    }

                    return input;
                }
                catch (IOException ex)
                {
                    Console.Write(
                        $"\nError reading input: {ex.Message}. \nPress Enter to try again... "
                    );
                    Console.ReadLine();
                    Console.WriteLine();
                }
                catch (OutOfMemoryException)
                {
                    Console.Write("\nError: Input is too large. \nPress Enter to try again... ");
                    Console.ReadLine();
                    Console.WriteLine();
                }
            } while (true);
        }

        static int GetValidIntInput(
            string prompt,
            int minValue = int.MinValue,
            int maxValue = int.MaxValue,
            int? maxLength = default
        )
        {
            do
            {
                try
                {
                    Console.Write($"{prompt}: ");
                    string? input = Console.ReadLine()?.Trim();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.Write(
                            "\nError: Input cannot be empty. \nPress Enter to try again... "
                        );
                        Console.ReadLine();
                        Console.WriteLine();
                        continue;
                    }

                    if (maxLength.HasValue && input.Length > maxLength.Value)
                    {
                        Console.Write(
                            $"\nError: Input must not exceed {maxLength.Value} digits. \nPress Enter to try again... "
                        );
                        Console.ReadLine();
                        Console.WriteLine();
                        continue;
                    }

                    if (int.TryParse(input, out int result))
                    {
                        if (result < minValue || result > maxValue)
                        {
                            Console.Write(
                                $"\nError: Please enter a number between {minValue} and {maxValue}. \nPress Enter to try again... "
                            );
                            Console.ReadLine();
                            Console.WriteLine();
                            continue;
                        }
                        return result;
                    }
                    else
                    {
                        Console.Write(
                            "\nError: Please enter a valid whole number. \nPress Enter to try again... "
                        );
                        Console.ReadLine();
                        Console.WriteLine();
                        continue;
                    }
                }
                catch (IOException ex)
                {
                    Console.Write(
                        $"\nError reading input: {ex.Message}. \nPress Enter to try again... "
                    );
                    Console.ReadLine();
                    Console.WriteLine();
                }
                catch (OutOfMemoryException)
                {
                    Console.Write("\nError: Input is too large. \nPress Enter to try again... ");
                    Console.ReadLine();
                    Console.WriteLine();
                }
            } while (true);
        }
    }
}
