using ElectDisciplines_API.Data;
using ElectDisciplines_API.Models;
using ElectDisciplines_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ElectDisciplines_API.Repository
{
    public class DisciplineRepository : Repository<Discipline>, IDisciplineRepository
    {
        private readonly ApplicationDbContext _db;

        public DisciplineRepository(ApplicationDbContext db): base(db)
        { _db = db; }
        

        public async Task<Discipline> UpdateAsync(Discipline entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Disciplines.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
