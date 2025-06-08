namespace Clinic_Patient_Management_System
{
    public class Patient(string fullName, int age, string medCondition)
    {
        public string FullName { get; } = fullName;
        public int Age { get; } = age;
        public string MedCondition { get; } = medCondition;

        // Add 10 sample patients from seperate array of size 10
        public static Patient[] GetSamplePatients()
        {
            Patient[] samplePatients = new Patient[10];

            samplePatients[0] = new Patient("Sarah Mokoena", 34, "Hypertension");
            samplePatients[1] = new Patient("Thando Ndlovu", 29, "Asthma");
            samplePatients[2] = new Patient("Nomsa Dlamini", 41, "Diabetes");
            samplePatients[3] = new Patient("Kabelo Molefe", 37, "High Cholesterol");
            samplePatients[4] = new Patient("Lerato Khumalo", 22, "Flu");
            samplePatients[5] = new Patient("Siphiwe Ntuli", 60, "Arthritis");
            samplePatients[6] = new Patient("Ayanda Zulu", 19, "Migraine");
            samplePatients[7] = new Patient("Boitumelo Mthembu", 28, "Allergies");
            samplePatients[8] = new Patient("Tshepo Mabena", 45, "Back Pain");
            samplePatients[9] = new Patient("Zanele Hlophe", 33, "Anxiety");

            return samplePatients;
        }
    }
}
