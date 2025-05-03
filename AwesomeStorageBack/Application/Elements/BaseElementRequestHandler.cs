using Application.Interfaces;

namespace Application.Elements;

public class BaseElementRequestHandler
{
    protected readonly IElementRepository ElementRepository;

    protected BaseElementRequestHandler(IElementRepository elementRepository)
    {
        ElementRepository = elementRepository;
    }
}