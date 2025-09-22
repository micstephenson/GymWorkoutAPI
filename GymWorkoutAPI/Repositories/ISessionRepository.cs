using GymWorkoutAPI.Data;

namespace GymWorkoutAPI.Repositories;
public interface ISessionRepository
{
    Session GetById(int id);
    IEnumerable<Session> GetAll();
    void Add(Session session);
    void Remove(int id);
}
