using Microsoft.EntityFrameworkCore;
using BlazorAcademy.Models;

namespace BlazorAcademy.Data
{
    public static class DataMigrator
    {
        public static async Task MigrateFromSqlServer(BlazorAcademyContext sqliteContext)
        {
            Console.WriteLine("?? Миграция данных из SQL Server...");

            try
            {
                // Подключение к SQL Server
                var sqlServerConnection = "Data Source=LALALA\\SQLEXPRES;Initial Catalog=PV_319_Import;Integrated Security=True;TrustServerCertificate=true";
                var optionsBuilder = new DbContextOptionsBuilder<BlazorAcademyContext>();
                optionsBuilder.UseSqlServer(sqlServerConnection);

                using var sqlServerContext = new BlazorAcademyContext(optionsBuilder.Options);

                // Миграция данных
                await MigrateDirections(sqlServerContext, sqliteContext);
                await MigrateGroups(sqlServerContext, sqliteContext);
                await MigrateStudents(sqlServerContext, sqliteContext);
                await MigrateDisciplines(sqlServerContext, sqliteContext);

                Console.WriteLine("? Миграция завершена!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"? Ошибка миграции: {ex.Message}");
            }
        }

        private static async Task MigrateDirections(BlazorAcademyContext source, BlazorAcademyContext destination)
        {
            if (await source.Directions.AnyAsync())
            {
                var data = await source.Directions.ToListAsync();
                destination.Directions.AddRange(data);
                await destination.SaveChangesAsync();
                Console.WriteLine($"? Направления: {data.Count} записей");
            }
        }

        private static async Task MigrateGroups(BlazorAcademyContext source, BlazorAcademyContext destination)
        {
            if (await source.Groups.AnyAsync())
            {
                var data = await source.Groups.ToListAsync();
                destination.Groups.AddRange(data);
                await destination.SaveChangesAsync();
                Console.WriteLine($"? Группы: {data.Count} записей");
            }
        }

        private static async Task MigrateStudents(BlazorAcademyContext source, BlazorAcademyContext destination)
        {
            if (await source.Students.AnyAsync())
            {
                var data = await source.Students.ToListAsync();
                destination.Students.AddRange(data);
                await destination.SaveChangesAsync();
                Console.WriteLine($"? Студенты: {data.Count} записей");
            }
        }

        private static async Task MigrateDisciplines(BlazorAcademyContext source, BlazorAcademyContext destination)
        {
            if (await source.Disciplines.AnyAsync())
            {
                var data = await source.Disciplines.ToListAsync();
                destination.Disciplines.AddRange(data);
                await destination.SaveChangesAsync();
                Console.WriteLine($"? Дисциплины: {data.Count} записей");
            }
        }
    }
}