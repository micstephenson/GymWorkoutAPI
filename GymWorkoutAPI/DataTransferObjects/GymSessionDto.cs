namespace GymWorkoutAPI.DataTransferObjects;

public class GymSessionDto
{
    public DateTime? SessionDate { get; set; }
    public double OverallDuration { get; set; }
    public int TrainerID { get; set; }
}
