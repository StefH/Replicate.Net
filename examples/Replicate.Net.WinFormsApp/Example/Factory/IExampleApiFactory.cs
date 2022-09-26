using Replicate.Net.WinFormsApp.Example.Client;

namespace Replicate.Net.WinFormsApp.Example.Factory;

public interface IExampleApiFactory
{
	IExampleApi GetApi();
}