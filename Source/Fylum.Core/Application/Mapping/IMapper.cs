namespace Fylum.Core.Application.Mapping;

public interface IMapper<TIn, TOut>
{
    TOut Map(TIn input);
}

public interface IInplaceMapper<TIn, TOut>
{
    void Map(TIn input, ref TOut output);
}
