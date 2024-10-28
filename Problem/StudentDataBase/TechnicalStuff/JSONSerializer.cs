using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Problem.StudentDataBase.Courses;

namespace Problem.StudentDataBase.TechnicalStuff
{
    internal static class JSONSerializer
    {
        static public string folderName = "UniversityData";
        static public string fileName = "JSONStudentDataBase.json";
        static string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), folderName);
        static public string filePath = Path.Combine(folderPath, fileName);

        private static string SerializeData<T>(T data)
        {
            var serializedObject = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            return serializedObject.ToString();
        }
        public static void SaveAllData<T>(T data)
        {
            if (data != null)
            {
                Directory.CreateDirectory(folderPath);

                File.Create(filePath).Close();
                File.WriteAllText(filePath, SerializeData(data));

                ConsoleInterfaceManager.DrawColoredText(new StringBuilder("The file was saved in: " + filePath), ConsoleColor.Green);
            }
            else
            {
                Console.WriteLine("The data are empty");
            }
        }

        public static T DeserializeData<T>(string readingFileName)
        {
            // Assuming folderPath is defined somewhere in your class
            string readingFilePath = Path.Combine(folderPath, readingFileName);

            if (string.IsNullOrEmpty(readingFilePath) || !File.Exists(readingFilePath))
            {
                throw new ArgumentException("There is no such file or directory");
            }

            // Read the file content
            string jsonString = File.ReadAllText(readingFilePath);

            if (string.IsNullOrWhiteSpace(jsonString))
            {
                throw new ArgumentException("File is empty");
            }

            try
            {
                // Deserialize the JSON data with options
                return JsonSerializer.Deserialize<T>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true, // Allows case-insensitive property matching
                    Converters = { new CourseClassConverter() } // Add your custom converters
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during deserialization: {ex.Message}");
                throw; // Re-throwing to allow upper layers to handle it
            }
        }

    }
}
