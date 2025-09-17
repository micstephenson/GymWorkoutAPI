using GymWorkoutAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymWorkoutAPI.Repositories
{
    public class TrainerRepository(TrainerContext trainerContext) : ITrainerRepository
    {

        public void Add(Trainer trainer)
        {
            trainerContext.Trainers.Add(trainer);
            trainerContext.SaveChanges();
        }

        public IEnumerable<Trainer> GetAll()
        {
            return trainerContext.Trainers.ToList();
        }

        public Trainer? GetById(int id)
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
