namespace Clinic_Patient_Management_System
{
    static class MainClass
    {
        private static void Main()
        {
            Console.Title = "RANDS Clinic Patient Management System";

            // Header
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(
                "==================================\n"
                    + "      RANDS Health Clinic\n"
                    + "==================================\n\n"
            );
            Console.ResetColor();

            bool isRunning;
            Console.WriteLine("Welcome to RANDS Clinic Patient Management System!\n");

            ShowLoadingAnimation();
            do
            {
                isRunning = PatientManagementSystem.HandleCliMenu();
            } while (isRunning);

            ConsoleDesign.WriteSuccess(
                "Thank you for using RANDS Clinic Patient Management System!\nPress Enter to exit..."
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
