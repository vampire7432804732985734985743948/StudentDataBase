using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Problem.StudentDataBase
{
    internal static class JSONSerializer
    {
        public static string SerializeData<T>(T data)
        {
            var serializedObject = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            return serializedObject.ToString();
        }
        public static void SaveAllData<T>(T data)
        {
            string fileName = "JSONStudentDataBase.json";
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);
            File.Create(filePath).Close();
            File.WriteAllText(filePath, Convert.ToString(data));
            ConsoleInterfaceManager.DrawColoredText(new StringBuilder("The file was saved in: " + filePath), ConsoleColor.Green);
        }
       
        public static T DeserializeData<T>(string filePath)
        {
           
            var jsonString = File.ReadAllText(filePath);
            if (jsonString == null)
                throw new ArgumentException("File is empty");
            else
                return JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}
