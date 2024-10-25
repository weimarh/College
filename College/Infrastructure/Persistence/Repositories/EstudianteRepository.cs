using Domain.Common;
using Domain.Estudiantes;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class EstudianteRepository : IEstudianteReposiroty
{
    private readonly ApplicationDbContext _context;

    public EstudianteRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void AddAsync(Alumno entity) => _context.Estudiantes.AddAsync(entity);

    public void DeleteAsync(Alumno entity) => _context.Estudiantes.Remove(entity);

    public void UpdateAsync(Alumno entity) => _context.Estudiantes.Update(entity);

    public async Task<bool> ExistsAsync(Identifier id) =>
        await _context.Estudiantes.AnyAsync(e => e.Id == id);

    public async Task<List<Alumno>> GetAllAsync() => await _context.Estudiantes.ToListAsync();

    public async Task<Alumno?> GetByIdAsync(Identifier id) =>
        await _context.Estudiantes.SingleOrDefaultAsync(e => e.Id == id);

}
