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
            // The rest remain null as to be added by the user
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
            // Check if there is space for a new patient
            int index = Array.FindIndex(Patients, p => p == null);
            if (index == -1)
            {
                ConsoleDesign.WriteError("Patient list is full. Cannot add more patients.\n");
                Console.Write("Press Enter to continue...");
                Console.ReadLine();
                return;
            }

            // Get patient details from user
            string fullName = InputValidator.GetValidStringInput("Enter patient's full name");
            int age = InputValidator.GetValidIntInput("Enter patient's age", 0, 120);
            string medCondition = InputValidator.GetValidStringInput(
                "Enter patient's medical condition"
            );
            Patients[index] = new Patient(fullName, age, medCondition);

            // Display success message
            ConsoleDesign.WriteSuccess($"\nPatient '{fullName}' added successfully!\n");
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        }

        private static void RemovePatient()
        {
            int count = Patients.Count(p => p != null);

            // Create a map of patient numbers to their array indices
            var num = 1;
            var map = new int[count];

            // Check if there are any patients to remove
            if (count == 0)
            {
                ConsoleDesign.WriteError("No patients to remove.\n");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                return;
            }

            // Display patients with numbers
            Console.WriteLine("Registered Patients:\n");
            Console.WriteLine($"{"No.", -5}{"Name", -25}{"Age", -5}{"Condition", -20}");
            for (int i = 0; i < Patients.Length; i++)
            {
                if (Patients[i] != null)
                {
                    Console.WriteLine(
                        $"{num, -5}{Patients[i]?.FullName, -25}{Patients[i]!.Age, -5}{Patients[i]!.MedCondition, -20}"
                    );
                    map[num - 1] = i;
                    num++;
                }
            }

            // Get the number of the patient to remove
            int toRemove = InputValidator.GetValidIntInput(
                $"Enter the number of the patient to remove (1-{count})",
                1,
                count
            );

            // Validate the input
            int arrayIndex = map[toRemove - 1];
            var removedPatient = Patients[arrayIndex];
            Patients[arrayIndex] = null;

            // Display success message
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
                ConsoleDesign.WriteSuccess($"\nFound {matches.Count} patient(s):\n");
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
            var activePatients = Patients.Where(p => p != null).ToList();

            if (!activePatients.Any())
            {
                ConsoleDesign.WriteError("No patient records to display.");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Registered Patients:\n");
            Console.WriteLine($"{"No.", -5}{"Name", -25}{"Age", -5}{"Condition", -20}");

            for (var i = 0; i < activePatients.Count; i++)
            {
                var patient = activePatients[i];
                Console.WriteLine(
                    $"{i + 1, -5}{patient!.FullName, -25}{patient.Age, -5}{patient.MedCondition, -20}"
                );
            }

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
