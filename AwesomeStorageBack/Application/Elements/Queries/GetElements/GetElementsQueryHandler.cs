using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Elements.Queries.GetElements;

public class GetElementsQueryHandler : BaseElementRequestHandler, IRequestHandler<GetElementsQuery, List<Element>>
{
    public GetElementsQueryHandler(IElementRepository elementRepository) : base(elementRepository) { }

    public async Task<List<Element>> Handle(GetElementsQuery request, CancellationToken cancellationToken)
    {
        var elements = await ElementRepository.GetAll(cancellationToken);
        elements.Sort((x, y) => y.CompareTo(x));
        return elements;
    }
}