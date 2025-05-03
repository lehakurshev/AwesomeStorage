using Domain;
using MediatR;

namespace Application.Elements.Queries.GetElements;

public class GetElementsQuery : IRequest<List<Element>>
{
    
}