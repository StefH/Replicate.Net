using Replicate.Net.WinFormsApp.InPainter.Client;

namespace Replicate.Net.WinFormsApp.InPainter.Factory;

public interface IInPainterApiFactory
{
	IInPainterApi GetApi();
}