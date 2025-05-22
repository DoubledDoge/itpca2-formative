namespace Clinic_Patient_Management_System
{
    public class Patient(string fullName, int age, string medCondition)
    {
        public string FullName { get; } = fullName;
        public int Age { get; } = age;
        public string MedCondition { get; } = medCondition;

        public static Patient[] GetSamplePatients()
        {
            return
            [
                new Patient("Sarah Mokoena", 34, "Hypertension"),
                new Patient("Thando Ndlovu", 29, "Asthma"),
                new Patient("Nomsa Dlamini", 41, "Diabetes"),
                new Patient("Kabelo Molefe", 37, "High Cholesterol"),
                new Patient("Lerato Khumalo", 22, "Flu"),
                new Patient("Siphiwe Ntuli", 60, "Arthritis"),
                new Patient("Ayanda Zulu", 19, "Migraine"),
                new Patient("Boitumelo Mthembu", 28, "Allergies"),
                new Patient("Tshepo Mabena", 45, "Back Pain"),
                new Patient("Zanele Hlophe", 33, "Anxiety"),
            ];
        }
    }
}
