namespace WorkoutTracker.Data.Entities
{
    public class Workout
    {
        public int Id { get; set; }

        public DateTime DateWorkout { get; set; }

        public string DayOfSplitId { get; set; }
    }
}
