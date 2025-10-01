using GymWorkoutAPI.DataTransferObjects;

namespace GymWorkoutAPI.Services
{
    public interface IGymSessionService
    {
        public void CreateSession(GymSessionDto sessionDTO);
        public IEnumerable<GymSessionDto> GetAllSessions();
        public GymSessionDto? GetSessionById(int id);
        public IEnumerable<SessionWorkoutDetailDto> GetSessionWorkoutDetails(int sessionId);
        public void AddWorkoutsToSession(int sessionId, IEnumerable<int> workoutIds);
        public void RemoveSession(int id);
    }
}