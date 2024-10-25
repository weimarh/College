using Application.Data;
using Domain.Asignaturas;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class AsignaturaRepository : IAsignaturaRepository
{
    private readonly IApplicationDbContext _context;

    public AsignaturaRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public void AddAsync(AsignaturaACursar entity) => _context.Asignaturas.Add(entity);

    public void DeleteAsync(AsignaturaACursar entity) => _context.Asignaturas.Remove(entity);

    public void UpdateAsync(AsignaturaACursar entity) => _context.Asignaturas.Update(entity);

    public async Task<bool> ExistsAsync(Identifier id) =>
        await _context.Asignaturas.AnyAsync(e => e.Id == id);

    public async Task<List<AsignaturaACursar>> GetAllAsync() =>
        await _context.Asignaturas.ToListAsync();

    public Task<AsignaturaACursar?> GetByIdAsync(Identifier id) =>
        _context.Asignaturas.SingleOrDefaultAsync(e => e.Id == id);
}
