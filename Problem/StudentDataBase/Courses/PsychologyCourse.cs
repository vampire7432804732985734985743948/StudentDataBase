using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.StudentDataBase.Courses
{
    internal class PsychologyCourse : Course
    {
        public PsychologyCourse() : base("Psychology") { }

        protected override void SetSubjects()
        {
            Subjects = new List<Subject>
        {
            new Subject("Introduction to Psychology - S"),
            new Subject("Developmental Psychology - S"),
            new Subject("Clinical Psychology - S"),
            new Subject("Social Psychology - S"),
            new Subject("Cognitive Behavioral Therapy - S"),
            new Subject("Psychopathology - S")
        };
        }
    }
}
