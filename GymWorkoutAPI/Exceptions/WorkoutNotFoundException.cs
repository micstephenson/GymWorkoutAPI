using System;

namespace GymWorkoutAPI.Exceptions
{
    public class WorkoutNotFoundException : Exception
    {
        public WorkoutNotFoundException(int workoutId)
            : base($"Product with ID {workoutId} was not found in the database.")
        {
        }

        public WorkoutNotFoundException(string message)
            : base(message)
        {
        }

        public WorkoutNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}