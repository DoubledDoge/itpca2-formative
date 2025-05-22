namespace Clinic_Patient_Management_System
{
    public static class PatientManagementSystem
    {
        private static readonly Patient?[] Patients;

        static PatientManagementSystem()
        {
            Patients = new Patient[25];
            var samplePatients = Patient.GetSamplePatients();
            for (int i = 0; i < samplePatients.Length; i++)
            {
                Patients[i] = samplePatients[i];
            }
            // The rest remain null to be added
        }

        public static bool HandleCliMenu()
        {
            ConsoleDesign.WriteHeader("=================== Main Menu ===================\n\n");
            ConsoleDesign.WriteMenu(
                "  1. Add Patient\n"
                    + "  2. Remove Patient\n"
                    + "  3. Search Patient\n"
                    + "  4. Display All Patients\n"
                    + "  5. Print Patient Information to File\n"
                    + "  6. Exit\n\n"
            );
            ConsoleDesign.WriteHeader("=================================================\n\n");

            int choice = InputValidator.GetValidIntInput("Enter your choice (1-6)", 1, 6);
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    AddPatient();
                    WaitAndClear();
                    break;
                case 2:
                    RemovePatient();
                    WaitAndClear();
                    break;
                case 3:
                    SearchPatient();
                    WaitAndClear();
                    break;
                case 4:
                    DisplayAllPatients();
                    WaitAndClear();
                    break;
                case 5:
                    FileManagement.PrintPatientInfoToFile(
                        Patients.Where(p => p != null).Cast<Patient>().ToList()
                    );
                    WaitAndClear();
                    break;
                case 6:
                    Console.WriteLine("Exiting Patient Management System..\n");
                    return false;
                default:
                    ConsoleDesign.WriteError(
                        "How did you get that? Invalid choice. Please try again.\n"
                    );
                    break;
            }
            return true;
        }

        private static void AddPatient()
        {
            int index = Array.FindIndex(Patients, p => p == null);
            if (index == -1)
            {
                ConsoleDesign.WriteError("Patient list is full. Cannot add more patients.\n");
                Console.Write("Press Enter to continue...");
                Console.ReadLine();
                return;
            }
            string fullName = InputValidator.GetValidStringInput("Enter patient's full name");
            int age = InputValidator.GetValidIntInput("Enter patient's age", 0, 120);
            string medCondition = InputValidator.GetValidStringInput(
                "Enter patient's medical condition"
            );
            Patients[index] = new Patient(fullName, age, medCondition);
            ConsoleDesign.WriteSuccess($"\nPatient '{fullName}' added successfully!\n");
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        }

        private static void RemovePatient()
        {
            int count = Patients.Count(p => p != null);
            if (count == 0)
            {
                ConsoleDesign.WriteError("No patients to remove.\n");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                return;
            }
            // Display patients with numbers
            Console.WriteLine("Registered Patients:\n");
            ConsoleDesign.WriteHeader("================================================");
            Console.WriteLine($"{"No.", -5}{"Name", -25}{"Age", -5}{"Condition", -20}");
            ConsoleDesign.WriteHeader("================================================");
            int shown = 1;
            int[] map = new int[count];
            for (int i = 0; i < Patients.Length; i++)
            {
                if (Patients[i] != null)
                {
                    Console.WriteLine(
                        $"{shown, -5}{Patients[i]!.FullName, -25}{Patients[i]!.Age, -5}{Patients[i]!.MedCondition, -20}"
                    );
                    map[shown - 1] = i;
                    shown++;
                }
            }
            ConsoleDesign.WriteHeader("================================================\n");
            int toRemove = InputValidator.GetValidIntInput(
                $"Enter the number of the patient to remove (1-{count})",
                1,
                count
            );
            int arrayIndex = map[toRemove - 1];
            var removedPatient = Patients[arrayIndex];
            Patients[arrayIndex] = null;
            ConsoleDesign.WriteSuccess(
                $"\nPatient '{removedPatient!.FullName}' removed successfully!\n"
            );
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        }

        private static void SearchPatient()
        {
            // Check if there are any patients
            int count = Patients.Count(p => p != null);
            if (count == 0)
            {
                ConsoleDesign.WriteError("No patients to search.\n");
                Console.Write("Press Enter to continue...");
                Console.ReadLine();
                return;
            }

            // Get search term from user
            string searchTerm = InputValidator.GetValidStringInput(
                "Enter patient name or part of name to search"
            );

            // Search for patients matching the search term
            var matches = Patients
                .Where(p =>
                    p != null && p.FullName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                )
                .ToList();

            // Display results
            if (matches.Count == 0)
            {
                ConsoleDesign.WriteError("Patient not found.\n");
            }
            else
            {
                Console.WriteLine($"\nFound {matches.Count} patient(s):\n");
                int shown = 1;
                foreach (var patient in matches)
                {
                    Console.WriteLine(
                        $"{shown, -5}{patient!.FullName, -25}{patient.Age, -5}{patient.MedCondition, -20}"
                    );
                    shown++;
                }
            }
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        }

        private static void DisplayAllPatients()
        {

            // Check if there are any patients
            int count = Patients.Count(p => p != null);
            if (count == 0)
            {
                ConsoleDesign.WriteError("No patient records to display.");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                return;
            }

            // Display all patients
            Console.WriteLine("Registered Patients:\n");
            ConsoleDesign.WriteHeader("================================================");
            Console.WriteLine($"{"No.", -5}{"Name", -25}{"Age", -5}{"Condition", -20}");
            ConsoleDesign.WriteHeader("================================================");
            int shown = 1;
            for (int i = 0; i < Patients.Length; i++)
            {
                if (Patients[i] != null)
                {
                    Console.WriteLine(
                        $"{shown, -5}{Patients[i]!.FullName, -25}{Patients[i]!.Age, -5}{Patients[i]!.MedCondition, -20}"
                    );
                    shown++;
                }
            }
            ConsoleDesign.WriteHeader("================================================\n");
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        }

        private static void WaitAndClear()
        {
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}
