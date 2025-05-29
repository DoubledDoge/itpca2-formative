namespace Student_Course_Enrollment_System
{
    public class Student(string fullName, int age, string studentId)
    {
        public string FullName { get; } = fullName;
        public int Age { get; } = age;
        public string StudentId { get; } = studentId;

        // Static method to return sample students in a LinkedList
        public static LinkedList<Student> GetStudents()
        {
            var students = new LinkedList<Student>();

            // Add sample students
            students.AddLast(new Student("Alice Johnson", 20, "EDUV001"));
            students.AddLast(new Student("Bob Smith", 22, "EDUV002"));
            students.AddLast(new Student("Carol Williams", 19, "EDUV003"));
            students.AddLast(new Student("David Brown", 21, "EDUV004"));
            students.AddLast(new Student("Emma Davis", 23, "EDUV005"));

            return students;
        }
    }
}
