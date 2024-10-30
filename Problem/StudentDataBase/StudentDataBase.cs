using System;
using System.Linq;
using System.Text;
using Problem.StudentDataBase.Courses;
using Problem.StudentDataBase.DataContainer;
using Problem.StudentDataBase.TechnicalStuff;

namespace Problem.StudentDataBase
{
    internal class StudentDataBase
    {
        private List<Student>? _students = null;
        private int _numberOfSubjects;

        public int NumberOfSubjects
        {
            get { return _numberOfSubjects; }
            private set
            {
                if (value > 0)
                {
                    _numberOfSubjects = value;
                }
                else
                {
                    ConsoleInterfaceManager.DrawColoredText(new StringBuilder("Invalid data"), ConsoleColor.Red);
                    _numberOfSubjects = 1;
                }
            }
        }

        public StudentDataBase()
        {
            _students = JSONSerializer.DeserializeData<List<Student>>("JSONStudentDataBase.json");
        }
        private (string? name, string? lastName, string? sex, string? pesselNumber, string? albumNumber, string? password, string? address, Course fieldOfStudy) AddStudentData()
        {
            Console.Write("Name:");
            string? name = Console.ReadLine();
            Console.Write("Last name: ");
            string? lastName = Console.ReadLine();
            Console.Write("Sex: ");
            string? sex = Console.ReadLine();
            Console.Write("Pessel number: ");
            string? pesselNumber = Console.ReadLine();
            Console.Write("Album number: ");
            string? albumNumber = Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = PasswordHasher.HashPassword(EnterObligateData());
            Console.WriteLine("Address: ");
            string? address = Console.ReadLine();
            Console.Write("Field of study: ");
            string? fieldOfStudy = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(fieldOfStudy))
            {
                ConsoleInterfaceManager.DrawColoredText(new StringBuilder("Null reference return"), ConsoleColor.Red);
                throw new ArgumentException("Invalid data");
            }
            Course course = CoursesFactory.CreateCourse(fieldOfStudy);

