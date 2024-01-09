using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace schoolproject
//{


// Singleton Pattern
public class SchoolDataStorage
{
    private static SchoolDataStorage instance;
    public List<Student> Students { get; set; }
    public List<Teacher> Teachers { get; set; }
    public List<Subject> Subjects { get; set; }

    private SchoolDataStorage()
    {
        Students = new List<Student>();
        Teachers = new List<Teacher>();
        Subjects = new List<Subject>();
    }

    public static SchoolDataStorage Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SchoolDataStorage();
            }
            return instance;
        }
    }
}

// Subject class
public class Subject
{
    public string Name { get; set; }
    public string SubjectCode { get; set; }
    public Teacher Teacher { get; set; }
}

// Teacher class
public class Teacher
{
    public string Name { get; set; }
    public string ClassAndSection { get; set; }
}

// Student class
public class Student
{
    public string Name { get; set; }
    public string ClassAndSection { get; set; }
}

// Repository Pattern
public class SchoolRepository
{
    private SchoolDataStorage dataStorage;

    public SchoolRepository()
    {
        dataStorage = SchoolDataStorage.Instance;
    }

    public void AddStudent(Student student)
    {
        dataStorage.Students.Add(student);
    }

    public void AddTeacher(Teacher teacher)
    {
        dataStorage.Teachers.Add(teacher);
    }

    public void AddSubject(Subject subject)
    {
        dataStorage.Subjects.Add(subject);
    }

    public List<Student> GetStudentsInClass(string classAndSection)
    {
        return dataStorage.Students.FindAll(student => student.ClassAndSection == classAndSection);
    }

    public List<Subject> GetSubjectsTaughtByTeacher(string teacherName)
    {
        return dataStorage.Subjects.FindAll(subject => subject.Teacher.Name == teacherName);
    }
}

class Program
{
    static void Main()
    {
        SchoolRepository repository = new SchoolRepository();

        // Adding dummy data
        repository.AddStudent(new Student { Name = "Surabhi", ClassAndSection = "ClassA" });
        repository.AddStudent(new Student { Name = "Nischitha", ClassAndSection = "ClassA" });
        repository.AddStudent(new Student { Name = "Adithi", ClassAndSection = "ClassA" });
        repository.AddStudent(new Student { Name = "Adhvi", ClassAndSection = "ClassA" });
        repository.AddStudent(new Student { Name = "Alfi", ClassAndSection = "ClassA" });
        repository.AddStudent(new Student { Name = "Vaishnavi", ClassAndSection = "ClassA" });

        repository.AddStudent(new Student { Name = "Harshi", ClassAndSection = "ClassB" });
        repository.AddStudent(new Student { Name = "Suman", ClassAndSection = "ClassB" });
        repository.AddStudent(new Student { Name = "Sharan", ClassAndSection = "ClassB" });
        repository.AddStudent(new Student { Name = "Mohan", ClassAndSection = "ClassB" });


        repository.AddTeacher(new Teacher { Name = "Teacher1", ClassAndSection = "ClassA" });
        // repository.AddTeacher(new Teacher { Name = "Teacher2", ClassAndSection = "ClassB" });

        repository.AddSubject(new Subject
        {
            Name = "Science",
            SubjectCode = "MATH101",
            Teacher = new Teacher { Name = "Teacher1", ClassAndSection = "ClassA" }

        });



        // Displaying lists
        Console.WriteLine("Students in ClassA:");
        foreach (var student in repository.GetStudentsInClass("ClassA"))
        {
            Console.WriteLine(student.Name);
        }

        Console.WriteLine("\nSubjects taught by Teacher1:");
        foreach (var subject in repository.GetSubjectsTaughtByTeacher("Teacher1"))
        {
            Console.WriteLine(subject.Name);
        }
        //d


        repository.AddSubject(new Subject
        {
            Name = "Computer Science",
            SubjectCode = "Cs102",
            Teacher = new Teacher { Name = "Teacher2", ClassAndSection = "ClassB" }

        });
        Console.WriteLine("");
        // d
        Console.WriteLine("Students in ClassB:");
        foreach (var student in repository.GetStudentsInClass("ClassB"))
        {
            Console.WriteLine(student.Name);
        }

        Console.WriteLine("\nSubjects taught by Teacher2:");
        foreach (var subject in repository.GetSubjectsTaughtByTeacher("Teacher2"))
        {
            Console.WriteLine(subject.Name);
        }
    }
}