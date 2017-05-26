using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSample.ViewModels
{
	public class MenuItemViewModel : BindableBase
	{
		public MenuItemViewModel()
		{
		}

		public MenuItemViewModel(MenuItemTypeEnum menuItemType, string title, string navigationPath)
		{
			MenuItemType = menuItemType;
			Title = title;
			NavigationPath = navigationPath;
		}


		public string NavigationPath { get; set; }



		#region properties

		private MenuItemTypeEnum _menuItemType;
		public MenuItemTypeEnum MenuItemType
		{
			get { return _menuItemType; }
			set { SetProperty<MenuItemTypeEnum>(ref _menuItemType, value); }
		}


		private string _title = null;
		public string Title
		{
			get { return _title; }
			set { SetProperty<string>(ref _title, value); }
		}

		#endregion
	}
}
