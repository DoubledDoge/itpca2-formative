namespace Bakery_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        /*  ======================
                Helper methods
            ======================  */
        static string GetValidStringInput(string prompt)
        {
            do
            {
                try
                {
                    Console.Write($"{prompt}: ");
                    string? input = Console.ReadLine()?.Trim();

                    if (string.IsNullOrWhiteSpace(input)) // if input is empty
                    {
                        Console.Write(
                            "\nError: Input cannot be empty. \nPress Enter to try again... "
                        );
                        Console.ReadLine();
                        Console.WriteLine();
                    }
                    else if (input.Any(char.IsDigit)) // if input contains numbers
                    {
                        Console.Write(
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
                catch (IOException ex) // if there is an error reading input
                {
                    Console.Write(
                        $"\nError reading input: {ex.Message}. \nPress Enter to try again... "
                    );
                    Console.ReadLine();
                    Console.WriteLine();
                }
                catch (OutOfMemoryException) // if input is too large
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
            while (true)
            {
                try
                {
                    Console.Write($"{prompt}: ");
                    string? input = Console.ReadLine()?.Trim();

                    if (string.IsNullOrWhiteSpace(input)) // if input is empty
                    {
                        Console.Write(
                            "\nError: Input cannot be empty. \nPress Enter to try again... "
                        );
                        Console.ReadLine();
                        Console.WriteLine();
                    }
                    else if (maxLength.HasValue && input.Length > maxLength.Value) // if input exceeds max length
                    {
                        Console.Write(
                            $"\nError: Input must not exceed {maxLength.Value} digits. \nPress Enter to try again... "
                        );
                        Console.ReadLine();
                        Console.WriteLine();
                    }
                    else if (int.TryParse(input, out int result))
                    {
                        if (result < minValue || result > maxValue) // if input is out of range
                        {
                            Console.Write(
                                $"\nError: Please enter a number between {minValue} and {maxValue}. \nPress Enter to try again... "
                            );
                            Console.ReadLine();
                            Console.WriteLine();
                        }
                        else
                        {
                            return result;
                        }
                    }
                    else // if input is not a valid integer
                    {
                        Console.Write(
                            "\nError: Please enter a valid whole number. \nPress Enter to try again... "
                        );
                        Console.ReadLine();
                        Console.WriteLine();
                    }
                }
                catch (IOException ex) // if there is an error reading input
                {
                    Console.Write(
                        $"\nError reading input: {ex.Message}. \nPress Enter to try again... "
                    );
                    Console.ReadLine();
                    Console.WriteLine();
                }
                catch (OutOfMemoryException) // if input is too large
                {
                    Console.Write("\nError: Input is too large. \nPress Enter to try again... ");
                    Console.ReadLine();
                    Console.WriteLine();
                }
            }
        }
    }
}
