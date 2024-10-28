using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.StudentDataBase.Courses
{
    internal class LogisticsCourse : Course
    {
        public LogisticsCourse() : base("Logistics") { }

        protected override void SetSubjects()
        {
            Subjects = new List<Subject>
        {
            new Subject("Logistics Systems Engineering - S"),
            new Subject("Supply Chain Management - S"),
            new Subject("Transport and Shipping Management - S"),
            new Subject("Production Logistics - S"),
            new Subject("Cost Management in Logistics - S"),
            new Subject("Logistics in Public Administration - S")
        };
        }
    }

}
