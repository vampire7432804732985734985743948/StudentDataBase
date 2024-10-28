using Problem.StudentDataBase.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Problem.StudentDataBase.TechnicalStuff
{
    internal class CourseClassConverter : JsonConverter<Course>
    {
        public override Course Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                var jsonObject = doc.RootElement;
                var fieldOfStudy = jsonObject.GetProperty("CourseName").GetString();

                return fieldOfStudy?.ToLower() switch
                {
                    "computer science" => new ComputerScienceCourse(),
                    "management" => new ManagementCourse(),
                    "logistics" => new LogisticsCourse(),
                    "economics" => new EconomicsCourse(),
                    "nursing" => new NursingCourse(),
                    "psychology" => new PsychologyCourse(),
                    _ => throw new NotSupportedException($"Unknown course type: {fieldOfStudy}")
                };
            }
        }

        public override void Write(Utf8JsonWriter writer, Course value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}
