namespace GymWorkoutAPI.DataTransferObjects;

public class WorkoutDto
{
    public string? WorkoutName { get; set; }
    public int? Reps { get; set; }
    public int? WorkoutSets { get; set; }
    public double? Duration { get; set; }
    public string Difficulty { get; set; }
}
