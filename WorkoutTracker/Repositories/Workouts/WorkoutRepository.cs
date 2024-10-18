using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Data;
using WorkoutTracker.Data.Entities;
using WorkoutTracker.Repositories.Base;

namespace WorkoutTracker.Repositories.Workouts
{
    public class WorkoutRepository : BaseRepository<Workout>, IWorkoutRepository
    {
        private WorkoutTrackerDbContext _context;

        public WorkoutRepository(WorkoutTrackerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Workout>> GetAllWorkoutsByDayOfSplitId(int dayOfSplitId)
        {
            return await _context.Workouts.Where(p => p.DayOfSplitId == dayOfSplitId).ToListAsync();
        }

        public async Task CreateWorkoutToDayOfSplit(int dayOfSplitId)
        {
            Workout workout = await _context.Workouts
                .OrderByDescending(p => p.DateWorkout)
                .Include(p => p.Exercises)
                .FirstAsync(p => p.DayOfSplitId == dayOfSplitId);

            Workout newWorkout = new Workout
            {
                DateWorkout = DateTime.Now,
                DayOfSplitId = dayOfSplitId,
                Exercises = new List<Exercise>() 
            };

            foreach (var exercise in workout.Exercises)
            {
                var newExercise = new Exercise
                {
                    Name = exercise.Name,
                    Weight = exercise.Weight,
                };

                newWorkout.Exercises.Add(newExercise);
            }

            await _context.AddAsync(newWorkout);
            await _context.SaveChangesAsync();

            foreach (var exercise in newWorkout.Exercises)
            {
                exercise.WorkoutId = newWorkout.Id;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<Workout> GetWorkoutById(int workoutId)
        {
            return await _context.Workouts.Include(p => p.Exercises).FirstAsync(p => p.Id == workoutId);
        }
    }
}
