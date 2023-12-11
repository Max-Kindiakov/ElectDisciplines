using ElectDisciplines_API.Data;
using ElectDisciplines_API.Models;
using ElectDisciplines_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ElectDisciplines_API.Repository
{
    public class DisciplineNumberRepository : Repository<DisciplineNumber>, IDisciplineNumberRepository
    {
        private readonly ApplicationDbContext _db;

        public DisciplineNumberRepository(ApplicationDbContext db): base(db)
        { _db = db; }
        

        public async Task<DisciplineNumber> UpdateAsync(DisciplineNumber entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.DisciplineNumbers.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
