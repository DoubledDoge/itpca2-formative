namespace Hotel_Reservation_System
{
    class Guest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Guest(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FullName => $"{FirstName} {LastName}";
    }
}
