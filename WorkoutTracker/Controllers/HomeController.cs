using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using WorkoutTracker.Data.Entities;
using WorkoutTracker.Repositories.DaysOfSplit;
using WorkoutTracker.Repositories.Exercises;
using WorkoutTracker.Repositories.Splits;
using WorkoutTracker.Repositories.Workouts;
using WorkoutTracker.Services.DaysOfSplit;
using WorkoutTracker.Services.Exercises;
using WorkoutTracker.Services.Splits;
using WorkoutTracker.Services.Workouts;
using WorkoutTracker.ViewModels;

namespace WorkoutTracker.Controllers
{
    public class HomeController : Controller
    {
        private IDayOfSplitRepository _dayOfSplitRepository;
        private IExerciseRepository _exerciseRepository;
        private ISplitRepository _splitRepository;
        private IWorkoutRepository _workoutRepository;

        public HomeController(IDayOfSplitRepository dayOfSplitRepository, IExerciseRepository exerciseRepository, ISplitRepository splitRepository, IWorkoutRepository workoutRepository)
        {
            _dayOfSplitRepository = dayOfSplitRepository;
            _exerciseRepository = exerciseRepository;
            _splitRepository = splitRepository;
            _workoutRepository = workoutRepository;
        }

        public async Task<IActionResult> Index()
        {
            //List<DayOfSplit> daysOfSplit =
            //[
            //    new DayOfSplit { Name = "Pull1", SplitId = 1, WorkoutCount = 60 },
            //    new DayOfSplit { Name = "Push1", SplitId = 1, WorkoutCount = 60 },
            //    new DayOfSplit { Name = "Legs", SplitId = 1, WorkoutCount = 60 },
            //    new DayOfSplit { Name = "Pull2", SplitId = 1, WorkoutCount = 60 },
            //    new DayOfSplit { Name = "Push2", SplitId = 1, WorkoutCount = 60 },
            //];
            //await _dayOfSplitRepository.CreateRangeAsync(daysOfSplit);

            //Split split = new Split
            //{ 
            //    SplitToString = "Pull • Push • Legs • Pull • Push",
            //    DateStart = new DateTime(2024, 07, 31),
            //    DateEnd = DateTime.MinValue,
            //    WeekStart = 52,
            //    WeekEnd = 0
            //};
            //await _splitRepository.CreateAsync(split);

            //Workout workout = new Workout
            //{
            //    DateWorkout = new DateTime(2024, 11, 4),
            //    DayOfSplitId = 1,
            //};
            //await _workoutRepository.CreateAsync(workout);

            //List<Exercise> exercises =
            //[
            //    new Exercise { Name = "Lat pulldown", Weight = 60, WorkoutId = 1 },
            //    new Exercise { Name = "Rowing machine", Weight = 60, WorkoutId = 1 },
            //    new Exercise { Name = "Barbell shoulder shrugs", Weight = 60, WorkoutId = 1 },
            //    new Exercise { Name = "Rear delt fly", Weight = 25, WorkoutId = 1 },
            //    new Exercise { Name = "Dumbbell curls 1/2", Weight = 30, WorkoutId = 1 },
            //    new Exercise { Name = "Wrist curls 1/2", Weight = 25, WorkoutId = 1 },
            //    new Exercise { Name = "Neck curls", Weight = 12, WorkoutId = 1 },
            //    new Exercise { Name = "Neck extensions", Weight = 09, WorkoutId = 1 },
            //];
            //await _exerciseRepository.CreateRangeAsync(exercises);

            //Workout workout = new Workout
            //{
            //    DateWorkout = new DateTime(2024, 11, 4),
            //    DayOfSplitId = 1,
            //    Exercises = exercises
            //};
            //await _workoutRepository.CreateAsync(workout);

            //List<Workout> workouts = await _workoutRepository.GetAllWorkoutsByDayOfSplitId(1);
            //Workout workout = workouts.First(p => p.DateWorkout == workouts.Max(p => p.DateWorkout));
            //await _workoutRepository.DeleteAsync(workout);



            return View();
        }

        public async Task<IActionResult> SplitHistory()
        {
            List<Split> splits = await _splitRepository.GetAllAsync();
            SplitHistoryViewModel vm = new SplitHistoryViewModel
            {
                Splits = splits
            };

            return View(vm);
        }

        [HttpGet("Home/CurrentSplit/{dayOfSplitId?}")]
        public async Task<IActionResult> CurrentSplit(int? dayOfSplitId)
        {
            List<DayOfSplit> daysOfSplit = await _dayOfSplitRepository.GetAllDaysOfSplitFromCurrentSplit();
            if (dayOfSplitId == null)
            {
                dayOfSplitId = daysOfSplit.First(p => p.Id == daysOfSplit.Min(p => p.Id)).Id;
            }

            CurrentSplitViewModel vm = new CurrentSplitViewModel
            {
                DayOfSplits = daysOfSplit,
                DayOfSplitId = (int)dayOfSplitId
            };

            return View(vm);
        }

        public async Task<IActionResult> PastSplit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkoutToDayOfSplit(int dayOfSplitId)
        {
            await _workoutRepository.CreateWorkoutToDayOfSplit(dayOfSplitId);
            return RedirectToAction("CurrentSplit", "Home", dayOfSplitId);
        }

        [HttpPost]
        public async Task<IActionResult> SaveChangesToWorkout(SaveWorkoutModel model)
        {
            Workout workout = await _workoutRepository.GetWorkoutById(model.WorkoutId);
            List<Exercise> exercisesToBeUpdated = new List<Exercise>();

            foreach (var exercise in model.Exercises)
            {
                var existingExercise = workout.Exercises.First(e => e.Id == exercise.Id);
                existingExercise.Weight = exercise.Weight;
                exercisesToBeUpdated.Add(existingExercise);
            }

            await _exerciseRepository.UpdateRangeAsync(exercisesToBeUpdated);
            return RedirectToAction("CurrentSplit", "Home", workout.DayOfSplitId);
        }

    }
}
