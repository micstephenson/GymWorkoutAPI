using GymWorkoutAPI.DataTransferObjects;
using GymWorkoutAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymWorkoutAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalTrainerController(ITrainerService trainerService) : ControllerBase
    {
        [HttpGet(Name = "Get all trainers")]
        public IActionResult GetAllTrainers()
        {
            var trainers = TrainerService.GetAllTrainers();

            if (trainers == null || !trainers.Any())
            {
                return NotFound("No Personal Trainers found");
            }
            return Ok(trainers);
        }

        [HttpPost(Name = "Add a new Trainer")]
        public IActionResult AddTrainer([FromBody] TrainerDTO trainerDTO)
        {
            if (trainerDTO == null)
            {
                return BadRequest("Trainer data is null.");
            }

            trainerService.CreateTrainer(trainerDTO);

            return Created();
        }

        [HttpDelete("{id}", Name = "Remove a Trainer")]
        public IActionResult RemoveTrainer(int id)
        {
            var trainer = trainerRepository.GetById(id);
            if (trainer == null)
            {
                return NotFound($"Trainer with id {id} not found");
            }

            trainerRepository.Remove(id);
            return NoContent();

        }
    }
}