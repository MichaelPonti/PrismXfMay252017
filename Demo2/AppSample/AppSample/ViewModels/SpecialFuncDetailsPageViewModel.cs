using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSample.ViewModels
{
	public class SpecialFuncDetailsPageViewModel : BindableBase, INavigatedAware, INavigatingAware
	{
		public const string DetailParamText = "detailparamtext";



		private INavigationService _navigationService = null;


		public SpecialFuncDetailsPageViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
		}


		#region properties

		private string _navParamText = null;
		public string NavParamText
		{
			get { return _navParamText; }
			set { SetProperty<string>(ref _navParamText, value); }
		}

		#endregion

		public void OnNavigatedFrom(NavigationParameters parameters)
		{
		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
			if (parameters != null && parameters.ContainsKey(DetailParamText))
			{
				NavParamText = (string) parameters[DetailParamText];
			}
		}

		public void OnNavigatingTo(NavigationParameters parameters)
		{
		}
	}
}
