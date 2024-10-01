using Microsoft.EntityFrameworkCore;
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

builder.Services.AddDbContext<WorkoutTrackerDbContext>(options =>
    options.UseMySQL("Server=mysql-210770ab-techstore.b.aivencloud.com;Database=workouttracker;Uid=avnadmin;Pwd=AVNS_ECNjUML_9rCSuGwr_PA;Port=15039"));

builder.Services.AddScoped<IDayOfSplitRepository, DayOfSplitRepository>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<ISplitRepository, SplitRepository>();
builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>();

builder.Services.AddScoped<IDayOfSplitService, DayOfSplitService>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<ISplitService, SplitService>();
builder.Services.AddScoped<IWorkoutService, WorkoutService>();


var app = builder.Build();


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
