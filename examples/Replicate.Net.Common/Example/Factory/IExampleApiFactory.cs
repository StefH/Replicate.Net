using Replicate.Net.Common.Example.Client;

namespace Replicate.Net.Common.Example.Factory;

public interface IExampleApiFactory
{
	IExampleApi GetApi();
}