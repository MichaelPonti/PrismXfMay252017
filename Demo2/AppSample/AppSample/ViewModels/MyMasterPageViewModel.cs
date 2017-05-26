using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSample.ViewModels
{
	public class MyMasterPageViewModel : BindableBase, INavigationAware
	{
		private INavigationService _navigationService = null;

		public MyMasterPageViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
		}




		private MenuPageViewModel _menuViewModel = null;
		public MenuPageViewModel MenuViewModel
		{
			get { return _menuViewModel; }
			set { SetProperty<MenuPageViewModel>(ref _menuViewModel, value); }
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{
		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
			MenuViewModel = new MenuPageViewModel(_navigationService);
		}

		public void OnNavigatingTo(NavigationParameters parameters)
		{
		}
	}
}
