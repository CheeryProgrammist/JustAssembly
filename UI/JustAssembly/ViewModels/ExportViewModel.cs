using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using JustAssembly.Interfaces;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;

namespace JustAssembly.ViewModels
{
    class ExportViewModel : NotificationObject
    {
	    public ICommand ExportCommand { get; private set; }

	    private string _filePath;
		public string FilePath
	    {
		    get
		    {
			    return _filePath;
		    }
		    set
		    {
			    if (this._filePath != value)
			    {
				    this._filePath = value;

				    this.RaisePropertyChanged("FilePath");

					this.RaisePropertyChanged("IsSaveEnabled");
			    }
		    }
	    }
	    public bool IsSaveEnabled
	    {
		    get
		    {
			    if (string.IsNullOrWhiteSpace(_filePath) || string.IsNullOrWhiteSpace(_filePath))
			    {
				    return false;
			    }

				return Directory.Exists(Path.GetDirectoryName(_filePath)) && Path.GetExtension(_filePath).StartsWith(".xls");
		    }
	    }

		public ExportViewModel()
		{
			this.ExportCommand = new DelegateCommand(OnSaveReport);
        }

	    private void OnSaveReport()
	    {
		    MessageBox.Show("Hi!");
	    }
    }
}
