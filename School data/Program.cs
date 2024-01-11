

using System;
using System.Collections.Generic;

class Student
{
    public string Name { get; set; }
    public string ClassSection { get; set; }
}

class Teacher
{
    public string Name { get; set; }
    public string ClassSection { get; set; }
}

class Subject
{
    public string Name { get; set; }
    public string SubjectCode { get; set; }
    public Teacher Teacher { get; set; }
}

class RainbowSchool
{
    public List<Student> Students { get; } = new List<Student>();
    public List<Teacher> Teachers { get; } = new List<Teacher>();
    public List<Subject> Subjects { get; } = new List<Subject>();

    public void AddStudent(string name, string classSection)
    {
        Students.Add(new Student { Name = name, ClassSection = classSection });
    }

    public void AddTeacher(string name, string classSection)
    {
        Teachers.Add(new Teacher { Name = name, ClassSection = classSection });
    }

    public void AddSubject(string name, string subjectCode, Teacher teacher)
    {
        Subjects.Add(new Subject { Name = name, SubjectCode = subjectCode, Teacher = teacher });
    }

    public List<Student> GetStudentsInClass(string classSection)
    {
        return Students.FindAll(student => student.ClassSection == classSection);
    }

    public List<Subject> GetSubjectsTaughtByTeacher(string teacherName)
    {
        Teacher teacher = Teachers.Find(t => t.Name == teacherName);
        if (teacher != null)
        {
            return Subjects.FindAll(subject => subject.Teacher == teacher);
        }
        return new List<Subject>();
    }
}

class Program
{
    static void Main(string[] args)
    {
        RainbowSchool rainbowSchool = new RainbowSchool();

        // Filling up the lists with data
        rainbowSchool.AddStudent("Student1", "ClassA");
        rainbowSchool.AddStudent("Student2", "ClassB");

        rainbowSchool.AddTeacher("Teacher1", "ClassA");
        rainbowSchool.AddTeacher("Teacher2", "ClassB");

        rainbowSchool.AddSubject("java", "JAVA474", rainbowSchool.Teachers[0]);
        rainbowSchool.AddSubject("c-sharp", "C-Sharp101474", rainbowSchool.Teachers[1]);

        // Display students in a class
        List<Student> classAStudents = rainbowSchool.GetStudentsInClass("ClassA");
        Console.WriteLine("Students in ClassA:");
        foreach (var student in classAStudents)
        {
            Console.WriteLine($"- {student.Name}");
        }

        // Display subjects taught by a teacher
        List<Subject> teacher2Subjects = rainbowSchool.GetSubjectsTaughtByTeacher("Teacher2");
        Console.WriteLine("Subjects taught by Teacher2:");
        foreach (var subject in teacher2Subjects)
        {
            Console.WriteLine($"- {subject.Name} (Code: {subject.SubjectCode})");
        }
    }
}

