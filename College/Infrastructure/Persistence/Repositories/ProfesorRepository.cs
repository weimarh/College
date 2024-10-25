using Application.Data;
using Domain.Common;
using Domain.Profesores;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ProfesorRepository : IProfesorRepository
{
    private readonly IApplicationDbContext _context;

    public ProfesorRepository(IApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void AddAsync(Maestro entity) => _context.Profesores.AddAsync(entity);

    public void DeleteAsync(Maestro entity) => _context.Profesores.Remove(entity);

    public void UpdateAsync(Maestro entity) => _context.Profesores.Update(entity);

    public async Task<bool> ExistsAsync(Identifier id) =>
        await _context.Profesores.AnyAsync(e => e.Id == id);

    public async Task<List<Maestro>> GetAllAsync() =>
        await _context.Profesores.ToListAsync();

    public async Task<Maestro?> GetByIdAsync(Identifier id) =>
        await _context.Profesores.SingleOrDefaultAsync(e => e.Id == id);
}
