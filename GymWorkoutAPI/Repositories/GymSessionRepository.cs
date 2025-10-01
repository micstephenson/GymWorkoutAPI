using GymWorkoutAPI.Data;
using GymWorkoutAPI.Data.Entity;
using GymWorkoutAPI.DataTransferObjects;

namespace GymWorkoutAPI.Repositories;

public class GymSessionRepository(WorkoutContext workoutContext) : IGymSessionRepository
{
    public void Add(GymSessions session)
    {
        workoutContext.GymSessions.Add(session);
        workoutContext.SaveChanges();
    }

    public IEnumerable<GymSessions> GetAll()
    {
        var gymsessions = workoutContext.GymSessions.ToList();
        return workoutContext.GymSessions.ToList();
    }

    public IEnumerable<SessionWorkoutDetailDto> GetSessionWorkoutDetails(int sessionId)
    {
        var result = (from gs in workoutContext.GymSessions
                      join t in workoutContext.Trainers on gs.TrainerID equals t.TrainerID
                      join sw in workoutContext.SessionWorkout on gs.SessionID equals sw.SessionID
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
        return workoutContext.GymSessions.FirstOrDefault(p => p.SessionID == id);
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
            workoutContext.Add(sessionWorkout);
        }
    }

    public void Remove(int id)
    {
        var session = workoutContext.GymSessions.FirstOrDefault(p => p.SessionID == id);
        if (session != null)
        {
            workoutContext.GymSessions.Remove(session);
            workoutContext.SaveChanges();
        }
    }
}
