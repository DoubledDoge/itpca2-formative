namespace Drone_Racing_System
{
    static class MainClass
    {
        private static async Task Main()
        {
            Console.Title = "BuzzBets Drone Racing System";

            // Header
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(
                "==================================\n" +
                "     BuzzBets Racing System\n" +
                "==================================\n"
            );
            Console.ResetColor();

            var continueRacing = true;
            ConsoleDesign.WriteHeader("Welcome to BuzzBets Drone Racing System!\n");
            Console.WriteLine("Where Velocity Meets Fortune.\n");


            while (continueRacing)
            {
                // Perform the race procedures
                ShowLoadingAnimation();
                await RaceManager.StartRace();

                // Ask user for another race
                Console.WriteLine("\n" + "=".PadLeft(50, '='));
                var response = InputValidator.GetValidStringInput("Would you like to race again? (y/n)");

                // Determine if user wants another race based on their input
                continueRacing = response is "y" or "yes" or "Y" or "Yes";

                if (continueRacing)
                {
                    Console.Clear();
                    ConsoleDesign.WriteHeader("Starting New Race!\n\n");
                }
            }

            Console.WriteLine("\nThank you for using BuzzBets Drone Racing System!");
            Console.Write("Press Enter to exit...");
            Console.ReadLine();
        }

        private static void ShowLoadingAnimation()
        {
            Console.Write("\nLoading system");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);
                Console.Write(".");
            }
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}
