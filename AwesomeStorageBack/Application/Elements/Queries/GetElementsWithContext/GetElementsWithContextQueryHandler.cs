using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Elements.Queries.GetElementsWithContext;

public class GetElementsWithContextQueryHandler : BaseElementRequestHandler, IRequestHandler<GetElementsWithContextQuery, List<Element>>
{
    public GetElementsWithContextQueryHandler(IElementRepository elementRepository) : base(elementRepository) { }

    public async Task<List<Element>> Handle(GetElementsWithContextQuery request, CancellationToken cancellationToken)
    {
        return await ElementRepository.GetAllWithСontext(request.SearchTerm, cancellationToken);
    }
}