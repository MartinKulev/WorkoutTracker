namespace WorkoutTracker.Data.Entities
{
    public class Split
    {
        public int Id { get; set; }

        public string SplitToString { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public int WeekStart { get; set; }

        public int WeekEnd { get; set; }
    }
}
