using Problem.StudentDataBase.TechnicalStuff;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.StudentDataBase.Courses
{
    internal class Subject
    {
        private const int MIN_GRADE = 2;
        private const int MAX_GRADE = 5;
        private int _grade;

        public int Grade
        {
            get { return _grade; }
            set
            {
                if (value < MAX_GRADE && value > MIN_GRADE)
                {
                    _grade = value;
                }
                else
                {
                    ConsoleInterfaceManager.DrawColoredText("Invalid data", ConsoleColor.Red);
                    _grade = 0;
                }
            }
        }

        private int _attendancePercentage;

        public int AttendancePercentage
        {
            get { return _attendancePercentage; }
            private set { _attendancePercentage = value; }
        }

        private int GeneratePercentageOfAttendance() => new Random().Next(0, 100);

        private string? _nameOfSubject;

        public string NameOfSubject
        {
            get { return _nameOfSubject ?? "Unknown"; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _nameOfSubject = value;
                }
                else
                {
                    _nameOfSubject = "Unknown";
                }
            }
        }
        public Subject(string nameOfSubject)
        {
            NameOfSubject = nameOfSubject;
        }
    }
}
