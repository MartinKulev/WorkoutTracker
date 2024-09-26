namespace WorkoutTracker.Data.Entities
{
    public class Exercise
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Weight { get; set; }

        public int WorkoutId { get; set; }
    }
}
