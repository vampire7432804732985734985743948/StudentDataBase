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
            if (!string.IsNullOrEmpty(albumNumber) && !string.IsNullOrEmpty(password))
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

        public void CreateUserInterface()
        {
            Lecturer selectedLecturer = new Lecturer(default, default, default, default, default, default, default);
            List<Lecturer> lecturers = GetLecturerDataBase();
            foreach (var lecturer in lecturers)
            {
                if (!string.IsNullOrEmpty(lecturer.AlbumNumber) && !string.IsNullOrEmpty(lecturer.Password))
                {
                    if (IsLoginAccepted(lecturer.AlbumNumber, lecturer.Password))
                    {
                        selectedLecturer = lecturer;
                        break;
                    }
                }
            }
            if (selectedLecturer != null)
            {
                Console.WriteLine(selectedLecturer.Name);
            }
            else
            {
                ConsoleInterfaceManager.DrawColoredText("Login failed: Invalid album number or password!", ConsoleColor.Red);
            }
        }
        private bool VerifyLecturerCredentials(string albumNumber, string enteredPassword)
        {
            var lecturer = FindLecturerByAlbumNumber(albumNumber);

            if (lecturer == null || string.IsNullOrEmpty(lecturer.Password))
            {
                Console.WriteLine("Lecturer not found.");
                return false;
            }

            return PasswordHasher.VerifyPassword(enteredPassword, lecturer.Password);
        }
        private Lecturer? FindLecturerByAlbumNumber(string albumNumber)
        {
            var lecturers = GetLecturerDataBase();
            return lecturers.FirstOrDefault(l => l.AlbumNumber == albumNumber);
        }
        private List<Lecturer> GetLecturerDataBase()
        {
            return JSONSerializer.DeserializeData<List<Lecturer>>(JSONSerializer.filePath);
        }
    }
}
