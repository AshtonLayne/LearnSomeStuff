using System.Linq;
using LearnStuff.Core.Models;

namespace LearnStuff.Core.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(string ID);
        T Find(string ID);
        void Insert(T t);
        void Update(T t);
    }
}