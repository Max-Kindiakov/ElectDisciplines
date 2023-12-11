using ElectDisciplines_API.Models;
using System.Linq.Expressions;

namespace ElectDisciplines_API.Repository.IRepository
{
    public interface IDisciplineNumberRepository : IRepository<DisciplineNumber>
    {
        
        Task<DisciplineNumber> UpdateAsync(DisciplineNumber entity);
        
    }
}
