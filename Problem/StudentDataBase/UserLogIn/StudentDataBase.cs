﻿using System;
using System.Linq;
using System.Text;
using Problem.StudentDataBase.DataContainer;
using Problem.StudentDataBase.TechnicalStuff;

namespace Problem.StudentDataBase
{
    internal class StudentDataBase
    {
        private List<Student> _students = new List<Student>();

        private (string? name, string? lastName, string? sex, string? pesselNumber, string? albumNumber, string? password, string? address, string? fieldOfStudy) AddStudentData()
        {
            Console.Write("Name:");
            string? name = Console.ReadLine();
            Console.Write("Last name: ");
            string? lastName = Console.ReadLine();
            Console.Write("Sex: ");
            string? sex = Console.ReadLine();
            Console.Write("Pessel number: ");
            string? pesselNumber = Console.ReadLine();
            Console.Write("Album number: ");
            string? albumNumber = Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = PasswordHasher.HashPassword(Console.ReadLine());
            Console.WriteLine("Address: ");
            string? address = Console.ReadLine();
            Console.Write("Field of study: ");
            string? fieldOfStudy = Console.ReadLine();
            return (name, lastName, sex, pesselNumber, albumNumber, password, address, fieldOfStudy);
        }
        public void AddStudent()
        {
            var student = AddStudentData();

            _students.Add(new Student
            (
                name: student.name,
                lastName: student.lastName,
                sex: student.sex,
                pesselNumber: student.pesselNumber,
                albumNumber: student.albumNumber,
                password: student.password,
                address: student.address,
                fieldOfStudy: student.fieldOfStudy
            ));
        }
        public void SaveAllData()
        {
            JSONSerializer.SaveAllData(_students);
        }
        public void ShowAllStudents()
        {
            foreach (var student in _students)
            {
                Console.WriteLine($"Name: {student.Name}");
                Console.WriteLine($"Last name: {student.LastName}");
                Console.WriteLine($"Sex: {student.Sex}");
                Console.WriteLine($"Pessel {student.PesselNumber}");
                Console.WriteLine($"Album number {student.AlbumNumber}");
                Console.WriteLine($"Address {student.Address}");
            }
        }
        public Student FindStudentByPessel(string pesselNumber)
        {
            foreach (var student in _students)
            {
                if (student.PesselNumber == pesselNumber)
                {
                    return student;
                }
            }
            return new Student(default, default, default, default, default, default, default, default);
        }
        public List<Student> FindStudentByLastName(string lastName)
        {
            List<Student> students = new List<Student>();
            foreach (var student in _students)
            {
                if (student.LastName == lastName)
                {
                    students.Add(student);
                }
            }
            return students;
        }
        public List<Student> SortByLastName()
        {
            return _students.OrderByDescending(student => student.LastName).ToList();
        }
        public List<Student> SortByFirstName()
        {
            return _students.OrderByDescending(student => student.Name).ToList();
        }
        public void DeleteStudentById(string albumNumber)
        {
            foreach (var student in _students)
            {
                if (student.AlbumNumber == albumNumber)
                {
                    _students.Remove(student);
                }
            }
        }
    }
}