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
        public Course? FieldOfStudy { get; private set; }
        public List<Subject>? CourseSubjects { get; private set; }

        public Student(string? name,
                       string? lastName,
                       string? sex,
                       string? pesselNumber,
                       string? albumNumber,
                       string? password,
                       string? address,
                       Course? fieldOfStudy)
        {
            Role = "Student";
            Name = name ?? "Unknown";
            LastName = lastName ?? "Unknown";
            Sex = sex ?? "Unknown";
            PesselNumber = pesselNumber ?? "Unknown";
            AlbumNumber = albumNumber ?? "Unknown";
            Password = password ?? "Invalid password";
            Address = address ?? "Unknown";
            FieldOfStudy = fieldOfStudy ?? new Course("Unknown");
            SetSubjectList();
        }

        private void SetSubjectList()
        {
            if (FieldOfStudy != null)
            {
                CourseSubjects = FieldOfStudy.Subjects;
            }
        }
    }
}
