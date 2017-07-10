using System;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Input;

namespace JustAssembly.SelectorControl
{
	public partial class SelectorControl : System.Windows.Controls.Control
    {
        public SelectorControl()
        {
            this.DefaultStyleKey = typeof(SelectorControl);

            this.BrowseCommand = new DelegateCommand(OnBrowseFilePathExecuted);
        }

        public static readonly DependencyProperty FilePathProperty =
                DependencyProperty.Register("FilePath", typeof(string), typeof(SelectorControl));

        public static readonly DependencyProperty BrowseCommandProperty =
                DependencyProperty.Register("BrowseCommand", typeof(ICommand), typeof(SelectorControl));

        public static readonly DependencyProperty SelectedItemTypeProperty =
                DependencyProperty.Register("SelectedItemType", typeof(SelectedItemType), typeof(SelectorControl));

        public static readonly DependencyProperty HeaderProperty =
                DependencyProperty.Register("Header", typeof(string), typeof(SelectorControl));

        public static readonly DependencyProperty FilterProperty =
                DependencyProperty.Register("Filter", typeof(string), typeof(SelectorControl));

        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public string Filter
        {
            get { return (string)GetValue(FilterProperty); }
            set { SetValue(FilterProperty, value); }
        }

        public SelectedItemType SelectedItemType
        {
            get { return (SelectedItemType)GetValue(SelectedItemTypeProperty); }
            set { SetValue(SelectedItemTypeProperty, value); }
        }
        
        private void OnBrowseFilePathExecuted()
        {
	        switch (this.SelectedItemType)
			{
				case SelectedItemType.File:
					GetEnteredFilePath();
					break;
				case SelectedItemType.Folder:
					GetEnteredFolderPath();
					break;
				case SelectedItemType.SaveToFile:
					GetSaveFilePath();
					break;
				default: throw new InvalidOperationException();
            }
        }

	    private void GetEnteredFolderPath()
        {
            System.Windows.Forms.FolderBrowserDialog showDialog = new System.Windows.Forms.FolderBrowserDialog()
            {
                ShowNewFolderButton = true
            };

            System.Windows.Forms.DialogResult showDialogResult = showDialog.ShowDialog();

            if (showDialogResult == System.Windows.Forms.DialogResult.OK)
            {
                FilePath = showDialog.SelectedPath;
            }
        }

        private void GetEnteredFilePath()
        {
            OpenFileDialog showDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Multiselect = false,
                Filter = this.Filter
            };
            bool? showDialogResult = showDialog.ShowDialog();

            if (showDialogResult == true)
            {
                FilePath = showDialog.FileName;
            }
		}

	    private void GetSaveFilePath()
	    {
		    var dialog = new SaveFileDialog()
		    {
			    Filter = "Excel Files | *.xlsx"
		    };
		    bool? showDialogResult = dialog.ShowDialog();
			
		    if (showDialogResult == true)
		    {
			    FilePath = dialog.FileName;
		    }
		}

		public ICommand BrowseCommand
        {
            get { return (ICommand)GetValue(BrowseCommandProperty); }
            set { SetValue(BrowseCommandProperty, value); }
        }

        public string FilePath
        {
            get
            {
                return (string)this.GetValue(FilePathProperty);
            }
            set
            {
                this.SetValue(FilePathProperty, value);
            }
        }
    }
}
