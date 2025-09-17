using GymWorkoutAPI.Data;
using GymWorkoutAPI.Exceptions;
using GymWorkoutAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymWorkoutAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalTrainerController : ControllerBase
    {
        private readonly ITrainerRepository trainerRepository;
        public PersonalTrainerController(ITrainerRepository trainerRepository)
        {
            this.trainerRepository = trainerRepository;
        }

        [HttpGet(Name = "Get all trainers")]
        public IActionResult GetAllTrainers()
        {
            var trainers = trainerRepository.GetAll();

            if (trainers == null || !trainers.Any())
            {
                return NotFound("No Personal Trainers found");
            }
            return Ok(trainers);
        }

        [HttpPost(Name = "Add a new Trainer")]
        public IActionResult AddTrainer([FromBody] Trainer trainer)
        {
            if (trainer == null)
            {
                return BadRequest("Trainer data is null.");
            }
            trainerRepository.Add(trainer);
            return CreatedAtAction(nameof(AddTrainer), new { id = trainer.TrainerID }, trainer);
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