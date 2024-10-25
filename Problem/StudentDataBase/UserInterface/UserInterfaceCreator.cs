using Problem.StudentDataBase.DataContainer;
using Problem.StudentDataBase.TechnicalStuff;
using Problem.StudentDataBase.UserLogIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.StudentDataBase.UserInterface
{
    internal class UserInterfaceCreator
    {
        private User _user = new User();
        private StudentDataBase _studentDataBase = new StudentDataBase();

        public void CreateUserInterface()
        {
            _user.SelectLecturer();

            while (true)
            {
                ShowNavigation();
                InputCommand();
            }
        }

        private void ShowNavigation()
        {
            ConsoleInterfaceManager.CentralizeText("-----Navigation----");
            Console.WriteLine("1 = Add student to the list");
            Console.WriteLine("2 = Remove student by id");
            Console.WriteLine("3 = Show list of students");
            Console.WriteLine("4 = Sort students by first name");
            Console.WriteLine("5 = Sort students by last name");
            Console.WriteLine("6 = Find student by pessel number");
            Console.WriteLine("7 = Save data");
            Console.WriteLine("8 = Clear console");
        }

        private void InputCommand()
        {
            var key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.D1:
                    _studentDataBase.AddStudent();
                    break;

                case ConsoleKey.D2:
                    Console.Write("Enter student album number: ");
                    int albumNumber = Convert.ToInt32(Console.ReadLine());
                    _studentDataBase.DeleteStudentById(albumNumber.ToString());
                    break;

                case ConsoleKey.D3:
                    _studentDataBase.ShowAllStudents();
                    break;

                case ConsoleKey.D4:
                    _studentDataBase.SortByFirstName();
                    break;

                case ConsoleKey.D5:
                    _studentDataBase.SortByLastName();
                    break;

                case ConsoleKey.D6:
                    Console.Write("Enter student pessel number: ");
                    int pesselNumber = Convert.ToInt32(Console.ReadLine());
                    _studentDataBase.FindStudentByPessel(pesselNumber.ToString());
                    break;
                case ConsoleKey.D7:
                    _studentDataBase.SaveAllData();
                    break;
                case ConsoleKey.D8:
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose a valid option from the menu.");
                    break;
            }
        }
    }
}
