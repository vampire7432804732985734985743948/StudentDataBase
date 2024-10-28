using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.StudentDataBase.Courses
{
    internal class Course
    {
        public string CourseName { get; protected set; }
        internal List<Subject> Subjects { get; set; } = new List<Subject>();
        public Course(string name)
        {
            CourseName = name;
            SetSubjects();
        }

        protected virtual void SetSubjects()
        {

        }
    }
}
