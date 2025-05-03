using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;

namespace Application.Elements.Commands.UpdateElement;

public class UpdateElementCommandHandler : BaseElementRequestHandler, IRequestHandler<UpdateElementCommand>
{
    public UpdateElementCommandHandler(IElementRepository elementRepository) : base(elementRepository) { }

    public async Task Handle(UpdateElementCommand request, CancellationToken cancellationToken)
    {
        var element = await ElementRepository.GetById(request.Id, cancellationToken);
        if (element == null)
        {
            throw new NotFoundException();
        }
        element.Details = request.Details;
        await ElementRepository.SaveChangesAsync(cancellationToken);
    }
}