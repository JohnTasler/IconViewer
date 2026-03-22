using System.Collections.Specialized;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace IconViewer;

public partial class MainViewModel : ObservableObject
{
	[ObservableProperty]
	private string _filePathText = string.Empty;

	partial void OnFilePathTextChanged(string value)
	{
		ExtractCommand.NotifyCanExecuteChanged();
	}

	[ObservableProperty]
	private StringCollection _previousFiles = Properties.Settings.Default.PreviousFiles ?? [];

	[RelayCommand]
	private void Browse()
	{
		var dialog = new Microsoft.Win32.OpenFileDialog
		{
			Title = "Select an icon file",
			Filter = "Icon files (*.ico)|*.ico|All files (*.*)|*.*",
			CheckFileExists = true,
			CheckPathExists = true,
			Multiselect = false
		};
		if (dialog.ShowDialog() == true)
		{
			FilePathText = dialog.FileName;
		}
	}

	[RelayCommand(CanExecute = nameof(CanExtract))]
	private void Extract()
	{
		// This is the wrong code for here.


	}

	private bool CanExtract() => !string.IsNullOrWhiteSpace(FilePathText) && File.Exists(FilePathText);

	[ObservableProperty]
	private ImageItem? _selectedImageItem;

	[ObservableProperty]
	private IEnumerable<ImageItem> _imageItems = [];
}
