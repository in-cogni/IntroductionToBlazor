//using Microsoft.EntityFrameworkCore;
//using BlazorAcademy.Models;

//namespace BlazorAcademy.Data
//{
//    public class DataMigrator
//    {
//        public static async Task MigrateFromSqlServer(BlazorAcademyContext sqliteContext)
//        {
//            Console.WriteLine("Начинаем миграцию данных из SQL Server...");

//            var sqlServerConnection = "Data Source=LALALA\\SQLEXPRES;Initial Catalog=PV_319_Import;Integrated Security=True;TrustServerCertificate=true";
//            var optionsBuilder = new DbContextOptionsBuilder<BlazorAcademyContext>();
//            optionsBuilder.UseSqlServer(sqlServerConnection);

//            using var sqlServerContext = new BlazorAcademyContext(optionsBuilder.Options);

//            try
//            {
//                if (await sqlServerContext.Directions.AnyAsync())
//                {
//                    var directions = await sqlServerContext.Directions.ToListAsync();
//                    sqliteContext.Directions.AddRange(directions);
//                    await sqliteContext.SaveChangesAsync();
//                    Console.WriteLine($" Перенесено направлений: {directions.Count}");
//                }

//                if (await sqlServerContext.Groups.AnyAsync())
//                {
//                    var groups = await sqlServerContext.Groups.ToListAsync();
//                    sqliteContext.Groups.AddRange(groups);
//                    await sqliteContext.SaveChangesAsync();
//                    Console.WriteLine($" Перенесено групп: {groups.Count}");
//                }

//                if (await sqlServerContext.Students.AnyAsync())
//                {
//                    var students = await sqlServerContext.Students.ToListAsync();
//                    sqliteContext.Students.AddRange(students);
//                    await sqliteContext.SaveChangesAsync();
//                    Console.WriteLine($" Перенесено студентов: {students.Count}");
//                }

//                if (await sqlServerContext.Disciplines.AnyAsync())
//                {
//                    var disciplines = await sqlServerContext.Disciplines.ToListAsync();
//                    sqliteContext.Disciplines.AddRange(disciplines);
//                    await sqliteContext.SaveChangesAsync();
//                    Console.WriteLine($" Перенесено дисциплин: {disciplines.Count}");
//                }

//                if (await sqlServerContext.Teachers.AnyAsync())
//                {
//                    var teachers = await sqlServerContext.Teachers.ToListAsync();
//                    var newTeachers = teachers.Select(t => new TeacherSimple
//                    {
//                        teacher_id = t.teacher_id,
//                        last_name = t.last_name ?? "",
//                        first_name = t.first_name ?? "",
//                        middle_name = t.middle_name,
//                        birth_date = t.birth_date,
//                        email = t.email,
//                        phone = t.phone,
//                        photo = t.photo,
//                        work_since = t.work_since,
//                        rate = t.rate
//                    }).ToList();

//                    sqliteContext.TeacherSimples.AddRange(newTeachers);
//                    await sqliteContext.SaveChangesAsync();
//                    Console.WriteLine($" Перенесено преподавателей: {newTeachers.Count}");
//                }

//                Console.WriteLine("Миграция данных завершена успешно!");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Ошибка миграции: {ex.Message}");
//            }
//        }
//    }
//}