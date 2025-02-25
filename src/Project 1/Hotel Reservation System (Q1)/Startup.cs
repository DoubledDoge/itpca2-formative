namespace Hotel_Reservation_System
{
    class Startup
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "=======================================\n"
                    + "      Welcome to GrandStay Hotel!\n"
                    + "=======================================\n"
            );

            bool isRunning;
            do
            {
                isRunning = HotelReservationSystem.HandleCLIMenu();
            } while (isRunning);

            Console.Write(
                "Thank you for using GrandStay Hotel Reservation System!\nPress Enter to exit..."
            );
            Console.ReadLine();
        }
    }
}
