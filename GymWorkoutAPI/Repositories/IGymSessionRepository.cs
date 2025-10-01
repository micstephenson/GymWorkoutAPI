using GymWorkoutAPI.Data.Entity;
using GymWorkoutAPI.DataTransferObjects;

namespace GymWorkoutAPI.Repositories;
public interface IGymSessionRepository
{
    void Add(GymSessions session);
    IEnumerable<GymSessions> GetAll();
    IEnumerable<SessionWorkoutDetailDto> GetSessionWorkoutDetails(int sessionId);
    GymSessions GetById(int id);
    void AddWorkoutsToSession(int sessionId, IEnumerable<int> workoutIds);
    void Remove(int id);
}
