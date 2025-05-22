namespace Clinic_Patient_Management_System
{
    public static class FileManagement
    {
        public static void PrintPatientInfoToFile(List<Patient> patients)
        {
            const string filePath = "patient_information.txt";

            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                writer.WriteLine("Registered Patients:\n");
                writer.WriteLine("===========================================");
                writer.WriteLine($"{"Name",-25}{"Age",-5}{"Condition",-20}");
                writer.WriteLine("===========================================");

                foreach (var patient in patients)
                {
                    writer.WriteLine($"{patient.FullName,-25}{patient.Age,-5}{patient.MedCondition,-20}");
                }
            }

            ConsoleDesign.WriteSuccess($"\nPatient information printed to {Path.GetFullPath(filePath)}.\n");
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}
