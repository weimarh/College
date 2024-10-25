using Domain.Common;
using Domain.Notas;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class NotaRepository : INotaRepository
{
    private readonly ApplicationDbContext _Context;

    public NotaRepository(ApplicationDbContext context)
    {
        _Context = context;
    }

    public void AddAsync(Nota entity) => _Context.Notas.Add(entity);

    public void DeleteAsync(Nota entity) => _Context.Notas.Remove(entity);

    public void UpdateAsync(Nota entity) => _Context.Notas.Update(entity);

    public async Task<bool> ExistsAsync(Identifier id) =>
        await _Context.Notas.AnyAsync(e => e.Id == id);

    public async Task<List<Nota>> GetAllAsync() =>
        await _Context.Notas.ToListAsync();

    public async Task<Nota?> GetByIdAsync(Identifier id) =>
        await _Context.Notas.SingleOrDefaultAsync(e => e.Id == id);
}
