using Application.Common.Exceptions;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Elements.Queries.GetElement;

public class GetElementQueryHandler : BaseElementRequestHandler, IRequestHandler<GetElementQuery, Element>
{
    public GetElementQueryHandler(IElementRepository elementRepository) : base(elementRepository) { }

    public async Task<Element> Handle(GetElementQuery request, CancellationToken cancellationToken)
    {
        var element = await ElementRepository.GetById(request.Id, cancellationToken);
        if (element == null)
        {
            throw new NotFoundException();
        }

        element.CountQueries++;
        await ElementRepository.SaveChangesAsync(cancellationToken);
        
        return element;
    }
}