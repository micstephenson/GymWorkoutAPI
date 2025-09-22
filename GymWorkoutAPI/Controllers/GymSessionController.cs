using GymWorkoutAPI.Data;
using GymWorkoutAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GymWorkoutAPI.Controllers
{
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

        [HttpPost(Name = "Add a new Session")]
        public IActionResult AddSession([FromBody] Session session)
        {
            if (session == null)
            {
                return BadRequest("Session data is null.");
            }
            sessionRepository.Add(session);
            return CreatedAtAction(nameof(AddSession), new { id = session.SessionID }, session);
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
}