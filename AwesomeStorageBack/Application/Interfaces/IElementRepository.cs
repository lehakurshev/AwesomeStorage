using Domain;

namespace Application.Interfaces;

public interface IElementRepository
{
    Task<List<Element>> GetAll(CancellationToken cancellationToken);
    Task<List<Element>> GetAllWithСontext(string searchTerm, CancellationToken cancellationToken);
    Task<Element?> GetById(Guid id, CancellationToken cancellationToken);
    Task<Guid> Add(Element element, CancellationToken cancellationToken);
    Task Delete(Element element, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}