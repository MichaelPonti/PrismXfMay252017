using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Navigation;
using Prism.Commands;

namespace AppSample.ViewModels
{
	public class MenuPageViewModel : BindableBase
	{
		private INavigationService _navigationService = null;

		public MenuPageViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
			InitializeMenu();
		}



		#region properties


		private ObservableCollection<MenuItemViewModel> _menuItems = null;
		public ObservableCollection<MenuItemViewModel> MenuItems
		{
			get { return _menuItems; }
			set { SetProperty<ObservableCollection<MenuItemViewModel>>(ref _menuItems, value); }
		}


		#endregion




		private void InitializeMenu()
		{
			ObservableCollection<MenuItemViewModel> items = new ObservableCollection<MenuItemViewModel>()
			{
				new MenuItemViewModel(MenuItemTypeEnum.Dashboard, "dashboard", $"{Pages.Navigation}/{Pages.Dashboard}"),
				new MenuItemViewModel(MenuItemTypeEnum.SpecialFunc1, "special func", $"{Pages.Navigation}/{Pages.SpecialFunc}"),
				new MenuItemViewModel(MenuItemTypeEnum.Settings, "settings", $"{Pages.Navigation}/{Pages.Settings}"),
				new MenuItemViewModel(MenuItemTypeEnum.About, "about", $"{Pages.Navigation}/{Pages.About}")
			};

			MenuItems = items;
		}


		private void UpdateCommands()
		{
			CommandMenuItemSelected.RaiseCanExecuteChanged();
		}


		private DelegateCommand<MenuItemViewModel> _commandMenuItemSelected = null;
		public DelegateCommand<MenuItemViewModel> CommandMenuItemSelected
		{
			get
			{
				return _commandMenuItemSelected ??
					(_commandMenuItemSelected = new DelegateCommand<MenuItemViewModel>(
						(a) =>
						{
							MenuItemViewModel item = a as MenuItemViewModel;
							if (item != null && !String.IsNullOrWhiteSpace(item.NavigationPath))
							{
								_navigationService.NavigateAsync(item.NavigationPath);
							}

							UpdateCommands();
						}));
			}
		}
	}
}
