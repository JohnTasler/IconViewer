using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Data;
using System.Xml.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tasler.Collections;
using Tasler.Collections.Extensions;
using Tasler.Interop.Kernel;
using Tasler.Interop.Resources;
using Tasler.Interop.User;
using ResourceType = Tasler.Interop.User.ResourceType;

namespace IconViewer;

public partial class MainViewModel : ObservableObject
{

	public MainViewModel()
	{
		_imageItemsList = [];
		_imageItemsSource = new CollectionViewSource() { Source = _imageItemsList };
		_imageItems = _imageItemsSource.View;

		_previousFiles = _previousFilesList = Properties.Settings.Default.PreviousFiles ??= [];
	}

	[ObservableProperty]
	private string _filePathText = string.Empty;

	partial void OnFilePathTextChanged(string value)
	{
		ExtractCommand.NotifyCanExecuteChanged();
	}

	[ObservableProperty]
	private readonly IEnumerable<string> _previousFiles;
	private readonly ObservableCollection<string> _previousFilesList;

	[ObservableProperty]
	private readonly ICollectionView _imageItems;
	private readonly CollectionViewSource _imageItemsSource;
	private readonly ObservableCollection<ImageItem> _imageItemsList;

	[ObservableProperty]
	private ImageItem? _selectedImageItem;

	[RelayCommand]
	private void Browse()
	{
		var dialog = new Microsoft.Win32.OpenFileDialog
		{
			Title = "Select an icon file",
			Filter = "Icon files (*.ico)|*.ico|Executable Files (*.exe;*.dll;*.mui)|*.exe;*.dll;*.mui;*.cpl;*sys|All files (*.*)|*.*",
			CheckFileExists = true,
			CheckPathExists = true,
			Multiselect = false
		};
		if (dialog.ShowDialog() == true)
		{
			this.FilePathText = dialog.FileName;
			if (this.CanExtract())
				_ = this.Extract();
		}
	}

	[RelayCommand(CanExecute = nameof(CanExtract))]
	private async Task Extract()
	{
		_imageItemsList.Clear();

		try
		{
			if (!this.ExtractFromExe())
			{
				using var fileStream = new FileStream(this.FilePathText, FileMode.Open, FileAccess.Read, FileShare.Read);
				var iconEntries = IconFileReader.GetIconDirectoryEntries(fileStream);
				foreach (var entry in iconEntries)
					_imageItemsList.Add(new ImageItem(entry));
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
		}

		var index = this.PreviousFiles.FirstIndex(s => s.ToLowerInvariant().Equals(this.FilePathText.ToLowerInvariant()));
		if (index > 0)
			_previousFilesList.Move(index, 0);
		else if (index < 0)
			_previousFilesList.Insert(0, this.FilePathText);
	}

	private bool ExtractFromExe()
	{
		using var library = KernelApi.LoadLibraryEx(this.FilePathText, LoadLibraryFlags.AsDatafile | LoadLibraryFlags.AsImageResource);
		if (library.IsInvalid)
			return false;

		// Extract all RT_GROUP_ICON resources from the executable.
		foreach (var groupIcon in library.EnumerateResourceNames(IntegerResourceType.GroupIcon))
		{
			unsafe
			{
				Debug.WriteLine($"{groupIcon}");

				var span = library.FindLoadAndLockResource(groupIcon, IntegerResourceType.GroupIcon, out var pointer);
				using var stream = new UnmanagedMemoryStream(pointer, span.Length);
				var iconEntries = IconFileReader.GetIconDirectoryEntries(stream, true);
				foreach (var entry in iconEntries)
					_imageItemsList.Add(new ImageItem(library, entry, groupIcon));
			}
		}

		return true;
	}

	private bool CanExtract() => !string.IsNullOrWhiteSpace(this.FilePathText) && File.Exists(this.FilePathText);
}
