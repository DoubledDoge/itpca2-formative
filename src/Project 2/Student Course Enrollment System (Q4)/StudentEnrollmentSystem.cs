namespace Student_Course_Enrollment_System
{
    public static class StudentEnrollmentSystem
    {
        private static readonly LinkedList<Student> Students = Student.GetStudents();

        public static bool HandleCliMenu()
        {
            ConsoleDesign.WriteHeader("=================== Main Menu ===================\n\n");
            ConsoleDesign.WriteMenu(
                "  1. Add Student\n"
                    + "  2. Remove Student\n"
                    + "  3. Display all Students\n"
                    + "  0. Exit\n\n"
            );
            ConsoleDesign.WriteHeader("=================================================\n\n");

            int choice = InputValidator.GetValidIntInput("Enter your choice (0-3)", 0, 3);
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    AddStudent();
                    WaitAndClear();
                    break;
                case 2:
                    RemoveStudent();
                    WaitAndClear();
                    break;
                case 3:
                    DisplayAllStudents();
                    WaitAndClear();
                    break;
                case 0:
                    Console.WriteLine("Exiting Student Enrollment System..\n");
                    return false;
                default:
                    ConsoleDesign.WriteError("Invalid choice. Please try again.\n");
                    break;
            }
            return true;
        }

        private static void AddStudent()
        {
            Console.Clear();

            // Get student details
            string fullName = InputValidator.GetValidStringInput("Enter student full name");
            int age = InputValidator.GetValidIntInput("Enter student age", 16, 100);
            string studentId = InputValidator.GetValidStringInput("Enter student ID");

            // Check if student ID already exists
            if (FindStudentById(studentId) != null)
            {
                ConsoleDesign.WriteError($"Student with ID {studentId} already exists.\n");
                return;
            }

            // Create new student and add to the list
            var newStudent = new Student(fullName, age, studentId);
            Students.AddLast(newStudent);

            ConsoleDesign.WriteSuccess($"Successfully added student: {newStudent.FullName}\n");
        }

        private static void RemoveStudent()
        {
            Console.Clear();

            // Check if there are any students to remove
            if (Students.Count == 0)
            {
                ConsoleDesign.WriteError("No students to remove.\n");
                return;
            }

            DisplayAllStudents();

            // Get student ID to remove
            string studentId = InputValidator.GetValidStringInput("Enter student ID to remove");

            // Find and remove the student
            var nodeToRemove = Students.First;

            // Traverse the linked list to find the student
            while (nodeToRemove != null)
            {
                if (nodeToRemove.Value.StudentId == studentId)
                {
                    string studentName = nodeToRemove.Value.FullName;

                    // Remove the student from the linked list
                    Students.Remove(nodeToRemove);
                    ConsoleDesign.WriteSuccess($"Successfully removed student: {studentName}\n");
                    return;
                }
                nodeToRemove = nodeToRemove.Next;
            }

            ConsoleDesign.WriteError($"Student with ID {studentId} not found.\n");
        }

        private static void DisplayAllStudents()
        {
            Console.Clear();

            // Check if there are any students to display
            if (Students.Count == 0)
            {
                ConsoleDesign.WriteError("No students enrolled.\n");
                return;
            }

            // Display total number of students
            ConsoleDesign.WriteSuccess($"Total Students: {Students.Count}\n\n");

            // Display student details
            Console.WriteLine("Registered Students:\n");
            Console.WriteLine($"{"No.", -4}{"Name", -30}{"Age", -6}{"Student ID", -10}");
            Console.WriteLine("--------------------------------------------------");

            int position = 1;
            var currentNode = Students.First;

            while (currentNode != null)
            {
                var student = currentNode.Value;
                Console.WriteLine(
                    $"{position, -4}{student.FullName, -30}{student.Age, -6}{student.StudentId, -10}"
                );
                currentNode = currentNode.Next;
                position++;
            }
        }

        // Finds a student by their ID in the linked list of students.
        private static Student? FindStudentById(string studentId)
        {
            var currentNode = Students.First;

            while (currentNode != null)
            {
                if (currentNode.Value.StudentId == studentId)
                {
                    return currentNode.Value;
                }
                currentNode = currentNode.Next;
            }

            return null;
        }

        private static void WaitAndClear()
        {
            Console.Write("\nPress Enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
