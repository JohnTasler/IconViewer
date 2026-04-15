using System.Windows;
using IconViewer.Properties;
using Tasler.Configuration;

namespace IconViewer;

static class Program
{
	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main()
	{
		Settings.Default.SetAutoSaveDeferral(TimeSpan.FromSeconds(2));
		Application app = new Application();
		app.Run(new MainView(new MainViewModel()));
		Settings.Default.ExpireAndClearAutoSaveDeferral();
	}
}
