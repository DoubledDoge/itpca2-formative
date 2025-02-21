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

        public static List<Room> GetRooms()
        {
            return new List<Room>
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
        }
    }
}
