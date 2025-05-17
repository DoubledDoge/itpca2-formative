namespace Clinic_Patient_Management_System
{
    public static class PatientManagementSystem
    {
        private static readonly List<Patient> Patients = Patient.GetPatients();

        public static bool HandleCliMenu()
        {
            ConsoleDesign.WriteHeader("=================== Main Menu ===================\n\n");
            ConsoleDesign.WriteMenu(
                "  1. Add Patient\n"
                    + "  2. Remove Patient\n"
                    + "  3. Search Patient\n"
                    + "  4. Display All Patients\n"
                    + "  5. Exit\n\n"
            );
            ConsoleDesign.WriteHeader("=================================================\n\n");

            int choice = InputValidator.GetValidIntInput("Enter your choice (1-5)", 1, 5);
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
            // Get patient details:
            string fullName = InputValidator.GetValidStringInput("Enter patient's full name");
            int age = InputValidator.GetValidIntInput("Enter patient's age", 0, 120);
            string medCondition = InputValidator.GetValidStringInput(
                "Enter patient's medical condition"
            );

            // Add patient to the list:
            var newPatient = new Patient(fullName, age, medCondition);
            Patients.Add(newPatient);

            // Display success message:
            ConsoleDesign.WriteSuccess($"\nPatient '{fullName}' added successfully!\n");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        private static void RemovePatient()
        {
            // Check if there are any patients to remove:
            if (Patients.Count == 0)
            {
                ConsoleDesign.WriteError("No patients to remove.\n");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                return;
            }

            // Display all patients:
            DisplayAllPatients();

            // Get the patient number to remove:
            int toRemove = InputValidator.GetValidIntInput(
                $"Enter the number of the patient to remove (1-{Patients.Count})",
                1,
                Patients.Count
            );
            var removedPatient = Patients[toRemove - 1];

            // Remove the patient from the list:
            Patients.RemoveAt(toRemove - 1);

            // Display success message:
            ConsoleDesign.WriteSuccess(
                $"\nPatient '{removedPatient.FullName}' removed successfully!\n"
            );
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        private static void SearchPatient()
        {
            // Check if there are any patients to search:
            if (Patients.Count == 0)
            {
                ConsoleDesign.WriteError("No patients to search.\n");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                return;
            }

            // Get the search term:
            string searchTerm = InputValidator.GetValidStringInput(
                "Enter patient name or part of name to search"
            );

            // Search for patients:
            var matches = Patients
                .Where(p => p.FullName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();

            // Display search results:
            if (matches.Count == 0)
            {
                ConsoleDesign.WriteError($"No patients found matching '{searchTerm}'.\n");
            }
            else
            {
                Console.WriteLine($"\nFound {matches.Count} patient(s):\n");
                ConsoleDesign.WriteHeader("================================================");
                Console.WriteLine($"{"No.", -5}{"Name", -25}{"Age", -5}{"Condition", -20}");
                ConsoleDesign.WriteHeader("================================================");

                int count = 1;
                foreach (var patient in matches)
                {
                    Console.WriteLine(
                        $"{count, -5}{patient.FullName, -25}{patient.Age, -5}{patient.MedCondition, -20}"
                    );
                    count++;
                }
                ConsoleDesign.WriteHeader("================================================\n");
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        private static void DisplayAllPatients()
        {
            // Check if there are any patients to display:
            if (Patients.Count == 0)
            {
                ConsoleDesign.WriteError("No patient records to display.");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                return;
            }

            int count = 1;

            // Display all patients:
            Console.WriteLine("Registered Patients:\n");
            ConsoleDesign.WriteHeader("================================================");
            Console.WriteLine($"{"No.", -5}{"Name", -25}{"Age", -5}{"Condition", -20}");
            ConsoleDesign.WriteHeader("================================================");
            foreach (var patient in Patients)
            {
                Console.WriteLine(
                    $"{count, -5}{patient.FullName, -25}{patient.Age, -5}{patient.MedCondition, -20}"
                );
                count++;
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
