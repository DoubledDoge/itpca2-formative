namespace Hotel_Reservation_System
{
    class Program
    {
        static List<Room> rooms = Room.GetRooms();
        static List<Reservation> reservations = Reservation.GetReservations();

        /*  ======================
                Main methods
            ======================  */

        static bool HandleCLIMenu()
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

            int choice = GetValidIntInput("Enter your choice (0-5)", 0, 5);
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
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }
            return true;
        }

        static void BookRoom()
        {
            string guestFullName = GetValidStringInput("Enter guest full name");

            Room roomToBook;
            do
            {
                int roomTypeChoice;
                string roomType;

                roomTypeChoice = GetValidIntInput(
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
                checkInDate = GetValidDateInput("Enter Check-in date");
                checkOutDate = GetValidDateInput("Enter Check-out date");

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
                guestFullName,
                checkInDate,
                checkOutDate
            );
            reservations.Add(reservation);

            roomToBook.IsAvailable = false;

            Console.Write(
                $"\nRoom {roomToBook.RoomNumber} booked for {guestFullName} from {checkInDate} to {checkOutDate}.\nPress Enter to continue..."
            );
            Console.ReadLine();
            return;
        }

        static void CheckInGuest()
        {
            string guestFullName = GetValidStringInput("Enter guest full name");
            int roomNumber = GetValidIntInput("Enter room number");

            // Find the reservation
            var reservation = reservations.FirstOrDefault(r =>
                string.Equals(r.GuestFullName, guestFullName, StringComparison.OrdinalIgnoreCase)
                && r.RoomNumber == roomNumber
            );

            if (reservation == null)
            {
                Console.Write(
                    $"\nNo reservation found for {guestFullName} in room {roomNumber}.\nPress Enter to continue..."
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
                    $"\nGuest {guestFullName} is already checked into room {roomNumber}.\nPress Enter to continue..."
                );
                Console.ReadLine();
                return;
            }

            room.IsCheckedIn = true;

            Console.Write(
                $"\nGuest {guestFullName} has been checked into room {roomNumber}.\nPress Enter to continue..."
            );
            Console.ReadLine();
        }

        static void CheckOutGuest()
        {
            int roomNumber = GetValidIntInput("Enter room number");
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
                        $"Room Number: {reservation.RoomNumber}, Guest: {reservation.GuestFullName}, From: {reservation.CheckInDate}, To: {reservation.CheckOutDate}"
                    );
                }
            }
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        }

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
                isRunning = HandleCLIMenu();
            } while (isRunning);

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

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.Write(
                            "\nError: Input cannot be empty. \nPress Enter to try again... "
                        );
                        Console.ReadLine();
                        Console.WriteLine();
                    }
                    else if (input.Any(char.IsDigit))
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
                catch (IOException ex)
                {
                    Console.Write(
                        $"\nError reading input: {ex.Message}. \nPress Enter to try again... "
                    );
                    Console.ReadLine();
                    Console.WriteLine();
                }
                catch (OutOfMemoryException)
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

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.Write(
                            "\nError: Input cannot be empty. \nPress Enter to try again... "
                        );
                        Console.ReadLine();
                        Console.WriteLine();
                    }
                    else if (maxLength.HasValue && input.Length > maxLength.Value)
                    {
                        Console.Write(
                            $"\nError: Input must not exceed {maxLength.Value} digits. \nPress Enter to try again... "
                        );
                        Console.ReadLine();
                        Console.WriteLine();
                    }
                    else if (int.TryParse(input, out int result))
                    {
                        if (result < minValue || result > maxValue)
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
                    else
                    {
                        Console.Write(
                            "\nError: Please enter a valid whole number. \nPress Enter to try again... "
                        );
                        Console.ReadLine();
                        Console.WriteLine();
                    }
                }
                catch (IOException ex)
                {
                    Console.Write(
                        $"\nError reading input: {ex.Message}. \nPress Enter to try again... "
                    );
                    Console.ReadLine();
                    Console.WriteLine();
                }
                catch (OutOfMemoryException)
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
