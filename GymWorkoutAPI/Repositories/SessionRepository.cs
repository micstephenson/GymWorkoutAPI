using GymWorkoutAPI.Data;
using GymWorkoutAPI.DataTransferObjects;

namespace GymWorkoutAPI.Repositories;

public class SessionRepository(SessionContext sessionContext, TrainerContext trainerContext, SessionWorkoutContext sessionWorkoutContext, WorkoutContext workoutContext) : ISessionRepository
{
    public void Add(GymSessions session)
    {
        sessionContext.GymSessions.Add(session);
        sessionContext.SaveChanges();
    }

    public IEnumerable<GymSessions> GetAll()
    {
        var gymsessions = sessionContext.GymSessions.ToList();
        return sessionContext.GymSessions.ToList();
    }

    public IEnumerable<SessionWorkoutDetailDto> GetSessionWorkoutDetails(int sessionId)
    {
        var result = (from gs in sessionContext.GymSessions
                      join t in trainerContext.Trainers on gs.TrainerID equals t.TrainerID
                      join sw in sessionWorkoutContext.SessionWorkout on gs.SessionID equals sw.SessionID
                      from workoutId in sw.WorkoutID
                      join w in workoutContext.Workouts on workoutId equals w.WorkoutID
                      where gs.SessionID == sessionId
                      select new SessionWorkoutDetailDto
                      {
                          SessionID = gs.SessionID,
                          SessionDate = gs.SessionDate,
                          TrainerID = t.TrainerID,
                          FirstName = t.FirstName,
                          LastName = t.LastName,
                          WorkoutID = w.WorkoutID,
                          WorkoutName = w.WorkoutName,
                          WorkoutSets = w.WorkoutSets ?? 0,
                          Reps = w.Reps ?? 0,
                          SessionDuration = gs.OverallDuration
                      }).ToList();

        return result;
    }

    public GymSessions GetById(int id)
    {
        return sessionContext.GymSessions.FirstOrDefault(p => p.SessionID == id);
    }

    public void AddWorkoutsToSession(int sessionId, IEnumerable<int> workoutIds)
    {
        foreach (var workoutID in workoutIds)
        {
            var sessionWorkout = new SessionWorkout
            {
                SessionID = sessionId,
                WorkoutID = new List<int> { workoutID }
            };
            sessionContext.Add(sessionWorkout);
        }
    }

    public void Remove(int id)
    {
        var session = sessionContext.GymSessions.FirstOrDefault(p => p.SessionID == id);
        if (session != null)
        {
            sessionContext.GymSessions.Remove(session);
            sessionContext.SaveChanges();
        }
    }
}
