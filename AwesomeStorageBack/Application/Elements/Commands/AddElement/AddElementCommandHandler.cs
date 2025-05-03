using Application.Common.Exceptions;
using Application.Interfaces;
using Application.Objects.Commands.AddElement;
using Domain;
using MediatR;

namespace Application.Elements.Commands.AddElement;

public class AddElementCommandHandler : BaseElementRequestHandler, IRequestHandler<AddElementCommand, Guid>
{
    public AddElementCommandHandler(IElementRepository elementRepository) : base(elementRepository) { }

    public async Task<Guid> Handle(AddElementCommand request, CancellationToken cancellationToken)
    {
        var element = new Element(request.Details);
        if (element == null)
        {
            throw new NotFoundException();
        }
        await ElementRepository.Add(element, cancellationToken);
        await ElementRepository.SaveChangesAsync(cancellationToken);
        return element.Id;
    }
}