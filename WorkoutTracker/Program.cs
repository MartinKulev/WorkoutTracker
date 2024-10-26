using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WorkoutTracker.Data;
using WorkoutTracker.Repositories.DaysOfSplit;
using WorkoutTracker.Repositories.Exercises;
using WorkoutTracker.Repositories.Splits;
using WorkoutTracker.Repositories.Workouts;
using WorkoutTracker.Services.DaysOfSplit;
using WorkoutTracker.Services.Exercises;
using WorkoutTracker.Services.Splits;
using WorkoutTracker.Services.Workouts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Configuration.AddJsonFile(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "GitSecrets.json"), optional: true);
string? connectionString = builder.Configuration.GetConnectionString("WorkoutTracker") ?? builder.Configuration.GetConnectionString("DefaultConnection")!;

builder.Services.AddDbContext<WorkoutTrackerDbContext>(options => options.UseMySQL(connectionString));


builder.Services.AddScoped<IDayOfSplitRepository, DayOfSplitRepository>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<ISplitRepository, SplitRepository>();
builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>();

builder.Services.AddScoped<IDayOfSplitService, DayOfSplitService>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<ISplitService, SplitService>();
builder.Services.AddScoped<IWorkoutService, WorkoutService>();


var app = builder.Build();
//OpenBrowser("http://localhost:5000");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=SplitHistory}/{id?}");

app.Run();


static void OpenBrowser(string url)
{
    try
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true // Use default browser
        });
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Failed to open browser: {ex.Message}");
    }
}