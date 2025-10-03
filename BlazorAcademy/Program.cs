using BlazorAcademy.Components;
using Microsoft.EntityFrameworkCore;
using BlazorAcademy.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<BlazorAcademyContext>(options =>
    options.UseSqlite("Data Source=app.db"));

builder.Services.AddQuickGridEntityFrameworkAdapter();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BlazorAcademyContext>();
    db.Database.EnsureCreated();

    if (!db.Students.Any())
    {
        Console.WriteLine("Добавляем начальные данные...");

        await db.SaveChangesAsync();
        Console.WriteLine("Начальные данные добавлены!");
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.Urls.Add("http://0.0.0.0:10000");
app.Run();