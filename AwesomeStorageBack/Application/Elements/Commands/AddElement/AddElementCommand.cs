using MediatR;

namespace Application.Objects.Commands.AddElement;

public class AddElementCommand : IRequest<Guid>
{
    public string Details { get; set; }
}