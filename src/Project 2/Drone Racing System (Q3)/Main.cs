namespace Drone_Racing_System
{
    static class MainClass
    {
        private static void Main()
        {
            Console.Title = "BuzzBets Drone Racing System";
            Console.CursorVisible = false;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.ResetColor();
            Console.WriteLine(
                "==================================\n"
                + "     BuzzBets Exchange System\n"
                + "==================================\n\n"
            );

            Console.WriteLine("Welcome to BuzzBets Drone Racing System!\n");
            Console.WriteLine("Where Velocity Meets Fortune.\n");

            ShowLoadingAnimation();

            Console.WriteLine("\nThank you for using BuzzBets Drone Racing System!");
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }

        private static void ShowLoadingAnimation()
        {
            Console.Write("\nLoading system");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(700);
                Console.Write(".");
            }
            Thread.Sleep(700);
            Console.Clear();
        }
    }
}
