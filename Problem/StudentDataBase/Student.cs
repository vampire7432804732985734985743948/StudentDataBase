using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.StudentDataBase
{
    internal class Student
    {
        public string FieldOfStudy { get; private set; }
        public string? Name { get; private set; }
        public string? LastName { get; private set; }
        public string? Address { get; private set; }
        private const int NUMBER_OF_DIGITS_PESSEL = 11;
        private const int NUMBER_OF_DIGITS_ALBUM_NUMBER = 5;

        private string? _albumNumber;

        public string AlbumNumber
        {
            get { return _albumNumber; }
            private set
            {
                if (value.Length != NUMBER_OF_DIGITS_ALBUM_NUMBER)
                {
                    _albumNumber = "Unknown";
                }
                else
                {
                    _albumNumber = value;
                }
            }
        }

        private string? _pesselNumber;
        public string PesselNumber
        {
            get
            {
                if (_pesselNumber != null)
                    return _pesselNumber;
                else
                    return _pesselNumber = string.Empty;
            }
            set
            {
                if (value.Length != NUMBER_OF_DIGITS_PESSEL || value == null)
                {
                    _pesselNumber =  "Unknown";
                }
                else
                {
                    _pesselNumber = value; 
                }
            }
        }

        public string? Sex { get; private set; }

        public Student(string? name = "Unknown", string? lastName = "Unknown", string? sex = "Unknown", string? pesselNumber = "Unknown", string? albumNumber = "Unknown", string FieldOfStydy = "Unknown", string? address = "Unknown")
        {
            Name = name ?? "Unknown";
            LastName = lastName ?? "Unknown";
            Sex = sex ?? "Unknown";
            PesselNumber = pesselNumber ?? "Unknown";
            AlbumNumber = albumNumber ?? "Unknown";
            Address = address ?? "Unknown";
            FieldOfStudy = FieldOfStydy ?? "Unknown";
        }
    }
}
