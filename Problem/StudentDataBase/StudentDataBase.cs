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
                    ConsoleInterfaceManager.DrawColoredText("Invalid data", ConsoleColor.Red);
                    _numberOfSubjects = 1;
                }
            }
        }

        public StudentDataBase()
        {
            _students = JSONSerializer.DeserializeData<List<Student>>("JSONStudentDataBase.json");
        }
        private (string? name, string? lastName, string? sex, string? pesselNumber, string? albumNumber, string? password, string? address, Course? fieldOfStudy) AddStudentData()
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
            Console.WriteLine($"Pessel {student.PesselNumber}");
            Console.WriteLine($"Album number {student.AlbumNumber}");
            Console.WriteLine($"Address {student.Address}");
            
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
                ConsoleInterfaceManager.DrawColoredText("There are no students!", ConsoleColor.Red);
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
                ConsoleInterfaceManager.DrawColoredText("Database  is empty",  ConsoleColor.Red);
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
                    ConsoleInterfaceManager.DrawColoredText("Invalid input", ConsoleColor.Red);
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
                    ConsoleInterfaceManager.DrawColoredText("There is no such student here", ConsoleColor.Red);
                    return new Student(default, default, default, default, default, default, default, default);
                }
            }
            else
            {
                ConsoleInterfaceManager.DrawColoredText("Database is empty", ConsoleColor.Red);
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
                    ConsoleInterfaceManager.DrawColoredText("There are no such students here", ConsoleColor.Red);
                    return new List<Student>();
                }
                else
                {
                    return students;      
                }
            }
            else
            {
                ConsoleInterfaceManager.DrawColoredText("The database is empty", ConsoleColor.Red);
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
                ConsoleInterfaceManager.DrawColoredText("There is no  such student", ConsoleColor.Red);
                return;
            }
            else
            {
                ConsoleInterfaceManager.DrawColoredText("The database is empty", ConsoleColor.Red);
            }
        }
    }
}