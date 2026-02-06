namespace Fylum.Core.Application.Mapping;

internal class IEnumerableMapper<TIn, TOut> : IMapper<IEnumerable<TIn>, IEnumerable<TOut>>
{
    private readonly IMapper<TIn, TOut> _mapper;

    public IEnumerableMapper(IMapper<TIn, TOut> mapper)
    {
        _mapper = mapper;
    }

    public IEnumerable<TOut> Map(IEnumerable<TIn> input) => input.Select(_mapper.Map);
}
