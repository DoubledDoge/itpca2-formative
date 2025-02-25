namespace Hotel_Reservation_System
{
    public static class HotelReservationSystem
    {
        static List<Room> rooms = Room.GetRooms();
        static List<Reservation> reservations = Reservation.GetReservations();

        /*  ======================
                Main methods
            ======================  */

        public static bool HandleCLIMenu()
        {
            Console.WriteLine(
                "============== Hotel Reservation System CLI Menu ==========\n\n"
                    + "1. Book Room\n"
                    + "2. Check-in Guest\n"
                    + "3. Check-out Guest\n"
                    + "4. View Available Rooms\n"
                    + "5. View Reservation History\n"
                    + "0. Exit\n\n"
                    + "==========================================================\n"
            );

            int choice = InputValidator.GetValidIntInput("Enter your choice (0-5)", 0, 5);
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    BookRoom();
                    break;
                case 2:
                    CheckInGuest();
                    break;
                case 3:
                    CheckOutGuest();
                    break;
                case 4:
                    ViewAvailableRooms();
                    break;
                case 5:
                    ViewReservationHistory();
                    break;
                case 0:
                    Console.WriteLine("Exiting Hotel Reservation System...\n");
                    return false;
                default:
                    Console.WriteLine("How did you get that? Invalid choice. Please try again.\n");
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
                    Console.WriteLine(
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
                    Console.WriteLine("\nCheck-out date must be after check-in date.\n");
                }
                else if (checkInDate < DateTime.Today)
                {
                    Console.WriteLine("\nCheck-in date cannot be in the past.\n");
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

            Console.Write(
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
                Console.Write(
                    $"\nNo reservation found for {guest.FullName} in room {roomNumber}.\nPress Enter to continue..."
                );
                Console.ReadLine();
                return;
            }

            var room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

            if (room == null)
            {
                Console.Write($"\nRoom {roomNumber} does not exist.\nPress Enter to continue...");
                Console.ReadLine();
                return;
            }

            if (room.IsCheckedIn)
            {
                Console.Write(
                    $"\nGuest {guest.FullName} is already checked into room {roomNumber}.\nPress Enter to continue..."
                );
                Console.ReadLine();
                return;
            }

            room.IsCheckedIn = true;

            Console.Write(
                $"\nGuest {guest.FullName} has been checked into room {roomNumber}.\nPress Enter to continue..."
            );
            Console.ReadLine();
        }

        static void CheckOutGuest()
        {
            int roomNumber = InputValidator.GetValidIntInput("Enter room number");
            var room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber); // Find the room

            if (room == null)
            {
                Console.Write($"\nRoom {roomNumber} does not exist.\nPress Enter to continue...");
                Console.ReadLine();
                return;
            }

            if (!room.IsCheckedIn)
            {
                Console.Write(
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

            Console.Write(
                $"\nRoom {roomNumber} has been checked out and is now available for new guests.\nPress Enter to continue..."
            );
            Console.ReadLine();
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
        }

        static void ViewReservationHistory()
        {
            Console.WriteLine("Reservation History:\n");
            if (reservations.Count == 0)
            {
                Console.WriteLine("No reservations found.");
            }
            else
            {
                foreach (var reservation in reservations)
                {
                    Console.WriteLine(
                        $"Room Number: {reservation.RoomNumber}, Guest: {reservation.GuestFullName}, From: {reservation.CheckInDate:dd/MM/yyyy}, To: {reservation.CheckOutDate:dd/MM/yyyy}"
                    );
                }
            }
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}
