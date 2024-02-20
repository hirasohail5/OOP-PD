using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
    internal class Program
{

    class Course
    {

        public string name;
        public int id;
        public Course(string name, int id)
        {
            this.name = name;
            this.id = id;
        }
    }
    class Student
    {

        public string name;
        public int id;
        public string password;
        public Student(string name, int id, string password)
        {
            this.name = name;
            this.id = id;
            this.password = password;
        }
    }
    class Teacher
    {
        public string name;
        public int id;
        public string password;
        public Teacher(string name, int id, string password)
        {
            this.name = name;
            this.id = id;
            this.password = password;
        }
    }
    static void Main(string[] args)
    {
        List<Teacher> teacher = new List<Teacher>();
        List<Course> course = new List<Course>();
        List<Student> student = new List<Student>();
        List<Course> stdcourse = new List<Course>();
        int option, stdoption, teacheroption;
        string user;
            
            loadteacherdata(teacher);
            loadstudentdata(student);
            loadCoursedata(course);


        while (true)
        {
            Console.Clear();
            Console.WriteLine("-::LMS::-");
            option = printmenu();
            if (option == 1)
            {
                Console.Clear();
                Console.WriteLine("-::SIGN UP::-");
                signup(student, teacher);
                    saveTeacherDetails(teacher);
                    saveStudentDetails(student);
                }
            else if (option == 2)
            {
                Console.Clear();
                Console.WriteLine("-::SIGN IN::-");
                user = signin(student, teacher);
                if (user == "Student")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("~::Student Menu::~");
                        Console.WriteLine("1.Register course");
                        Console.WriteLine("2.Show Cuurent courses");
                        Console.WriteLine("3.Unregister course");
                        Console.WriteLine("4.Exit");
                        Console.WriteLine("Enter your option");
                        stdoption = int.Parse(Console.ReadLine());
                        if (stdoption == 1)
                        {
                            Console.Clear();
                            Registercourses(stdcourse, course);
                                saveCourseDetails(course);
                                Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                        }
                        else if (stdoption == 2)
                        {
                            Console.Clear();
                            ShowRegistercourse(stdcourse);

                        }
                        else if (stdoption == 3)
                        {
                            Console.Clear();
                            unregistercourse(stdcourse);
                                saveCourseDetails(course);
                            }
                        else if (stdoption == 4)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Try again.Press any key to continue");
                            Console.ReadKey();
                        }
                    }
                }
                else if (user == "Teacher")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("~::Teacher Menu::~");
                        Console.WriteLine("1. Add courses");
                        Console.WriteLine("2. Exit");
                        teacheroption = int.Parse(Console.ReadLine());
                        if (teacheroption == 1)
                        {
                            Console.Clear();
                            Addcourses(course);
                                saveCourseDetails(course);
                            }
                        else if (teacheroption == 2)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Try again.Press any key to continue");
                            Console.ReadKey();
                        }
                    }
                }
            }
            else if (option == 3)
            {
                    saveTeacherDetails(teacher);
                    saveStudentDetails(student);
                    saveCourseDetails(course);
                    break;
            }
            else
            {
                Console.WriteLine("Try again.Press any key to continue");
                Console.ReadKey();

            }
        }


    }
    static int printmenu()
    {
        Console.WriteLine("1. SignUp");
        Console.WriteLine("2. Signin");
        Console.WriteLine("3. Exit");
        Console.WriteLine("Enter your option");
        return int.Parse(Console.ReadLine());
    }
    static void signup(List<Student> student, List<Teacher> teacher)
    {
        Console.WriteLine("Enter your name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter your id: ");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter your password: ");
        string password = Console.ReadLine();
        Console.WriteLine("Enter role: ");
        string role = Console.ReadLine();
        if (role == "student")
        {
            Student s = new Student(name, id, password);
            student.Add(s);

        }
        else if (role == "teacher")
        {
            Teacher t = new Teacher(name, id, password);
            teacher.Add(t);
        }
    }

        

        static string signin(List<Student> student, List<Teacher> teacher)
    {
        string username, password;
        Console.WriteLine("Enter name: ");
        username = Console.ReadLine();
        Console.WriteLine("Enter password: ");
        password = Console.ReadLine();
        foreach (var std in student)
        {

            if (username == std.name && password == std.password)
            {
                return "Student";
            }
        }
        foreach (var teach in teacher)
        {
            if (username == teach.name && password == teach.password)
            {
                return "Teacher";
            }
        }
        return null;
    }
    static void Registercourses(List<Course> stdcourse, List<Course> course)
    {
        Console.WriteLine("Enter course name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Course id: ");
        int id = int.Parse(Console.ReadLine());
        foreach (var courses in course)
        {
            if (courses.id == id && courses.name == name)
            {
                Course c = new Course(name, id);
                stdcourse.Add(c);
                Console.WriteLine("Course registered successfully!");
                break;
            }
            else
            {
                Console.WriteLine("Error: Course not found.");
            }
        }
    }
    static void ShowRegistercourse(List<Course> stdcourses)
    {
        Console.WriteLine("Course ID\tCourse Name");
        foreach (var course in stdcourses)
        {
            Console.WriteLine($"{course.id}\t\t{course.name}");
        }
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }
    static void unregistercourse(List<Course> stdcourses)
    {
        int z = 0;
        Console.WriteLine("Enter course name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter course id: ");
        int id = int.Parse(Console.ReadLine());
        for (int i = 0; i < stdcourses.Count; i++)
        {
            if (name == stdcourses[i].name && id == stdcourses[i].id)
            {
                stdcourses.RemoveAt(i);
                Console.WriteLine("Unregistered successfully");
                z++;
                break;
            }

        }
        if (z == 0)
        {
            Console.WriteLine("No course found!");
        }
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }
    static void Addcourses(List<Course> courses)
    {
        Console.WriteLine("Enter course name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Course id: ");
        int id = int.Parse(Console.ReadLine());
        Course C = new Course(name, id);
        courses.Add(C);
    }
        static void loadteacherdata(List<Teacher> teacher)
        {
            string line = "";
            string Username, Password;
            int id;

            if (File.Exists(Teachers))
            {
                StreamReader fileVariable = new StreamReader(Teachers);
                while ((line = fileVariable.ReadLine()) != null)
                {
                    Username = parseData(line, 1);
                    Password = parseData(line, 2);
                    id = parseData(line, 3);
                    Teacher t = new Teacher(name, password, id);
                    teacher.Add(t);

                }

                fileVariable.Close();
            }
            else
            {
                Console.Write("File does not exist!");
            }
        }
        static void loadstudentdata(List<Student> student)
        {
            string line = "";
            string Username, Password;
            int id;

            if (File.Exists(Students))
            {
                StreamReader fileVariable = new StreamReader(Students);
                while ((line = fileVariable.ReadLine()) != null)
                {
                    Username = parseData(line, 1);
                    Password = parseData(line, 2);
                    id = parseData(line, 3);
                    Student s = new Student(name, password, id);
                    student.Add(s);

                }

                fileVariable.Close();
            }
            else
            {
                Console.Write("File does not exist!");
            }
        }
        static void loadCoursedata(List<Course> course)
        {
            string line = "";
            string name;
            int id;

            if (File.Exists(Courses))
            {
                StreamReader fileVariable = new StreamReader(Courses);
                while ((line = fileVariable.ReadLine()) != null)
                {
                    name = parseData(line, 1);
                    id = parseData(line, 2);

                    Course C = new Course(name, id);
                    course.Add(C);

                }

                fileVariable.Close();
            }
            else
            {
                Console.Write("File does not exist!");
            }
        }
        static string parseData(string line, int field)
        {

            string item = "";
            int commaCount = 1;
            int length = line.Length;
            for (int x = 0; x < length; x++)
            {
                if (line[x] == ',')
                {
                    commaCount++;
                }
                else if (field == commaCount)
                {
                    item += line[x];
                }
            }

            return item;
        }
        static void saveTeacherDetails(List<Teacher> teacher)
        {
            StreamWriter fileVariable = new StreamWriter(Teachers);
            for (int i = 0; i < teacher.Count; i++)
            {
                fileVariable.WriteLine(teacher[i].username + "," + teacher[i].password + "," + teacher[i].role);
            }
            fileVariable.Flush();
            fileVariable.Close();
        }
        static void saveStudentDetails(List<Student> student)
        {
            StreamWriter fileVariable = new StreamWriter(Students);
            for (int i = 0; i < student.Count; i++)
            {
                fileVariable.WriteLine(student[i].username + "," + student[i].password + "," + student[i].role);
            }
            fileVariable.Flush();
            fileVariable.Close();
        }
        static void saveCourseDetails(List<Course> course)
        {
            StreamWriter fileVariable = new StreamWriter(Courses);
            for (int i = 0; i < course.Count; i++)
            {
                fileVariable.WriteLine(course[i].username + "," + course[i].password + "," + course[i].role);
            }
            fileVariable.Flush();
            fileVariable.Close();
        }

    }
}
