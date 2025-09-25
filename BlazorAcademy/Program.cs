using BlazorAcademy.Components;
using Microsoft.EntityFrameworkCore;
using BlazorAcademy.Data;

var builder = WebApplication.CreateBuilder(args);

// БЕЗОПАСНАЯ регистрация БД
var connectionString = builder.Configuration.GetConnectionString("BlazorAcademyContext");

if (string.IsNullOrEmpty(connectionString))
{
    // Если нет строки подключения, используем InMemory
    builder.Services.AddDbContextFactory<BlazorAcademyContext>(options =>
        options.UseInMemoryDatabase("BlazorAcademy"));
    Console.WriteLine("Using InMemory database");
}
else
{
    // Если есть строка подключения, используем SQL Server
    builder.Services.AddDbContextFactory<BlazorAcademyContext>(options =>
        options.UseSqlServer(connectionString));
    Console.WriteLine($"Using SQL Server: {connectionString}");
}

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage(); // Детальные ошибки в development
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Автоматические миграции только для реальной БД
if (!string.IsNullOrEmpty(connectionString))
{
    try
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<BlazorAcademyContext>();
        context.Database.Migrate();
        Console.WriteLine("Database migrations applied successfully");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Database migration error: {ex.Message}");
    }
}

app.Run();