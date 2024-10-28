using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.StudentDataBase.Courses
{
    internal class NursingCourse : Course
    {
        public NursingCourse() : base("Nursing") { }

        protected override void SetSubjects()
        {
            Subjects = new List<Subject>
        {
            new Subject("Anatomy and Physiology - S"),
            new Subject("Biochemistry and Biophysics - S"),
            new Subject("Basic Nursing Care - S"),
            new Subject("Clinical Nursing - S"),
            new Subject("Medical Simulation - S"),
            new Subject("Emergency Nursing - S")
        };
        }
    }
}
