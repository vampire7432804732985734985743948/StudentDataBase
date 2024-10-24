using System;
using Problem.StudentDataBase;

StudentDataBase student = new StudentDataBase();

student.AddStudent();
Console.WriteLine("_________________");
student.ShowAllStudents();
student.SaveAllData();