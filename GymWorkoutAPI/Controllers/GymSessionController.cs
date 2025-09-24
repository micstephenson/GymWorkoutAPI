using GymWorkoutAPI.Data;
using GymWorkoutAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GymWorkoutAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GymSessionController : ControllerBase
{
    private readonly ISessionRepository sessionRepository;
    public GymSessionController(ISessionRepository sessionRepository)
    {
        this.sessionRepository = sessionRepository;
    }

    [HttpGet(Name = "Get all sessions")]
    public IActionResult GetAllSessions()
    {
        var sessions = sessionRepository.GetAll();

        if (sessions == null || !sessions.Any())
        {
            return NotFound("No Sessions found");
        }
        return Ok(sessions);
    }

    [HttpGet("{sessionId}/workouts", Name = "Get Session Workout Details")]
    public IActionResult GetSessionWorkouts(int sessionId)
    {
        var session = sessionRepository.GetSessionWorkoutDetails(sessionId);
        if (session == null || !session.Any())
        {
            return NotFound($"Session with id {sessionId} not found");
        }
        return Ok(session);
    }

    [HttpPost(Name = "Add a new Session")]
    public IActionResult AddSession([FromBody] GymSession session)
    {
        if (session == null)
        {
            return BadRequest("Session data is null.");
        }
        sessionRepository.Add(session);
        return CreatedAtAction(nameof(AddSession), new { id = session.SessionID }, session);
    }

    [HttpPost("add-workouts", Name = "Add Workouts to Session")]
    public IActionResult AddWorkoutsToSession([FromBody] SessionWorkout SessionWorkout)
    {
        if (SessionWorkout == null || SessionWorkout.WorkoutID == null || !SessionWorkout.WorkoutID.Any())
        {
            return BadRequest("Invalid data.");
        }

        var session = sessionRepository.GetById(SessionWorkout.SessionID);
        if (session == null)
        {
            return NotFound($"Session with id {SessionWorkout.SessionID} not found");
        }

        sessionRepository.AddWorkoutsToSession(SessionWorkout.SessionID, SessionWorkout.WorkoutID);
        return Ok($"Workouts added to session {SessionWorkout.SessionID}");
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
        var session = sessionRepository.GetById(id);
        if (session == null)
        {
            return NotFound($"Session with id {id} not found");
        }

        sessionRepository.Remove(id);
        return NoContent();

    }
}