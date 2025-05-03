using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;

namespace Persistence.Repository;

public class ElementRepository : IElementRepository
{
    private readonly AppDbContext _context;

    public ElementRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Element>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Elements
            .ToListAsync(cancellationToken);
    }

    public async Task<List<Element>> GetAllWithСontext(string searchTerm, CancellationToken cancellationToken)
    {
        var tsQuery = searchTerm.Replace(" ", " & ");

        return await _context.Elements
            .FromSqlRaw(@"
                SELECT * FROM ""Elements""
                ORDER BY ts_rank(to_tsvector('english', ""Details""), to_tsquery('english', {0})) DESC", 
                tsQuery)
            .ToListAsync(cancellationToken);
    }
    
    public async Task<Element?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Elements.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public async Task<Guid> Add(Element element, CancellationToken cancellationToken)
    {
        await _context.Elements.AddAsync(element, cancellationToken);
        return element.Id;
    }
    
    public async Task Delete(Element element, CancellationToken cancellationToken)
    {
        _context.Elements.Remove(element);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}