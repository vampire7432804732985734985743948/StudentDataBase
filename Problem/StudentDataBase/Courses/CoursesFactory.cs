using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.StudentDataBase.Courses
{
    internal class CoursesFactory
    {
        public static Course CreateCourse(string courseName)
        {
            if (string.IsNullOrWhiteSpace(courseName))
            {
                throw new ArgumentException("Invalid course name");
            }
            else
            {
                switch (courseName.ToLower())
                {
                    case "computer science":
                        return new ComputerScienceCourse();
                    case "management":
                        return new ManagementCourse();
                    case "logistics":
                        return new LogisticsCourse();
                    case "economics":
                        return new EconomicsCourse();
                    case "nursing":
                        return new NursingCourse();
                    case "psychology":
                        return new PsychologyCourse();
                    default:
                        throw new ArgumentException("Invalid course name");
                }
            }
        }
    }
}
