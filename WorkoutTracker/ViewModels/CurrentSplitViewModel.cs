﻿using WorkoutTracker.Data.Entities;

namespace WorkoutTracker.ViewModels
{
    public class CurrentSplitViewModel
    {
        public List<DayOfSplit> DayOfSplits { get; set; }

        public int DayOfSplitId { get; set; }
    }
}
