namespace WorkoutTracker.Data.Entities
{
    public class DayOfSplit
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int WorkoutCount { get; set; }

        public int SplitId { get; set; }
    }
}
