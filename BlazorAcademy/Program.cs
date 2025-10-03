using BlazorAcademy.Components;
using Microsoft.EntityFrameworkCore;
using BlazorAcademy.Data;

var builder = WebApplication.CreateBuilder(args);

// SQLite
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
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();