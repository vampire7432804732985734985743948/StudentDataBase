using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.StudentDataBase.Courses
{
    public abstract class Course
    {
        public string Name { get; protected set; }

        // Change this to internal if Subject is internal
        internal List<Subject> Subjects { get; set; } = new List<Subject>();

        public Course(string name)
        {
            Name = name;
            SetSubjects();
        }

        protected abstract void SetSubjects();
    }
}
