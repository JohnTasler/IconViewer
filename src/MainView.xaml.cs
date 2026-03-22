using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Tasler.Windows;

namespace IconViewer;

public partial class MainView : INotifyPropertyChanged
{
	public MainView()
	{
		this.InitializeComponent();
		this.Loaded += MainView_Loaded;
	}

	public MainView(MainViewModel viewModel)
		: this()
	{
		this.HookDataContextAsViewModel(PropertyChanged);
		this.DataContext = viewModel;
	}

	public MainViewModel ViewModel => (MainViewModel)this.DataContext;

	public event PropertyChangedEventHandler? PropertyChanged;

	private void MainView_Loaded(object sender, RoutedEventArgs e)
	{
		// Set focus to the first tabstop control when the view is loaded
		this.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
	}
}
