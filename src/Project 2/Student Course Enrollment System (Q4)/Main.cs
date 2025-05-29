namespace Student_Course_Enrollment_System
{
    static class MainClass
    {
        private static void Main()
        {
            Console.Title = "Student Course Enrollment System";

            // Header
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(
                "==================================\n"
                    + "Student Course Enrollment System\n"
                    + "==================================\n\n"
            );
            Console.ResetColor();

            bool isRunning;
            Console.WriteLine("Welcome to the Student Course Enrollment System!\n");

            ShowLoadingAnimation();
            do
            {
                isRunning = StudentEnrollmentSystem.HandleCliMenu();
            } while (isRunning);

            ConsoleDesign.WriteSuccess(
                "Thank you for using our Student Course Enrollment System!\nPress Enter to exit..."
            );
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
