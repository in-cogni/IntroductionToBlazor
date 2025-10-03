using System.Globalization;
using BlazorAcademy.Models;

namespace BlazorAcademy.Data
{
    public static class CsvImporter
    {
        public static void ImportAllData(BlazorAcademyContext context)
        {
            Console.WriteLine("🔄 Импорт данных из CSV...");

            var csvFolder = Path.Combine(Directory.GetCurrentDirectory(), "Data", "CSV");

            try
            {
                // Импорт Directions
                if (File.Exists(Path.Combine(csvFolder, "Directions.csv")))
                {
                    var directions = ReadDirectionsCsv(Path.Combine(csvFolder, "Directions.csv"));
                    context.Directions.AddRange(directions);
                    context.SaveChanges();
                    Console.WriteLine($"✅ Направлений: {directions.Count}");
                }

                // Импорт Groups
                if (File.Exists(Path.Combine(csvFolder, "Groups.csv")))
                {
                    var groups = ReadGroupsCsv(Path.Combine(csvFolder, "Groups.csv"));
                    context.Groups.AddRange(groups);
                    context.SaveChanges();
                    Console.WriteLine($"✅ Групп: {groups.Count}");
                }

                // Импорт Students
                if (File.Exists(Path.Combine(csvFolder, "Students.csv")))
                {
                    var students = ReadStudentsCsv(Path.Combine(csvFolder, "Students.csv"));
                    context.Students.AddRange(students);
                    context.SaveChanges();
                    Console.WriteLine($"✅ Студентов: {students.Count}");
                }

                // Импорт Teachers
                if (File.Exists(Path.Combine(csvFolder, "Teachers.csv")))
                {
                    var teachers = ReadTeachersCsv(Path.Combine(csvFolder, "Teachers.csv"));
                    context.TeacherSimples.AddRange(teachers);
                    context.SaveChanges();
                    Console.WriteLine($"✅ Преподавателей: {teachers.Count}");
                }

                // Импорт Disciplines
                if (File.Exists(Path.Combine(csvFolder, "Disciplines.csv")))
                {
                    var disciplines = ReadDisciplinesCsv(Path.Combine(csvFolder, "Disciplines.csv"));
                    context.Disciplines.AddRange(disciplines);
                    context.SaveChanges();
                    Console.WriteLine($"✅ Дисциплин: {disciplines.Count}");
                }

                Console.WriteLine("🎉 Импорт данных завершен!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Ошибка импорта: {ex.Message}");
            }
        }

        private static List<Direction> ReadDirectionsCsv(string filePath)
        {
            var directions = new List<Direction>();

            if (!File.Exists(filePath))
                return directions;

            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length >= 2)
                {
                    var direction = new Direction
                    {
                        direction_id = byte.Parse(parts[0]), // int -> byte
                        direction_name = parts[1]
                    };
                    directions.Add(direction);
                }
            }

            return directions;
        }

        private static List<Group> ReadGroupsCsv(string filePath)
        {
            var groups = new List<Group>();

            if (!File.Exists(filePath))
                return groups;

            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length >= 5)
                {
                    // Преобразуем время из строки в TimeOnly
                    var timeParts = parts[4].Split(':');
                    var hours = int.Parse(timeParts[0]);
                    var minutes = timeParts.Length > 1 ? int.Parse(timeParts[1]) : 0;

                    var group = new Group
                    {
                        group_id = int.Parse(parts[0]),
                        group_name = parts[1],
                        direction = byte.Parse(parts[2]), // int -> byte
                        weekdays = byte.Parse(parts[3]),  // int -> byte
                        start_time = new TimeOnly(hours, minutes)
                    };
                    groups.Add(group);
                }
            }

            return groups;
        }

        private static List<Student> ReadStudentsCsv(string filePath)
        {
            var students = new List<Student>();

            if (!File.Exists(filePath))
                return students;

            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length >= 9)
                {
                    var student = new Student
                    {
                        stud_id = int.Parse(parts[0]),
                        last_name = parts[1],
                        first_name = parts[2],
                        middle_name = parts[3] == "NULL" ? null : parts[3],
                        birth_date = DateOnly.Parse(parts[4]),
                        email = parts[5] == "NULL" || string.IsNullOrEmpty(parts[5]) ? null : parts[5],
                        phone = parts[6] == "NULL" || string.IsNullOrEmpty(parts[6]) ? null : parts[6],
                        photo = null,
                        group = int.Parse(parts[8])
                    };
                    students.Add(student);
                }
            }

            return students;
        }

        private static List<TeacherSimple> ReadTeachersCsv(string filePath)
        {
            var teachers = new List<TeacherSimple>();

            if (!File.Exists(filePath))
                return teachers;

            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length >= 10)
                {
                    var teacher = new TeacherSimple
                    {
                        teacher_id = int.Parse(parts[0]),
                        last_name = parts[1],
                        first_name = parts[2],
                        middle_name = parts[3] == "NULL" ? null : parts[3],
                        birth_date = DateOnly.Parse(parts[4]),
                        email = parts[5] == "NULL" || string.IsNullOrEmpty(parts[5]) ? null : parts[5],
                        phone = parts[6] == "NULL" || string.IsNullOrEmpty(parts[6]) ? null : parts[6],
                        photo = null,
                        work_since = DateOnly.Parse(parts[8]),
                        rate = decimal.Parse(parts[9])
                    };
                    teachers.Add(teacher);
                }
            }

            return teachers;
        }

        private static List<Discipline> ReadDisciplinesCsv(string filePath)
        {
            var disciplines = new List<Discipline>();

            if (!File.Exists(filePath))
                return disciplines;

            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length >= 3)
                {
                    var discipline = new Discipline
                    {
                        discipline_id = short.Parse(parts[0]),
                        discipline_name = parts[1],
                        number_of_lessons = byte.Parse(parts[2]) // int -> byte
                    };
                    disciplines.Add(discipline);
                }
            }

            return disciplines;
        }
    }
}