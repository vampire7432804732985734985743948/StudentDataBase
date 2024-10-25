using System;
using System.IO;
using System.Text;
using System.Text.Json;

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
                File.AppendAllText(filePath, SerializeData(data));
                ConsoleInterfaceManager.DrawColoredText(new StringBuilder("The file was saved in: " + filePath), ConsoleColor.Green);
            }
            else
            {
                Console.WriteLine("The datum is empty");
            }
        }

        public static T DeserializeData<T>()
        {
            if (filePath != null && File.Exists(filePath))
            {
                var jsonString = File.ReadAllText(filePath);
                if (jsonString != null && !string.IsNullOrEmpty(jsonString))
                    return JsonSerializer.Deserialize<T>(jsonString);
                else
                    throw new ArgumentException("File is empty");
            }
            else
            {
                throw new ArgumentException("There is no such directory");
            }
        }
    }
}
