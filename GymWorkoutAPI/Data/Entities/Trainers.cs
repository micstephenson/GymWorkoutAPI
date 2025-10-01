using System.ComponentModel.DataAnnotations;

namespace GymWorkoutAPI.Data.Entity;
public class Trainers
{
    [Key]
    public int TrainerID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}
