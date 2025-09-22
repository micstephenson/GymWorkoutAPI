using GymWorkoutAPI.Data;

namespace GymWorkoutAPI.Repositories
{
    public class TrainerRepository(TrainerContext trainerContext) : ITrainerRepository
    {

        public void Add(TrainerEntity trainer)
        {
            trainerContext.Trainers.Add(trainer);
            trainerContext.SaveChanges();
        }

        public IEnumerable<TrainerEntity> GetAll()
        {
            return trainerContext.Trainers.ToList();
        }

        public TrainerEntity? GetById(int id)
        {
            return trainerContext.Trainers.FirstOrDefault(p => p.TrainerID == id);
        }

        public void Remove(int id)
        {
            var trainer = trainerContext.Trainers.FirstOrDefault(p => p.TrainerID == id);
            if (trainer != null)
            {
                trainerContext.Trainers.Remove(trainer);
                trainerContext.SaveChanges();
            }
        }
    }
}
