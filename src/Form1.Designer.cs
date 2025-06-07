
namespace IconViewer;

partial class Form1
{
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	/// Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing)
	{
		this.ClearImageListBox();

		if (disposing && (components != null))
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
		_filePanel = new Panel();
		_fileNameLabel = new Label();
		_browseButton = new Button();
		_filePathComboBox = new ComboBox();
		_extractButton = new Button();
		_iconPictureBox = new PictureBox();
		_imagesListBox = new ListBox();
		_saveAsButton = new Button();
		_imagePanel = new Panel();
		_borderPanel = new Panel();
		_showBorderCheckBox = new CheckBox();
		_filePanel.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)_iconPictureBox).BeginInit();
		_imagePanel.SuspendLayout();
		_borderPanel.SuspendLayout();
		this.SuspendLayout();
		// 
		// _filePanel
		// 
		_filePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		_filePanel.Controls.Add(_fileNameLabel);
		_filePanel.Controls.Add(_browseButton);
		_filePanel.Controls.Add(_filePathComboBox);
		_filePanel.Controls.Add(_extractButton);
		_filePanel.Dock = DockStyle.Top;
		_filePanel.Location = new Point(0, 0);
		_filePanel.Margin = new Padding(15);
		_filePanel.Name = "_filePanel";
		_filePanel.Size = new Size(524, 53);
		_filePanel.TabIndex = 0;
		// 
		// _fileNameLabel
		// 
		_fileNameLabel.AutoSize = true;
		_fileNameLabel.Location = new Point(14, 19);
		_fileNameLabel.Margin = new Padding(4, 0, 4, 0);
		_fileNameLabel.Name = "_fileNameLabel";
		_fileNameLabel.Size = new Size(61, 15);
		_fileNameLabel.TabIndex = 1;
		_fileNameLabel.Text = "&File name:";
		// 
		// _browseButton
		// 
		_browseButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		_browseButton.Location = new Point(378, 13);
		_browseButton.Margin = new Padding(4, 3, 4, 3);
		_browseButton.Name = "_browseButton";
		_browseButton.Size = new Size(33, 27);
		_browseButton.TabIndex = 3;
		_browseButton.Text = "...";
		_browseButton.UseVisualStyleBackColor = true;
		_browseButton.Click += this.BrowseButton_Click;
		// 
		// _filePathComboBox
		// 
		_filePathComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		_filePathComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
		_filePathComboBox.AutoCompleteSource = AutoCompleteSource.FileSystem;
		_filePathComboBox.Location = new Point(85, 15);
		_filePathComboBox.Margin = new Padding(0);
		_filePathComboBox.Name = "_filePathComboBox";
		_filePathComboBox.Size = new Size(293, 23);
		_filePathComboBox.Sorted = true;
		_filePathComboBox.TabIndex = 2;
		_filePathComboBox.TextChanged += this.FilePathComboBox_TextChanged;
		// 
		// _extractButton
		// 
		_extractButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		_extractButton.Enabled = false;
		_extractButton.Location = new Point(423, 13);
		_extractButton.Margin = new Padding(4, 3, 4, 3);
		_extractButton.Name = "_extractButton";
		_extractButton.Size = new Size(88, 27);
		_extractButton.TabIndex = 4;
		_extractButton.Text = "&Extract";
		_extractButton.UseVisualStyleBackColor = true;
		_extractButton.Click += this.ExtractButton_Click;
		// 
		// _iconPictureBox
		// 
		_iconPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		_iconPictureBox.BackColor = SystemColors.AppWorkspace;
		_iconPictureBox.Location = new Point(1, 1);
		_iconPictureBox.Margin = new Padding(0);
		_iconPictureBox.Name = "_iconPictureBox";
		_iconPictureBox.Size = new Size(96, 96);
		_iconPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
		_iconPictureBox.TabIndex = 6;
		_iconPictureBox.TabStop = false;
		// 
		// _imagesListBox
		// 
		_imagesListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		_imagesListBox.DisplayMember = "DisplayText";
		_imagesListBox.Enabled = false;
		_imagesListBox.FormattingEnabled = true;
		_imagesListBox.Location = new Point(14, 52);
		_imagesListBox.Margin = new Padding(4, 3, 4, 3);
		_imagesListBox.Name = "_imagesListBox";
		_imagesListBox.Size = new Size(224, 289);
		_imagesListBox.TabIndex = 1;
		_imagesListBox.SelectedIndexChanged += this.ImagesListBox_SelectedIndexChanged;
		// 
		// _saveAsButton
		// 
		_saveAsButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		_saveAsButton.Enabled = false;
		_saveAsButton.Location = new Point(423, 323);
		_saveAsButton.Margin = new Padding(4, 3, 4, 3);
		_saveAsButton.Name = "_saveAsButton";
		_saveAsButton.Size = new Size(88, 27);
		_saveAsButton.TabIndex = 4;
		_saveAsButton.Text = "Save &as...";
		_saveAsButton.UseVisualStyleBackColor = true;
		_saveAsButton.Click += this.SaveAsButton_Click;
		// 
		// _imagePanel
		// 
		_imagePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		_imagePanel.Controls.Add(_borderPanel);
		_imagePanel.Location = new Point(252, 52);
		_imagePanel.Margin = new Padding(0);
		_imagePanel.Name = "_imagePanel";
		_imagePanel.Size = new Size(258, 258);
		_imagePanel.TabIndex = 2;
		_imagePanel.Resize += this.ImagePanel_Resize;
		// 
		// _borderPanel
		// 
		_borderPanel.BackColor = SystemColors.ControlText;
		_borderPanel.Controls.Add(_iconPictureBox);
		_borderPanel.Location = new Point(0, 0);
		_borderPanel.Margin = new Padding(0);
		_borderPanel.Name = "_borderPanel";
		_borderPanel.Size = new Size(98, 98);
		_borderPanel.TabIndex = 0;
		_borderPanel.Visible = false;
		// 
		// _showBorderCheckBox
		// 
		_showBorderCheckBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		_showBorderCheckBox.AutoSize = true;
		_showBorderCheckBox.Enabled = false;
		_showBorderCheckBox.Location = new Point(252, 328);
		_showBorderCheckBox.Name = "_showBorderCheckBox";
		_showBorderCheckBox.Size = new Size(93, 19);
		_showBorderCheckBox.TabIndex = 3;
		_showBorderCheckBox.Text = "Show &border";
		_showBorderCheckBox.UseVisualStyleBackColor = true;
		_showBorderCheckBox.CheckedChanged += this.ShowBorderCheckBox_CheckedChanged;
		// 
		// Form1
		// 
		this.AcceptButton = _extractButton;
		this.AutoScaleDimensions = new SizeF(7F, 15F);
		this.AutoScaleMode = AutoScaleMode.Font;
		this.ClientSize = new Size(524, 363);
		this.Controls.Add(_showBorderCheckBox);
		this.Controls.Add(_imagePanel);
		this.Controls.Add(_saveAsButton);
		this.Controls.Add(_imagesListBox);
		this.Controls.Add(_filePanel);
		this.Margin = new Padding(4, 3, 4, 3);
		this.MinimumSize = new Size(540, 402);
		this.Name = "Form1";
		this.StartPosition = FormStartPosition.CenterScreen;
		this.Text = "Extract Associated Icon";
		_filePanel.ResumeLayout(false);
		_filePanel.PerformLayout();
		((System.ComponentModel.ISupportInitialize)_iconPictureBox).EndInit();
		_imagePanel.ResumeLayout(false);
		_borderPanel.ResumeLayout(false);
		this.ResumeLayout(false);
		this.PerformLayout();

	}

	#endregion

	private System.Windows.Forms.Panel _filePanel;
	private System.Windows.Forms.Button _extractButton;
	private System.Windows.Forms.ComboBox _filePathComboBox;
	private System.Windows.Forms.PictureBox _iconPictureBox;
	private System.Windows.Forms.ListBox _imagesListBox;
	private System.Windows.Forms.Label _fileNameLabel;
	private System.Windows.Forms.Button _saveAsButton;
	private System.Windows.Forms.Button _browseButton;
	private System.Windows.Forms.Panel _imagePanel;
	private System.Windows.Forms.CheckBox _showBorderCheckBox;
	private System.Windows.Forms.Panel _borderPanel;
}

