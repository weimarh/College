using Application.Data;
using Domain.Asignaturas;
using Domain.Estudiantes;
using Domain.Materias;
using Domain.Notas;
using Domain.Primitives;
using Domain.Profesores;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
{
    private readonly IPublisher _publisher;

    public ApplicationDbContext(DbContextOptions options, IPublisher publisher) : base(options)
    {
        _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
    }

    public DbSet<Maestro> Profesores { get; set; }
    public DbSet<Alumno> Estudiantes { get; set; }
    public DbSet<MateriaACursar> Materias { get; set; }
    public DbSet<Nota> Notas { get; set; }
    public DbSet<AsignaturaACursar> Asignaturas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var domainEvents = ChangeTracker.Entries<AggregateRoot>()
            .Select(entry => entry.Entity)
            .Where(entity => entity.GetDomainEvents().Any())
            .SelectMany(entity => entity.GetDomainEvents());

        var results = await base.SaveChangesAsync(cancellationToken);

        foreach (var domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent, cancellationToken);
        }

        return results;
    }
}
