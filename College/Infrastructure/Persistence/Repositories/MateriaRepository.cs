using Domain.Common;
using Domain.Materias;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class MateriaRepository : IMateriaRepository
{
    private readonly ApplicationDbContext _context;

    public MateriaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void AddAsync(MateriaACursar entity) => _context.Materias.Add(entity);

    public void DeleteAsync(MateriaACursar entity) => _context.Materias.Remove(entity);

    public void UpdateAsync(MateriaACursar entity) => _context.Materias.Update(entity);

    public async Task<bool> ExistsAsync(Identifier id) =>
        await _context.Materias.AnyAsync(e => e.Id == id);

    public async Task<List<MateriaACursar>> GetAllAsync() =>
        await _context.Materias.ToListAsync();

    public async Task<MateriaACursar?> GetByIdAsync(Identifier id) =>
        await _context.Materias.SingleOrDefaultAsync(e => e.Id == id);

}
