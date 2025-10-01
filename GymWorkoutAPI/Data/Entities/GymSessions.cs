using System.ComponentModel.DataAnnotations;

namespace GymWorkoutAPI.Data.Entity;
public class GymSessions
{
    [Key]
    public int SessionID { get; set; }
    public DateTime? SessionDate { get; set; }
    public double OverallDuration { get; set; }
    public int TrainerID { get; set; }
}
