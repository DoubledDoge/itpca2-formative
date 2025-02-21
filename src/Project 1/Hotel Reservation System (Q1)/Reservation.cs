namespace Hotel_Reservation_System
{
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

        public static List<Reservation> GetReservations()
        {
            return new List<Reservation>();
        }
    }
}
