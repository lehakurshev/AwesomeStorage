using Domain;
using MediatR;

namespace Application.Elements.Queries.GetElement;

public class GetElementQuery : IRequest<Element>
{
    public Guid Id { get; set; }
}