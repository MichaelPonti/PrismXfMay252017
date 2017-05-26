using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSample.ViewModels
{
	public class SpecialFuncPageViewModel : BindableBase
	{
		private INavigationService _navigationService = null;


		public SpecialFuncPageViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
		}


		#region properties


		private string _dataForDetails = null;
		public string DataForDetails
		{
			get { return _dataForDetails; }
			set
			{
				/// SetProperty returns true if the value changes on the property
				/// only update the ui if the value changes
				if (SetProperty<string>(ref _dataForDetails, value))
				{
					CommandDetails.RaiseCanExecuteChanged();
				}
			}
		}


		#endregion


		#region CommandDetails implementation


		private DelegateCommand _commandDetails = null;
		public DelegateCommand CommandDetails
		{
			get
			{
				return _commandDetails ??
					(_commandDetails = new DelegateCommand(
						async () =>
						{
							NavigationParameters nps = new NavigationParameters();
							nps.Add(SpecialFuncDetailsPageViewModel.DetailParamText, DataForDetails);
							await _navigationService.NavigateAsync(Pages.SpecialFuncDetails, nps, false, true);
						},
						() => !String.IsNullOrWhiteSpace(DataForDetails)));
			}
		}


		#endregion
	}
}
