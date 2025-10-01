using System.ComponentModel.DataAnnotations;

namespace GymWorkoutAPI.Data.Entity;
public class SessionWorkout
{
    [Key]
    public int SessionID { get; set; }
    public int WorkoutID { get; set; }
}
