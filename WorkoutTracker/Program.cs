using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Globalization;
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

builder.Services.AddDbContext<WorkoutTrackerDbContext>(options => options.UseNpgsql(connectionString));


builder.Services.AddTransient<IDayOfSplitRepository, DayOfSplitRepository>();
builder.Services.AddTransient<IExerciseRepository, ExerciseRepository>();
builder.Services.AddTransient<ISplitRepository, SplitRepository>();
builder.Services.AddTransient<IWorkoutRepository, WorkoutRepository>();

builder.Services.AddTransient<IDayOfSplitService, DayOfSplitService>();
builder.Services.AddTransient<IExerciseService, ExerciseService>();
builder.Services.AddTransient<ISplitService, SplitService>();
builder.Services.AddTransient<IWorkoutService, WorkoutService>();


var app = builder.Build();

var cultureInfo = new CultureInfo("en-GB"); // Use dd.MM.yyyy format
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
app.Use(async (context, next) =>
{
    CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
    CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
    await next();
});
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
    pattern: "{controller=Home}/{action=CurrentSplit}/{id?}");

app.MapGet("/", context =>
{
    context.Response.Redirect("/Home/CurrentSplit");
    return Task.CompletedTask;
});

app.Run();