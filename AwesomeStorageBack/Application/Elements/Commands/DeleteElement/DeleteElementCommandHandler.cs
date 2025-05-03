using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;

namespace Application.Elements.Commands.DeleteElement;

public class DeleteElementCommandHandler : BaseElementRequestHandler, IRequestHandler<DeleteElementCommand>
{
    public DeleteElementCommandHandler(IElementRepository elementRepository) : base(elementRepository) { }

    public async Task Handle(DeleteElementCommand request, CancellationToken cancellationToken)
    {
        var element = await ElementRepository.GetById(request.Id, cancellationToken);
        if (element == null)
        {
            throw new NotFoundException();
        }
        await ElementRepository.Delete(element, cancellationToken);
        await ElementRepository.SaveChangesAsync(cancellationToken);
    }
}