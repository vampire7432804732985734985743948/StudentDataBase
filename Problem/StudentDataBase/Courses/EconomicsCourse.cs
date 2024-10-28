using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.StudentDataBase.Courses
{
    internal class EconomicsCourse : Course
    {
        public EconomicsCourse() : base("Economics") { }

        protected override void SetSubjects()
        {
            Subjects = new List<Subject>
        {
            new Subject("Macroeconomics - S"),
            new Subject("Financial and Capital Markets - S"),
            new Subject("Data Management in Economics - S"),
            new Subject("Business Models and Simulations - S"),
            new Subject("History of Economic Thought - S"),
            new Subject("International Economics - S")
        };
        }
    }

}