            return (name, lastName, sex, pesselNumber, albumNumber, password, address, course);
        }
        public void AddStudent()
        {
            if (_students == null )
            {
                _students = JSONSerializer.DeserializeData<List<Student>>("JSONStudentDataBase.json");
            }
            var student = AddStudentData();

            _students.Add(new Student
            (
                name: student.name,
                lastName: student.lastName,
                sex: student.sex,
                pesselNumber: student.pesselNumber,
                albumNumber: student.albumNumber,
                password: student.password,
                address: student.address,
                fieldOfStudy: student.fieldOfStudy
            ));
        }
        public void SaveAllData()
        {
            JSONSerializer.SaveAllData(_students);
        }
        public void ShowStudentData(Student student)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Name: {student.Name}");
            Console.WriteLine($"Last name: {student.LastName}");
            Console.WriteLine($"Sex: {student.Sex}");
            Console.WriteLine($"Pessel: {student.PesselNumber}");
            Console.WriteLine($"Album number: {student.AlbumNumber}");
            Console.WriteLine($"Address: {student.Address}");
            Console.WriteLine($"Course: {student.FieldOfStudy.CourseName}");
            
        }
        public void ShowAllStudents()
        {
            if (_students != null)
            {
                foreach (var student in _students)
                {
                    ShowStudentData(student);
                }
            }
            else
            {
                ConsoleInterfaceManager.DrawColoredText(new StringBuilder("There are no students!"), ConsoleColor.Red);
            }
        }
        public void ShowAllStudents(List<Student> students)
        {
            if (students != null)
            {
                foreach (var student in students)
                {
                    ShowStudentData(student);
                }
            }
            else
            {
                ConsoleInterfaceManager.DrawColoredText(new StringBuilder("Database  is empty"),  ConsoleColor.Red);
            }
        }
        private string EnterObligateData()
        {
            string? data;

            do
            {
                data = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(data))
                {
                    Console.WriteLine("Input cannot be empty. Please enter a valid value:");
                }

            } while (string.IsNullOrWhiteSpace(data));

            return data;
        }
        public Student FindStudentByAlbumNumber(string albumNumber)
        {
            Student? selectedStudent = new Student(default, default, default, default, default, default, default, default);
            if (_students != null && _students.Count > 0)
            {
                if (albumNumber.Length != UserData.NUMBER_OF_DIGITS_ALBUM_NUMBER)
                {
                    ConsoleInterfaceManager.DrawColoredText(new StringBuilder("Invalid input"), ConsoleColor.Red);
                    return selectedStudent;
                }
                foreach (var student in _students)
                {
                    if (student.AlbumNumber == albumNumber)
                    {

                        Console.WriteLine(student.Name + student.PesselNumber);
                        selectedStudent = student;
                    }
                }

                if (selectedStudent.PesselNumber != null)
                {
                    return selectedStudent;
                }
                else
                {
                    ConsoleInterfaceManager.DrawColoredText(new StringBuilder("There is no such student here"), ConsoleColor.Red);
                    return new Student(default, default, default, default, default, default, default, default);
                }
            }
            else
            {
                ConsoleInterfaceManager.DrawColoredText(new StringBuilder("Database is empty"), ConsoleColor.Red);
                return new Student(default, default, default, default, default, default, default, default);
            }
        }
        public List<Student> FindStudentsByLastName(string lastName)
        {
            List<Student> students = new List<Student>();

            if (_students != null && _students.Count > 0)
            {
                foreach (var student in _students)
                {
                    Console.WriteLine(student.Name);
                    if (student.LastName == lastName)
                    {
                        students.Add(student);
                    }
                }
                if (students.Count <= 0)
                {
                    ConsoleInterfaceManager.DrawColoredText(new StringBuilder("There are no such students here"), ConsoleColor.Red);
                    return new List<Student>();
                }
                else
                {
                    return students;      
                }
            }
            else
            {
                ConsoleInterfaceManager.DrawColoredText(new StringBuilder("The database is empty"), ConsoleColor.Red);
                return new List<Student>();
            }
        }
        public List<Student> SortByLastName()
        {
            if (_students != null)
            {
                return _students.OrderBy(student => student.LastName).ToList();
            }
            else
            {
                return new List<Student>();
            }
        }
        public List<Student> SortByFirstName()
        {
            if (_students != null)
            {
                return _students.OrderBy(student => student.Name).ToList();
            }
            else
            {
                return new List<Student>();
            }
        }
        public void DeleteStudentById(string albumNumber)
        {
            if (_students != null)
            {
                foreach (var student in _students)
                {
                    if (student.AlbumNumber == albumNumber)
                    {
                        _students.Remove(student);
                        return;
                    }
                }
                ConsoleInterfaceManager.DrawColoredText(new StringBuilder("There is no  such student"), ConsoleColor.Red);
                return;
            }
            else
            {
                ConsoleInterfaceManager.DrawColoredText(new StringBuilder("The database is empty"), ConsoleColor.Red);
            }
        }

        public Subject FindSubject(string subjectName, string albumNumber)
        {
            if (string.IsNullOrWhiteSpace(subjectName) || string.IsNullOrWhiteSpace(albumNumber))
            {
                ConsoleInterfaceManager.DrawColoredText(new StringBuilder("Invalid data"), ConsoleColor.Red);
                return new Subject("Unknown");
            }
            Student selectedStudent = FindStudentByAlbumNumber(albumNumber);
            Subject? selectedSubject = null;

            if (selectedStudent.CourseSubjects != null)
            {
                foreach (var subject in selectedStudent.CourseSubjects)
                {
                    ConsoleInterfaceManager.DrawColoredText(subject.NameOfSubject, ConsoleColor.Green);
                    if (subject.NameOfSubject == subjectName)
                    {
                        selectedSubject = subject;
                        break;
                    }
                }
            }
            if (selectedSubject != null)
            {
                return selectedSubject;
            }
            else
            {
                ConsoleInterfaceManager.DrawColoredText(new StringBuilder("There is no such subject here"), ConsoleColor.Red);
                return new Subject("Unknown");
            }
            
        }
        public void UpdateStudentGrade(string subject, string albumNumber, int grade)
        {
            if (string.IsNullOrWhiteSpace(subject) || string.IsNullOrWhiteSpace(albumNumber))
            {
                ConsoleInterfaceManager.DrawColoredText(new StringBuilder("Invalid data. Something went wrong here :("), ConsoleColor.Red);
                return;
            }
            var selectedSubject = FindSubject(subject, albumNumber);

            selectedSubject.Grade = grade;
        }
        public void ShowCourseInfo(string albumNumber)
        {
            ConsoleColor passIndicator = ConsoleColor.Green;
            var selectedStudent = FindStudentByAlbumNumber(albumNumber);
            const int MIN_GRADE_TO_PASS_THE_LECTURE = 3;
            if (selectedStudent != null && selectedStudent.CourseSubjects != null)
            {
                foreach (var subject in selectedStudent.CourseSubjects)
                {
                    if (subject.Grade < MIN_GRADE_TO_PASS_THE_LECTURE)
                    {
                        passIndicator = ConsoleColor.Red;
                    }
                    ConsoleInterfaceManager.DrawColoredText($"{subject.NameOfSubject} - {subject.Grade}", passIndicator);
                    passIndicator = ConsoleColor.Green;
                }
            }
            else
            {
                ConsoleInterfaceManager.DrawColoredText(new StringBuilder("Something went wrong here"), ConsoleColor.Red);
            }
        }
    }
}