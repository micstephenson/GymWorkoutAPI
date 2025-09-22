using GymWorkoutAPI.Data;
using GymWorkoutAPI.Exceptions;
using GymWorkoutAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GymWorkoutAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymWorkoutController : ControllerBase
    {
        private readonly IWorkoutRepository workoutRepository;
        public GymWorkoutController(IWorkoutRepository workoutRepository)
        {
            this.workoutRepository = workoutRepository;
        }

        [HttpGet(Name = "Get all workouts")]
        public IActionResult GetAllWorkouts()
        {
            var workouts = workoutRepository.GetAll();
            
            if (workouts == null || !workouts.Any())
            {
                return NotFound("No Workouts found");
            }
            return Ok(workouts);
        }

        [HttpPost(Name = "Add a new Workout")]
        public IActionResult AddWorkout([FromBody] Workout workout)
        {
            if (workout == null)
            {
                return BadRequest("Workout data is null.");
            }
            workoutRepository.Add(workout);
            return CreatedAtAction(nameof(AddWorkout), new { id = workout.WorkoutID }, workout);
        }


        [HttpPut("update", Name = "Update a Workout")]
        public IActionResult UpdateWorkout(int id, [FromBody] Workout updatedWorkout)
        {
            if (updatedWorkout == null || updatedWorkout.WorkoutID != id)
            {
                return BadRequest("Invalid workout data");
            }

            var existingWorkout = workoutRepository.GetById(id);
            if (existingWorkout == null)
            {
                throw new WorkoutNotFoundException(id);
            }

            existingWorkout.WorkoutName = updatedWorkout.WorkoutName;
            existingWorkout.Duration = updatedWorkout.Duration;

            workoutRepository.Update(existingWorkout);
            return NoContent();
        }


        [HttpDelete("{id}", Name = "Remove a Workout")]
        public IActionResult RemoveWorkout(int id)
        {
            var workout = workoutRepository.GetById(id);
            if (workout == null)
            {
                return NotFound($"Workout with id {id} not found");
            }

            workoutRepository.Remove(id);
            return NoContent();

        }
    }
}