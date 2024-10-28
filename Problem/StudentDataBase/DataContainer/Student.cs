using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem.StudentDataBase.Courses;

namespace Problem.StudentDataBase.DataContainer
{
    internal class Student : UserData
    {
        public string FieldOfStudy { get; private set; }
        private List<Subject> _subjects = new List<Subject>();

        public Student(string? name,
                       string? lastName,
                       string? sex,
                       string? pesselNumber,
                       string? albumNumber,
                       string? password,
                       string? address,
                       string? fieldOfStudy)
        {
            Role = "Student";
            Name = name ?? "Unknown";
            LastName = lastName ?? "Unknown";
            Sex = sex ?? "Unknown";
            PesselNumber = pesselNumber ?? "Unknown";
            AlbumNumber = albumNumber ?? "Unknown";
            Password = password ?? "Invalid password";
            Address = address ?? "Unknown";
            FieldOfStudy = fieldOfStudy ?? "Unknown";
        }

        public override void ShowInfo()
        {

        }

        public void AddSubject(Subject subject)
        {
            _subjects.Add(subject);
        }
    }
}
