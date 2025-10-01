namespace GymWorkoutAPI.DataTransferObjects;

public class SessionWorkoutDetailDto
{
    public int SessionID { get; set; }
    public DateTime? SessionDate { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int WorkoutID { get; set; }
    public int TrainerID { get; set; }
    public string WorkoutName { get; set; }
    public int WorkoutSets { get; set; }
    public int Reps { get; set; }
    public double SessionDuration { get; set; }
    
}
