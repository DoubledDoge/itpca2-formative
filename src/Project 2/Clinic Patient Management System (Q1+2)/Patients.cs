namespace Clinic_Patient_Management_System
{
    public class Patient(string fullName, int age, string medCondition)
    {
        public string FullName { get; } = fullName;
        public int Age { get; } = age;
        public string MedCondition { get; } = medCondition;

        public static List<Patient> GetPatients()
        {
            return
            [
                new Patient("Sarah Mokoena", 34, "Hypertension"),
                new Patient("Thando Ndlovu", 29, "Asthma"),
                new Patient("Sipho Khumalo", 45, "Diabetes"),
            ];
        }
    }
}
