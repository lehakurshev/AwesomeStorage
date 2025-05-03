using MediatR;

namespace Application.Elements.Commands.DeleteElement;

public class DeleteElementCommand : IRequest
{
    public Guid Id { get; set; }
}