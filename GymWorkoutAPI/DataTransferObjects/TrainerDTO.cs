using GymWorkoutAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace GymWorkoutAPI.DataTransferObjects;
public class TrainerDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

}
