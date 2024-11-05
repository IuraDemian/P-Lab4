using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

class Student
{
    public string Surname { get; set; }
    public string Gender { get; set; }
    public string Class { get; set; }
    public int Grade1 { get; set; }
    public int Grade2 { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        string jsonFilePath = "Shkola.json";

        List<Student> students = new List<Student>
        {
            new Student { Surname = "Микулець", Gender = "ч", Class = "10-B", Grade1 = 7, Grade2 = 12 },
            new Student { Surname = "Сидоренко", Gender = "ч", Class = "10-A", Grade1 = 8, Grade2 = 9 },
            new Student { Surname = "Потрогош", Gender = "ж", Class = "10-B", Grade1 = 3, Grade2 = 9 },
            new Student { Surname = "Іванова", Gender = "ж", Class = "10-А", Grade1 = 8, Grade2 = 10 }
        };

        string json = JsonConvert.SerializeObject(students, Formatting.Indented);
        File.WriteAllText(jsonFilePath, json);


        foreach (var student in students)
        {
            Console.WriteLine($"Прiзвище - {student.Surname}, Стать - {student.Gender}, Класс - {student.Class}, Перша та друга оцiнка - {student.Grade1}:{student.Grade2}.");
        }


        Console.WriteLine("Введiть класс");
        string classInput = Console.ReadLine();
        int girlCount = 0;

        foreach (var student in students)
        {
            if (student.Class == classInput && student.Gender == "ж")
            {
                girlCount++;
            }
        }
        Console.WriteLine($"Кiлькiсть дiвчат у классi {classInput} - {girlCount}");


        Console.WriteLine("Введiть класс");
        string averageClassInput = Console.ReadLine();
        double totalGrade = 0;
        int count = 0;

        foreach (var student in students)
        {
            if (student.Class == averageClassInput)
            {
                totalGrade += (student.Grade1 + student.Grade2);
                count += 2;
            }
        }
        double averageGrade = count > 0 ? totalGrade / count : 0;

        Console.WriteLine($"Середня оцiнка у классi {averageClassInput} = {averageGrade}");
    }
}