using GymWorkoutAPI.DataTransferObjects;
using GymWorkoutAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymWorkoutAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonalTrainerController(ITrainerService trainerService) : ControllerBase
{
    [HttpGet(Name = "Get all trainers")]
    public IActionResult GetAllTrainers()
    {
        var trainers = trainerService.GetAllTrainers();

        if (trainers == null || !trainers.Any())
        {
            return NotFound("No Personal Trainers found");
        }
        return Ok(trainers);
    }

    [HttpPost(Name = "Add a new Trainer")]
    public IActionResult AddTrainer([FromBody] TrainerDto trainerDTO)
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
        var trainer = trainerService.GetTrainerById(id);
        if (trainer == null)
        {
            return NotFound($"Trainer with id {id} not found");
        }

        trainerService.RemoveTrainer(id);
        return NoContent();

    }
}