using AppSample.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AppSample.ViewModels
{
	public class SettingsPageViewModel : BindableBase
	{
		private ISettingsService _settingsService = null;


		public SettingsPageViewModel(ISettingsService settingsService)
		{
			_settingsService = settingsService;
		}




		private string _setting1;
		public string Setting1
		{
			get { return _setting1; }
			set { SetProperty<string>(ref _setting1, value); }
		}
		private int _setting2;
		public int Setting2
		{
			get { return _setting2; }
			set { SetProperty<int>(ref _setting2, value); }
		}




		private DelegateCommand _commandSave = null;
		public DelegateCommand CommandSave
		{
			get
			{
				return _commandSave ??
					(_commandSave = new DelegateCommand(
						() =>
						{
							_settingsService.SaveSettings();
						}));
			}
		}
	}
}
