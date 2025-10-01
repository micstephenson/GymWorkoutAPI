namespace GymWorkoutAPI.DataTransferObjects;

public class WorkoutDto
{
    public string? WorkoutName { get; set; }
    public int? Reps { get; set; }
    public int? WorkoutSets { get; set; }
    public double? Duration { get; set; }
    public string Difficulty { get; set; }
}

//    public Difficulty Difficulty { get; set; }
//}

//public enum Difficulty
//{
//    Low = 1,
//    Medium = 2,
//    High = 3
//}