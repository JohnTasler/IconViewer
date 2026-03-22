using System.Windows;

namespace IconViewer;

static class Program
{
	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main()
	{
		Application app = new Application();
		app.Run(new MainView(new MainViewModel()));
	}
}
