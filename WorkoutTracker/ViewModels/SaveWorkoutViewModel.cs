namespace WorkoutTracker.ViewModels
{
    public class SaveWorkoutModel
    {
        public int WorkoutId { get; set; }

        public DateTime DateWorkout { get; set; }

        public List<ExerciseViewModel> Exercises { get; set; }
    }

}
