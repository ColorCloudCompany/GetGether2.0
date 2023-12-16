using GetGether.Models;

namespace GetGether.Repository.Interfaces
{


    /// <summary>
    /// Часть паттерна репозиторий, которая создает базовые команды для взаимодействия с базой данных
    /// </summary>
    /// <typeparam name="TDbModel"></typeparam>
    /// 


    public interface IBaseRepository<TDbModel> where TDbModel : BaseModel
    {
        public List<TDbModel> GetAll();
        public TDbModel Get(int Id);
        public TDbModel Create(TDbModel model);
        public TDbModel Update(TDbModel model);
        public void Delete(int Id);
    }
}
