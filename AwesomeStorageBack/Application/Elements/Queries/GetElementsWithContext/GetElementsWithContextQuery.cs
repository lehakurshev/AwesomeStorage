using Domain;
using MediatR;

namespace Application.Elements.Queries.GetElementsWithContext;

public class GetElementsWithContextQuery : IRequest<List<Element>>
{
    public string SearchTerm { get; set; }
}