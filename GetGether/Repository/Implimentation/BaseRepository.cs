using GetGether.Data;
using GetGether.Models;
using GetGether.Repository.Interfaces;

namespace GetGether.Repository.Implimentation
{
    public class BaseRepository<TDbModel> : IBaseRepository<TDbModel> where TDbModel : BaseModel
    {
        private GlobalDBContext Context { get; set; }
        public BaseRepository(GlobalDBContext context)
        {
            Context = context;
        }

        public TDbModel Create(TDbModel model)
        {
            Context.Set<TDbModel>().Add(model);
            Context.SaveChanges();
            return model;
        }

        public void Delete(int Id)
        {
            var toDelete = Context.Set<TDbModel>().FirstOrDefault(m => m.Id == Id);
            Context.Set<TDbModel>().Remove(toDelete);
            Context.SaveChanges();
        }

        public List<TDbModel> GetAll()
        {
            return Context.Set<TDbModel>().ToList();
        }

        public TDbModel Update(TDbModel model)
        {
            var toUpdate = Context.Set<TDbModel>().FirstOrDefault(m => m.Id == model.Id);
            if (toUpdate != null)
            {
                toUpdate = model;
            }
            Context.Update(toUpdate);
            Context.SaveChanges();
            return toUpdate;
        }

        public TDbModel Get(int Id)
        {
            return Context.Set<TDbModel>().FirstOrDefault(m => m.Id == Id);
        }
    }
}
