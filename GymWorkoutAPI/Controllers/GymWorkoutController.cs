using GymWorkoutAPI.DataTransferObjects;
using GymWorkoutAPI.Exceptions;
using GymWorkoutAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymWorkoutAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GymWorkoutController(IWorkoutService workoutService) : ControllerBase
{
    [HttpGet(Name = "Get all workouts")]
    public IActionResult GetAllWorkouts()
    {
        var workouts = workoutService.GetAllWorkouts();
        
        if (workouts == null || !workouts.Any())
        {
            return NotFound("No Workouts found");
        }
        return Ok(workouts);
    }

    [HttpPost(Name = "Add a new Workout")]
    public IActionResult AddWorkout([FromBody] WorkoutDto workout)
    {
        if (workout == null)
        {
            return BadRequest("Workout data is null.");
        }
        workoutService.CreateWorkout(workout);
        return Ok("Workout added successfully.");
    }


    [HttpPut("update", Name = "Update a Workout")]
    public IActionResult UpdateWorkout(int id, [FromBody] WorkoutDto updatedWorkout)
    {
        if (updatedWorkout == null)
            return BadRequest("Invalid workout data");
     

        workoutService.UpdateWorkout(id, updatedWorkout);
        return NoContent();
    }

    [HttpDelete("{id}", Name = "Remove a Workout")]
    public IActionResult RemoveWorkout(int id)
    {
        var workout = workoutService.GetWorkoutById(id);
        if (workout == null)
        {
            return NotFound($"Workout with id {id} not found");
        }

        workoutService.RemoveWorkout(id);
        return NoContent();

    }
}