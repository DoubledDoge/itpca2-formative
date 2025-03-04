namespace Hotel_Reservation_System
{
    public static class HotelReservationSystem
    {
        static List<Room> rooms = Room.GetRooms();
        static List<Reservation> reservations = Reservation.GetReservations();

        public static bool HandleCLIMenu()
        {
            ConsoleDesign.WriteHeader("==================== Main Menu ===================\n\n");
            ConsoleDesign.WriteMenu(
                "  1. Book Room\n"
                    + "  2. Check-in Guest\n"
                    + "  3. Check-out Guest\n"
                    + "  4. View Available Rooms\n"
                    + "  5. View Reservation History\n"
                    + "  0. Exit\n\n"
            );
            ConsoleDesign.WriteHeader("====================================================\n\n");

            int choice = InputValidator.GetValidIntInput("Enter your choice (0-5)", 0, 5);
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    BookRoom();
                    WaitAndClear();
                    break;
                case 2:
                    CheckInGuest();
                    WaitAndClear();
                    break;
                case 3:
                    CheckOutGuest();
                    WaitAndClear();
                    break;
                case 4:
                    ViewAvailableRooms();
                    WaitAndClear();
                    break;
                case 5:
                    ViewReservationHistory();
                    WaitAndClear();
                    break;
                case 0:
                    Console.WriteLine("Exiting Hotel Reservation System...\n");
                    return false;
                default:
                    ConsoleDesign.WriteError(
                        "How did you get that? Invalid choice. Please try again.\n"
                    );
                    Console.Clear();
                    break;
            }
            return true;
        }

        static void BookRoom()
        {
            string firstName = InputValidator.GetValidStringInput("Enter guest first name");
            string lastName = InputValidator.GetValidStringInput("Enter guest last name");
            Guest guest = new Guest(firstName, lastName);

            Room roomToBook;
            do
            {
                int roomTypeChoice;
                string roomType;

                roomTypeChoice = InputValidator.GetValidIntInput(
                    "Enter room type to book (1: Single, 2: Double, 3: Suite)",
                    1,
                    3
                );

                roomType = roomTypeChoice switch
                {
                    1 => "Single",
                    2 => "Double",
                    3 => "Suite",
                    _ => throw new InvalidOperationException(
                        "How did you get that? Invalid number."
                    ),
                };

                // Find the first available room of the chosen type
                roomToBook =
                    rooms.FirstOrDefault(r => r.RoomType == roomType && r.IsAvailable)
                    ?? throw new InvalidOperationException(
                        "No available rooms of the selected type."
                    ); // Throw exception if no available rooms of the selected type

                if (roomToBook == null)
                {
                    ConsoleDesign.WriteError(
                        "No available rooms of the selected type. Please choose another type.\n"
                    );
                }
            } while (roomToBook == null);

            DateTime checkInDate;
            DateTime checkOutDate;
            do
            {
                checkInDate = InputValidator.GetValidDateInput("Enter Check-in date");
                checkOutDate = InputValidator.GetValidDateInput("Enter Check-out date");

                if (checkInDate >= checkOutDate)
                {
                    ConsoleDesign.WriteError("\nCheck-out date must be after check-in date.\n");
                }
                else if (checkInDate < DateTime.Today)
                {
                    ConsoleDesign.WriteError("\nCheck-in date cannot be in the past.\n");
                }
            } while (checkInDate >= checkOutDate || checkInDate < DateTime.Today);

            var reservation = new Reservation(
                roomToBook.RoomNumber,
                guest.FullName,
                checkInDate,
                checkOutDate
            );
            reservations.Add(reservation);

            roomToBook.IsAvailable = false;

            ConsoleDesign.WriteSuccess(
                $"\nRoom {roomToBook.RoomNumber} booked for {guest.FullName} from {checkInDate:dd/MM/yyyy} to {checkOutDate:dd/MM/yyyy}.\nPress Enter to continue..."
            );
            Console.ReadLine();
            return;
        }

        static void CheckInGuest()
        {
            string firstName = InputValidator.GetValidStringInput("Enter guest first name");
            string lastName = InputValidator.GetValidStringInput("Enter guest last name");
            Guest guest = new Guest(firstName, lastName);
            int roomNumber = InputValidator.GetValidIntInput("Enter room number");

            // Find the reservation
            var reservation = reservations.FirstOrDefault(r =>
                string.Equals(r.GuestFullName, guest.FullName, StringComparison.OrdinalIgnoreCase)
                && r.RoomNumber == roomNumber
            );

            if (reservation == null)
            {
                ConsoleDesign.WriteError(
                    $"\nNo reservation found for {guest.FullName} in room {roomNumber}.\nPress Enter to continue..."
                );
                Console.ReadLine();
                return;
            }

            var room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

            if (room == null)
            {
                ConsoleDesign.WriteError(
                    $"\nRoom {roomNumber} does not exist.\nPress Enter to continue..."
                );
                Console.ReadLine();
                return;
            }

            if (room.IsCheckedIn)
            {
                ConsoleDesign.WriteError(
                    $"\nGuest {guest.FullName} is already checked into room {roomNumber}.\nPress Enter to continue..."
                );
                Console.ReadLine();
                return;
            }

            room.IsCheckedIn = true;

            ConsoleDesign.WriteSuccess(
                $"\nGuest {guest.FullName} has been checked into room {roomNumber}.\nPress Enter to continue..."
            );
            Console.ReadLine();
            return;
        }

        static void CheckOutGuest()
        {
            int roomNumber = InputValidator.GetValidIntInput("Enter room number");
            var room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber); // Find the room

            if (room == null)
            {
                ConsoleDesign.WriteError(
                    $"\nRoom {roomNumber} does not exist.\nPress Enter to continue..."
                );
                Console.ReadLine();
                return;
            }

            if (!room.IsCheckedIn)
            {
                ConsoleDesign.WriteError(
                    $"\nRoom {roomNumber} is not currently checked in.\nPress Enter to continue..."
                );
                Console.ReadLine();
                return;
            }

            // Find the reservation
            var reservation = reservations.FirstOrDefault(r => r.RoomNumber == roomNumber);

            if (reservation != null)
            {
                reservations.Remove(reservation);
            }

            room.IsCheckedIn = false;
            room.IsAvailable = true;

            ConsoleDesign.WriteSuccess(
                $"\nRoom {roomNumber} has been checked out and is now available for new guests.\nPress Enter to continue..."
            );
            Console.ReadLine();
            return;
        }

        static void ViewAvailableRooms()
        {
            // Display available rooms
            Console.WriteLine("Available Rooms:\n");
            foreach (var room in rooms.Where(r => r.IsAvailable))
            {
                Console.WriteLine($"Room: {room.RoomNumber} - {room.RoomType}\n");
            }
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
            return;
        }

        static void ViewReservationHistory()
        {
            Console.WriteLine("Reservation History:\n");
            if (reservations.Count == 0)
            {
                ConsoleDesign.WriteError("No reservations found.\nPress Enter to continue...");
            }
            else
            {
                foreach (var reservation in reservations)
                {
                    Console.Write(
                        $"Room Number: {reservation.RoomNumber}, Guest: {reservation.GuestFullName}, From: {reservation.CheckInDate:dd/MM/yyyy}, To: {reservation.CheckOutDate:dd/MM/yyyy}\nPress Enter to continue..."
                    );
                }
            }
            Console.ReadLine();
            return;
        }

        static void WaitAndClear()
        {
            Thread.Sleep(1000);
            Console.Clear();
            return;
        }
    }
}
