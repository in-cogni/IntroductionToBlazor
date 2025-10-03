using Microsoft.EntityFrameworkCore;
using BlazorAcademy.Models;

namespace BlazorAcademy.Data
{
    public static class DataMigrator
    {
        public static async Task MigrateFromSqlServer(BlazorAcademyContext sqliteContext)
        {
            Console.WriteLine("?? �������� ������ �� SQL Server...");

            try
            {
                // ����������� � SQL Server
                var sqlServerConnection = "Data Source=LALALA\\SQLEXPRES;Initial Catalog=PV_319_Import;Integrated Security=True;TrustServerCertificate=true";
                var optionsBuilder = new DbContextOptionsBuilder<BlazorAcademyContext>();
                optionsBuilder.UseSqlServer(sqlServerConnection);

                using var sqlServerContext = new BlazorAcademyContext(optionsBuilder.Options);

                // �������� ������
                await MigrateTable(sqlServerContext.Directions, sqliteContext.Directions, "�����������");
                await MigrateTable(sqlServerContext.Groups, sqliteContext.Groups, "������");
                await MigrateTable(sqlServerContext.Students, sqliteContext.Students, "��������");
                await MigrateTable(sqlServerContext.Disciplines, sqliteContext.Disciplines, "����������");

                Console.WriteLine("? �������� ���������!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"? ������ ��������: {ex.Message}");
            }
        }

        private static async Task MigrateTable<T>(IQueryable<T> source, DbSet<T> destination, string tableName) where T : class
        {
            if (await source.AnyAsync())
            {
                var data = await source.ToListAsync();
                destination.AddRange(data);
                await destination.Context.SaveChangesAsync();
                Console.WriteLine($"? {tableName}: {data.Count} �������");
            }
        }
    }
}