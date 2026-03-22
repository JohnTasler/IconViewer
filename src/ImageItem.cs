using System.Windows.Interop;
using System.Windows.Media.Imaging;
using CommunityToolkit.Diagnostics;
using Tasler.Interop.Gdi;
using Tasler.Interop.Resources;

namespace IconViewer;

public class ImageItem : IDisposable
{
	private SafeGdiIcon _iconHandle;

	private ImageItem(SafeGdiIcon iconHandle, bool takeOwnership)
	{
		Guard.IsNotNull(iconHandle);
		Guard.IsNotDefault(iconHandle.Handle);

		_iconHandle = takeOwnership
			?	new SafeGdiIconOwned() { Handle = iconHandle.DetachHandle() }
			: new SafeGdiIcon() { Handle = iconHandle.Handle };

		var iconBitmapInfo = _iconHandle.GetIconBitmapInfo();
		var width = iconBitmapInfo.Width;
		var height = iconBitmapInfo.Height;

		_icon = Imaging.CreateBitmapSourceFromHIcon(_iconHandle.DangerousGetHandle(),
			new(0, 0, width, height), BitmapSizeOptions.FromWidthAndHeight(width, height));
	}

	public ImageItem(SafeGdiIcon iconHandle, Interop.SHIL imageListIndex)
		: this(iconHandle, true)
	{
		this.DisplayText = $"{imageListIndex} {_icon.Width}x{_icon.Height}";
	}

	public ImageItem(IconDirectoryItem directoryItem)
		: this(directoryItem.CreateIcon(), true)
	{
		this.DisplayText = directoryItem.ResDirEntry.ToString();
	}

	public BitmapSource Icon => _icon;
	private BitmapSource _icon;

	public int Width => this.Icon.PixelWidth;

	public int Height => this.Icon.PixelHeight;

	public string DisplayText { get; } = null!;

	public override string ToString() => this.DisplayText;

	public void Dispose()
	{
		if (_icon is not null)
		{
			_icon = null!;
		}
		if (_iconHandle is not null)
		{
			_iconHandle.Dispose();
			_iconHandle = null!;
		}
		GC.SuppressFinalize(this);
	}

	~ImageItem()
	{
		this.Dispose();
	}
}
