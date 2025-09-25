using GymWorkoutAPI.Data;
using GymWorkoutAPI.DataTransferObjects;

namespace GymWorkoutAPI.Repositories;
public interface ISessionRepository
{
    GymSessions GetById(int id);
    IEnumerable<GymSessions> GetAll();
    IEnumerable<SessionWorkoutDetailDto> GetSessionWorkoutDetails(int sessionId);
    void AddWorkoutsToSession(int sessionId, IEnumerable<int> workoutIds);
    void Add(GymSessions session);
    void Remove(int id);
}
