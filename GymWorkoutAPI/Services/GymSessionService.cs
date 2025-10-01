using GymWorkoutAPI.DataTransferObjects;
using GymWorkoutAPI.Repositories;
using GymWorkoutAPI.Mappers;

namespace GymWorkoutAPI.Services;

public class GymSessionService(IGymSessionRepository sessionRepository) : IGymSessionService
{
    public void CreateSession(GymSessionDto session)
    {
        var sessionEntity = session.ToEntity();
        sessionRepository.Add(sessionEntity);
    }
    
    public IEnumerable<GymSessionDto> GetAllSessions()
    {
        var sessions = sessionRepository.GetAll();
        return sessions.Select(entity => entity.ToDTO());
    }
    public GymSessionDto GetSessionById(int id)
    {
        var sessionEntity = sessionRepository.GetById(id);
        return sessionEntity?.ToDTO();
    }

    public IEnumerable<SessionWorkoutDetailDto> GetSessionWorkoutDetails(int sessionId)
    {
        return sessionRepository.GetSessionWorkoutDetails(sessionId);
    }
    
    public void AddWorkoutsToSession(int sessionId, IEnumerable<int> workoutIds)
    {
        sessionRepository.AddWorkoutsToSession(sessionId, workoutIds);
    }

    public void RemoveSession(int id)
    {
        sessionRepository.Remove(id);
    }
}
