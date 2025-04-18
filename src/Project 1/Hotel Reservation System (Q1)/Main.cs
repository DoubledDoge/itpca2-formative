namespace Hotel_Reservation_System
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Console.Title = "GrandStay Hotel Reservation System";

            Console.WriteLine(
                "=======================================\n"
                    + "      Welcome to GrandStay Hotel!\n"
                    + "=======================================\n"
            );

            bool isRunning;

            // Simulate loading (Very optional animation for fun)
            ShowLoadingAnimation();
            do
            {
                isRunning = HotelReservationSystem.HandleCliMenu();
            } while (isRunning);

            ConsoleDesign.WriteSuccess(
                "Thank you for using GrandStay Hotel Reservation System!\nPress Enter to exit..."
            );
            Console.ReadLine();
            return;
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
            return;
        }
    }
}
