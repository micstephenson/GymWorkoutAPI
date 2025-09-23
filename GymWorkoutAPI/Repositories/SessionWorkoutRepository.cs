using GymWorkoutAPI.Data;

namespace GymWorkoutAPI.Repositories
{
    public class SessionWorkoutRepository(SessionWorkoutContext sessionworkoutContext) : ISessionRepository
    {

        public void AddSessionWorkout(SessionWorkout sessionworkout)
        {
            sessionworkoutContext.SessionWorkout.Add(sessionworkout);
            sessionworkoutContext.SaveChanges();
        }

        public IEnumerable<Session> GetAllWorkouts()
        {
            return sessionworkoutContext.SessionWorkout.ToList();
        }

        public Session? GetById(int id)
        {
            return sessionworkoutContext.Sessions.FirstOrDefault(p => p.SessionID == id);
        }


        public void Remove(int id)
        {
            var session = sessionworkoutContext.Sessions.FirstOrDefault(p => p.SessionID == id);
            if (session != null)
            {
                sessionworkoutContext.Sessions.Remove(session);
                sessionworkoutContext.SaveChanges();
            }
        }
    }
}
