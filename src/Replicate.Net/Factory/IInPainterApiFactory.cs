using Replicate.Net.Client;

namespace Replicate.Net.Factory;

public interface IInPainterApiFactory
{
    IInPainterApi GetApi();
}