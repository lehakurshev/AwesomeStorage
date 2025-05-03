using MediatR;

namespace Application.Elements.Commands.UpdateElement;

public class UpdateElementCommand : IRequest
{
    public Guid Id { get; set; }
    public string Details { get; set; }
}