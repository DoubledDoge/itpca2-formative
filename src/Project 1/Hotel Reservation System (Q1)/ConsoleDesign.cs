namespace Hotel_Reservation_System
{
    public static class ConsoleDesign
    {
        public static void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message);
            Console.ResetColor();
            return;
        }

        public static void WriteSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(message);
            Console.ResetColor();
            return;
        }

        public static void WriteMenu(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(message);
            Console.ResetColor();
            return;
        }

        public static void WriteHeader(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(message);
            Console.ResetColor();
        }
    }
}
