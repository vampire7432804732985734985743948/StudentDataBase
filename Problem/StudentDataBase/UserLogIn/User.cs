using Problem.StudentDataBase.DataContainer;
using Problem.StudentDataBase.TechnicalStuff;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem.StudentDataBase.UserLogIn
{
    internal class User
    {
        private bool IsLoginAccepted(string albumNumber, string password)
        {
            if (!string.IsNullOrWhiteSpace(albumNumber) && !string.IsNullOrWhiteSpace(password))
            {
                if (VerifyLecturerCredentials(albumNumber, password))
                {
                    ConsoleInterfaceManager.DrawColoredText("Login successful!", ConsoleColor.Green);
                    return true;
                }
                else
                {
                    ConsoleInterfaceManager.DrawColoredText("Login failed: Invalid album number or password!", ConsoleColor.Red);
                    return false;
                }
            }
            else { return false; }
        }
        public void SelectLecturer()
        {
            Lecturer? selectedLecturer = null;
            List<Lecturer> lecturers = GetLecturerDataBase();

            string album = GetUserAlbumNumber();
            string password = GetUserPassword();

            foreach (var lecturer in lecturers)
            {
                if (!string.IsNullOrWhiteSpace(lecturer.AlbumNumber) && !string.IsNullOrWhiteSpace(lecturer.Password))
                {
                    if (lecturer.AlbumNumber == album && IsLoginAccepted(album, password))
                    {
                        selectedLecturer = lecturer;
                        break;
                    }
                }
            }
            if (selectedLecturer != null)
            {
                ShowUserInfo(selectedLecturer);
            }
            else
            {
                ConsoleInterfaceManager.DrawColoredText("Not a single datum is here", ConsoleColor.Red);
                SelectLecturer();
            }
        }
        private bool VerifyLecturerCredentials(string albumNumber, string enteredPassword)
        {
            var lecturer = FindLecturerByAlbumNumber(albumNumber);

            if (lecturer == null || string.IsNullOrWhiteSpace(lecturer.Password))
            {
                Console.WriteLine("Lecturer not found.");
                return false;
            }
            else
            {
                return PasswordHasher.VerifyPassword(enteredPassword, lecturer.Password);
            }

        }

        private string GetUserAlbumNumber()
        {
            Console.Write("Enter your album number: ");
            string? album = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(album))
            {
                return album;
            }
            else
            {
                throw new ArgumentException("Invalid album number");
            }
        }
        private string GetUserPassword()
        {
            Console.Write("Enter your password: ");
            string? password = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(password))
            {
                return password;
            }
            else
            {
                throw new ArgumentException("Invalid album number");
            }
        }
        private Lecturer? FindLecturerByAlbumNumber(string albumNumber)
        {
            var lecturers = GetLecturerDataBase();
            return lecturers.FirstOrDefault(lecturer => lecturer.AlbumNumber == albumNumber);
        }
        private List<Lecturer> GetLecturerDataBase()
        {
            return JSONSerializer.DeserializeData<List<Lecturer>>("Lecturers.json");
        }
        private void ShowUserInfo(Lecturer lecturer)
        {
            Console.WriteLine($"Name: {lecturer.Name}");
            Console.WriteLine($"Last name: {lecturer.LastName}");
            Console.WriteLine($"Sex: {lecturer.Sex}");
            Console.WriteLine($"Pessel: {lecturer.PesselNumber}");
            Console.WriteLine($"Album number: {lecturer.AlbumNumber}");
            Console.WriteLine($"Address: {lecturer.Address}");
            Console.WriteLine($"Specialization: {lecturer.Specialization}");
        }
    }
}
