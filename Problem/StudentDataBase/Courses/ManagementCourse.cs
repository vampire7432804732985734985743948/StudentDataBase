using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.StudentDataBase.Courses
{
    public class ManagementCourse : Course
    {
        public ManagementCourse() : base("Management") { }

        protected override void SetSubjects()
        {
            Subjects = new List<Subject>
        {
            new Subject("Principles of Management - S"),
            new Subject("Human Resource Management - S"),
            new Subject("Marketing Management - S"),
            new Subject("Financial Management - S"),
            new Subject("Strategic Management - S"),
            new Subject("Project Management - S"),
            new Subject("Operations and Supply Chain Management - S"),
            new Subject("Organizational Behavior - S"),
            new Subject("Entrepreneurship - S"),
            new Subject("Business Law - S")
        };
        }
    }
}
