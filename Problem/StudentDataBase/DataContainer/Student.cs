using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.StudentDataBase.DataContainer
{
    internal class Student : UserData
    {
        public string FieldOfStudy { get; private set; }
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
    }
}
