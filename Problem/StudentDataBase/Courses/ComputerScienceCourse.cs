using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.StudentDataBase.Courses
{
    internal class ComputerScienceCourse : Course
    {
        public ComputerScienceCourse() : base("Computer Science") { }

        protected override void SetSubjects()
        {
            Subjects = new List<Subject>
        {
            new Subject("Humanistic and Social module - S"),
            new Subject("Discrete mathematics - S"),
            new Subject("ICT and multimedia systems - S"),
            new Subject("Introduction to computer networks - S"),
            new Subject("T Project Management - S"),
            new Subject("Software Engineering - S"),
            new Subject("Gym classes")
        };
        }
    }
}
