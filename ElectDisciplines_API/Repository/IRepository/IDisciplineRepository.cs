using ElectDisciplines_API.Models;
using System.Linq.Expressions;

namespace ElectDisciplines_API.Repository.IRepository
{
    public interface IDisciplineRepository : IRepository<Discipline>
    {
        
        Task<Discipline> UpdateAsync(Discipline entity);
        
    }
}
