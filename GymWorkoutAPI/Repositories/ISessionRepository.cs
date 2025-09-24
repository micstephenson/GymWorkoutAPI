using GymWorkoutAPI.Data;
using GymWorkoutAPI.DataTransferObjects;

namespace GymWorkoutAPI.Repositories;
public interface ISessionRepository
{
    GymSession GetById(int id);
    IEnumerable<GymSession> GetAll();
    IEnumerable<SessionWorkoutDetailDto> GetSessionWorkoutDetails(int sessionId);
    void AddWorkoutsToSession(int sessionId, IEnumerable<int> workoutIds);
    void Add(GymSession session);
    void Remove(int id);
}
