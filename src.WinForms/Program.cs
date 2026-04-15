using IconViewer.WinForms.Properties;
using Tasler.Configuration;

namespace IconViewer.WinForms;

static class Program
{
	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main()
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(false);
		Settings.Default.SetAutoSaveDeferral(TimeSpan.FromSeconds(2));
		Application.Run(new Form1());
		Settings.Default.ExpireAndClearAutoSaveDeferral();
	}
}
