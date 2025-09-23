using GymWorkoutAPI.Data;

namespace GymWorkoutAPI.Repositories
{
    public class SessionRepository(SessionContext sessionContext) : ISessionRepository
    {

        public void Add(Session session)
        {
            sessionContext.Sessions.Add(session);
            sessionContext.SaveChanges();
        }

        public IEnumerable<Session> GetAll()
        {
            return sessionContext.Sessions.ToList();
        }

        public Session? GetById(int id)
        {
            return sessionContext.Sessions.FirstOrDefault(p => p.SessionID == id);
        }


        public void Remove(int id)
        {
            var session = sessionContext.Sessions.FirstOrDefault(p => p.SessionID == id);
            if (session != null)
            {
                sessionContext.Sessions.Remove(session);
                sessionContext.SaveChanges();
            }
        }
    }
}
