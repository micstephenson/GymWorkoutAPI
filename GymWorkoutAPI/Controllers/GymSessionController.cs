using GymWorkoutAPI.DataTransferObjects;
using GymWorkoutAPI.Repositories;
using GymWorkoutAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymWorkoutAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GymSessionController(IGymSessionService sessionService) : ControllerBase
{
    [HttpGet(Name = "Get all sessions")]
    public IActionResult GetAllSessions()
    {
        var sessions = sessionService.GetAllSessions();

        if (sessions == null || !sessions.Any())
        {
            return NotFound("No Sessions found");
        }
        return Ok(sessions);
    }

    [HttpGet("{sessionId}/workouts", Name = "Get Session Workout Details")]
    public IActionResult GetSessionWorkouts(int sessionId)
    {
        var session = sessionService.GetSessionWorkoutDetails(sessionId);
        if (session == null || !session.Any())
        {
            return NotFound($"Session with id {sessionId} not found");
        }
        return Ok(session);
    }

    [HttpPost(Name = "Add a new Session")]
    public IActionResult AddSession([FromBody] GymSessionDto gymSessionDto)
    {
        if (gymSessionDto == null)
        {
            return BadRequest("Session data is null.");
        }
        sessionService.CreateSession(gymSessionDto);
        return Created(string.Empty, gymSessionDto);
    }

    [HttpPost("{sessionId}", Name = "Add Workouts to Session")]
    public IActionResult AddWorkoutsToSession([FromBody] WorkoutsToAdd workoutsToAdd, [FromRoute] int sessionId)
    {
        if (workoutsToAdd == null || workoutsToAdd.WorkoutIDs.Count() < 0)
        {
            return BadRequest("Invalid data.");
        }

        var session = sessionService.GetSessionById(sessionId);
        if (session == null)
        {
            return NotFound($"Session with id {sessionId} not found");
        }

        sessionService.AddWorkoutsToSession(sessionId, workoutsToAdd.WorkoutIDs);
        return Ok($"Workouts added to session {sessionId}");
    }


    //[HttpPut("update", Name = "Update a Session")]
    //public IActionResult UpdateSession(int id, [FromBody] Session updatedSession)
    //{
    //    if (updatedSession == null || updatedSession.SessionID != id)
    //    {
    //        return BadRequest("Invalid workout data");
    //    }

    //    var existingSession = sessionRepository.GetById(id);
    //    if (existingSession == null)
    //    {
    //        throw new WorkoutNotFoundException(id);
    //    }

    //    existingSession.SessionName = updatedSession.SessionName;
    //    existingSession.Duration = updatedSession.Duration;

    //    sessionRepository.Update(existingSession);
    //    return NoContent();
    //}


    [HttpDelete("{id}", Name = "Remove a Session")]
    public IActionResult RemoveSession(int id)
    {
        var session = sessionService.GetSessionById(id);
        if (session == null)
        {
            return NotFound($"Session with id {id} not found");
        }

        sessionService.RemoveSession(id);
        return NoContent();

    }
}