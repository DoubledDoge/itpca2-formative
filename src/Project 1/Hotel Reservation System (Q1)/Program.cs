namespace Hotel_Reservation_System
{
    class Room
    {
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsCheckedIn { get; set; }

        public Room(int roomNumber, string roomType)
        {
            RoomNumber = roomNumber;
            RoomType = roomType;
            IsAvailable = true;
            IsCheckedIn = false;
        }
    }

    class Reservation
    {
        public int RoomNumber { get; set; }
        public string GuestFullName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public Reservation(
            int roomNumber,
            string guestFullName,
            DateTime checkInDate,
            DateTime checkOutDate
        )
        {
            RoomNumber = roomNumber;
            GuestFullName = guestFullName;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }
    }

    class Program
    {
        static List<Room> rooms = new List<Room>
        {
            new Room(101, "Single") { IsAvailable = true },
            new Room(102, "Single") { IsAvailable = false },
            new Room(103, "Single") { IsAvailable = true },
            new Room(104, "Single") { IsAvailable = false },
            new Room(105, "Single") { IsAvailable = true },
            new Room(201, "Double") { IsAvailable = true },
            new Room(202, "Double") { IsAvailable = false },
            new Room(203, "Double") { IsAvailable = true },
            new Room(204, "Double") { IsAvailable = false },
            new Room(205, "Double") { IsAvailable = true },
            new Room(301, "Suite") { IsAvailable = true },
            new Room(302, "Suite") { IsAvailable = false },
            new Room(303, "Suite") { IsAvailable = true },
            new Room(304, "Suite") { IsAvailable = false },
            new Room(305, "Suite") { IsAvailable = true },
        };

        static List<Reservation> reservations = new List<Reservation>();

        /*  ======================
                Main methods
            ======================  */

        static bool HandleCLIMenu()
        {
            // Display CLI Menu
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

            // Get user input
            int choice = GetValidIntInput("Enter your choice (0-5)", 0, 5);
            Console.WriteLine();

            // Handle user choice
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
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }
            return true;
        }

        static void BookRoom()
        {
            // Get guest full name from user
            string guestFullName = GetValidStringInput("Enter guest full name");

            Room roomToBook;
            do
            {
                int roomTypeChoice;
                string roomType;

                /// Get room type from user
                roomTypeChoice = GetValidIntInput(
                    "Enter room type to book (1: Single, 2: Double, 3: Suite)",
                    1,
                    3
                );

                // Determine room type based on user choice
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
                    );

                // Display error message if no available rooms of the selected type
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
                // Get check-in and check-out dates
                checkInDate = GetValidDateInput("Enter Check-in date");
                checkOutDate = GetValidDateInput("Enter Check-out date");

                // Check if check in date is before check out date
                if (checkInDate >= checkOutDate)
                {
                    Console.WriteLine("\nCheck-out date must be after check-in date.\n");
                }
            } while (checkInDate >= checkOutDate);

            // Create reservation
            var reservation = new Reservation(
                roomToBook.RoomNumber,
                guestFullName,
                checkInDate,
                checkOutDate
            );
            reservations.Add(reservation); // Add reservation to list

            // Mark room as unavailable
            roomToBook.IsAvailable = false;

            // Display success message
            Console.Write(
                $"\nRoom {roomToBook.RoomNumber} booked for {guestFullName} from {checkInDate} to {checkOutDate}.\nPress Enter to continue..."
            );
            Console.ReadLine();
            return;
        }

        static void CheckInGuest()
        {
            // Get guest full name from user
            string guestFullName = GetValidStringInput("Enter guest full name");

            // Get room number from user
            int roomNumber = GetValidIntInput("Enter room number");

            // Find the reservation
            var reservation = reservations.FirstOrDefault(r =>
                string.Equals(r.GuestFullName, guestFullName, StringComparison.OrdinalIgnoreCase)
                && r.RoomNumber == roomNumber
            );

            // Check if reservation exists
            if (reservation == null)
            {
                Console.Write(
                    $"\nNo reservation found for {guestFullName} in room {roomNumber}.\nPress Enter to continue..."
                );
                Console.ReadLine();
                return;
            }

            // Find the room
            var room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

            // Check if room exists
            if (room == null)
            {
                Console.Write($"\nRoom {roomNumber} does not exist.\nPress Enter to continue...");
                Console.ReadLine();
                return;
            }

            // Check if the room is already checked in
            if (room.IsCheckedIn)
            {
                Console.Write(
                    $"\nGuest {guestFullName} is already checked into room {roomNumber}.\nPress Enter to continue..."
                );
                Console.ReadLine();
                return;
            }

            // Mark room as checked in
            room.IsCheckedIn = true;

            // Display success message
            Console.Write(
                $"\nGuest {guestFullName} has been checked into room {roomNumber}.\nPress Enter to continue..."
            );
            Console.ReadLine();
        }

        static void CheckOutGuest()
        {
            // Get room number from user
            int roomNumber = GetValidIntInput("Enter room number");

            // Find the room
            var room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

            // Check if room exists
            if (room == null)
            {
                Console.Write($"\nRoom {roomNumber} does not exist.\nPress Enter to continue...");
                Console.ReadLine();
                return;
            }

            // Check if the room is checked in
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

            // Remove the reservation if it exists
            if (reservation != null)
            {
                reservations.Remove(reservation);
            }

            // Mark room as checked out and available
            room.IsCheckedIn = false;
            room.IsAvailable = true;

            // Display success message
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
                        $"Room Number: {reservation.RoomNumber}, Guest: {reservation.GuestFullName}, From: {reservation.CheckInDate}, To: {reservation.CheckOutDate}"
                    );
                }
            }
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            // Entry point of the Hotel Reservation System
            Console.WriteLine(
                "=======================================\n"
                    + "      Welcome to GrandStay Hotel!\n"
                    + "=======================================\n"
            );

            bool isRunning;
            // Main loop of the program
            do
            {
                isRunning = HandleCLIMenu();
            } while (isRunning);

            // Exit message
            Console.Write(
                "Thank you for using GrandStay Hotel Reservation System!\nPress Enter to exit..."
            );
            Console.ReadLine();
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

                Console.WriteLine();
            } while (true);
        }

        static int GetValidIntInput(
            string prompt,
            int minValue = int.MinValue,
            int maxValue = int.MaxValue,
            int? maxLength = default
        )
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

                Console.WriteLine();
            } while (true);
        }

        static DateTime GetValidDateInput(string prompt)
        {
            do
            {
                try
                {
                    Console.Write($"{prompt} (dd/mm/yyyy): ");
                    string? input = Console.ReadLine()?.Trim();

                    if (
                        DateTime.TryParseExact(
                            input,
                            "dd/MM/yyyy",
                            null,
                            System.Globalization.DateTimeStyles.None,
                            out DateTime date
                        )
                    )
                    {
                        return date;
                    }
                    else
                    {
                        Console.Write(
                            "\nError: Please enter a valid date in the format dd/mm/yyyy. \nPress Enter to try again..."
                        );
                        Console.ReadLine();
                        Console.WriteLine();
                    }
                }
                catch (Exception ex)
                {
                    Console.Write($"\nError: {ex.Message}. \nPress Enter to try again...");
                    Console.ReadLine();
                    Console.WriteLine();
                }
            } while (true);
        }
    }
}
