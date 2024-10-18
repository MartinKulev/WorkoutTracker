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
            //Split split = new Split
            //{ 
            //    SplitToString = "Pull • Push • Legs • Pull • Push",
            //    DateStart = new DateTime(2024, 07, 31),
            //    DateEnd = DateTime.MinValue,
            //    WeekStart = 52,
            //    WeekEnd = 0
            //};
            //await _splitRepository.CreateAsync(split);

            //List<DayOfSplit> daysOfSplit =
            //[
            //    new DayOfSplit { Name = "Pull1", SplitId = 1, WorkoutCount = 60 },
            //    new DayOfSplit { Name = "Push1", SplitId = 1, WorkoutCount = 60 },
            //    new DayOfSplit { Name = "Legs", SplitId = 1, WorkoutCount = 60 },
            //    new DayOfSplit { Name = "Pull2", SplitId = 1, WorkoutCount = 60 },
            //    new DayOfSplit { Name = "Push2", SplitId = 1, WorkoutCount = 60 },
            //];
            //await _dayOfSplitRepository.CreateRangeAsync(daysOfSplit);

            //List<Exercise> exercises =
            //[
            //    new Exercise { Name = "Lat pulldown", Weight = 50, WorkoutId = 1 },
            //    new Exercise { Name = "Rowing machine", Weight = 00, WorkoutId = 1 },
            //    new Exercise { Name = "Barbell shoulder shrugs", Weight = 60, WorkoutId = 1 },
            //    new Exercise { Name = "Rear delt fly", Weight = 20, WorkoutId = 1 },
            //    new Exercise { Name = "Dumbbell curls 1/2", Weight = 30, WorkoutId = 1 },
            //    new Exercise { Name = "Wrist curls 1/2", Weight = 25, WorkoutId = 1 },
            //    new Exercise { Name = "Neck curls 1/2", Weight = 12, WorkoutId = 1 },
            //    new Exercise { Name = "Neck extensions 1/2", Weight = 7, WorkoutId = 1 },
            //];
            //await _exerciseRepository.CreateRangeAsync(exercises);

            //List<Exercise> exercises =
            //[
            //    new Exercise { Name = "Bench press pr", Weight = 50, WorkoutId = 2 },
            //    new Exercise { Name = "Cable chest fly", Weight = 00, WorkoutId = 2 },
            //    new Exercise { Name = "Shoulder dumbbell press", Weight = 60, WorkoutId = 2 },
            //    new Exercise { Name = "Dumbbell lateral raises", Weight = 20, WorkoutId = 2 },
            //    new Exercise { Name = "Dumbbell curls 1/2", Weight = 30, WorkoutId = 2 },
            //    new Exercise { Name = "Wrist curls 1/2", Weight = 25, WorkoutId = 2 },
            //    new Exercise { Name = "Neck curls 1/2", Weight = 12, WorkoutId = 2 },
            //    new Exercise { Name = "Neck extensions 1/2", Weight = 7, WorkoutId = 2 },
            //];
            //await _exerciseRepository.CreateRangeAsync(exercises);

            //List<Exercise> exercises =
            //[
            //    new Exercise { Name = "Hack squat", Weight = 30, WorkoutId = 3 },
            //    new Exercise { Name = "Leg press", Weight = 60, WorkoutId = 3 },
            //    new Exercise { Name = "Leg extension", Weight = 30, WorkoutId = 3 },
            //    new Exercise { Name = "Leg curl", Weight = 20, WorkoutId = 3 },
            //    new Exercise { Name = "Abductor machine in/out 1/2", Weight = 50, WorkoutId = 3 },
            //    new Exercise { Name = "Abductor machine out/in 1/2", Weight = 45, WorkoutId = 3 },
            //    new Exercise { Name = "Calf machine", Weight = 45, WorkoutId = 3 },
            //];
            //await _exerciseRepository.CreateRangeAsync(exercises);

            //List<Exercise> exercises =
            //[
            //    new Exercise { Name = "One-hand lat pulldown", Weight = 00, WorkoutId = 4 },
            //    new Exercise { Name = "One-hand cable row", Weight = 00, WorkoutId = 4 },
            //    new Exercise { Name = "Dumbbell shoulder shrugs", Weight = 45, WorkoutId = 4 },
            //    new Exercise { Name = "Face Pulls", Weight = 18, WorkoutId = 4 },
            //    new Exercise { Name = "Barbell curls 1/2", Weight = 30, WorkoutId = 4 },
            //    new Exercise { Name = "Reverse curls 1/2", Weight = 15, WorkoutId = 4 },
            //    new Exercise { Name = "Neck curls 1/2", Weight = 12, WorkoutId = 4 },
            //    new Exercise { Name = "Neck extensions 1/2", Weight = 7, WorkoutId = 4},
            //];
            //await _exerciseRepository.CreateRangeAsync(exercises);

            //List<Exercise> exercises =
            //[
            //    new Exercise { Name = "One-hand cable chest press", Weight = 00, WorkoutId = 5 },
            //    new Exercise { Name = "One-hand cable bench press", Weight = 20, WorkoutId = 5 },
            //    new Exercise { Name = "Machine shoulder press", Weight = 20, WorkoutId = 5 },
            //    new Exercise { Name = "Cable lateral raises", Weight = 15, WorkoutId = 5 },
            //    new Exercise { Name = "One-hand triceps pushdowns", Weight = 20, WorkoutId = 5 },
            //    new Exercise { Name = "Upper abdominal machine", Weight = 40, WorkoutId = 5 },
            //];
            //await _exerciseRepository.CreateRangeAsync(exercises);

            //Workout workout = new Workout
            //{
            //    DateWorkout = new DateTime(2024, 7, 31),
            //    DayOfSplitId = 5,
            //    Exercises = exercises
            //};
            //await _workoutRepository.CreateAsync(workout);
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

        [HttpGet("Home/PastSplit/{splitId}/{dayOfSplitId?}")]
        public async Task<IActionResult> PastSplit(int splitId, int? dayOfSplitId)
        {
            List<DayOfSplit> daysOfSplit = await _dayOfSplitRepository.GetAllDaysOfSplitBySplitId(splitId);

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

        [HttpPost]
        public async Task<IActionResult> AddWorkoutToDayOfSplit(int dayOfSplitId)
        {
            await _workoutRepository.CreateWorkoutToDayOfSplit(dayOfSplitId);
            DayOfSplit dayOfSplit = await _dayOfSplitRepository.GetDayOfSplitById(dayOfSplitId);
            dayOfSplit.WorkoutCount++;
            await _dayOfSplitRepository.UpdateAsync(dayOfSplit);
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

            workout.DateWorkout = model.DateWorkout;

            await _exerciseRepository.UpdateRangeAsync(exercisesToBeUpdated);
            await _workoutRepository.UpdateAsync(workout);
            return RedirectToAction("CurrentSplit", "Home", workout.DayOfSplitId);
        }

    }
}
