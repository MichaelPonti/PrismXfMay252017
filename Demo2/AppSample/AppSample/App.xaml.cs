using Prism.Unity;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using AppSample.Views;
using AppSample.ViewModels;

namespace AppSample
{
	public static class Pages
	{
		public const string Main = "main";


		public const string Master = "master";
		public const string Navigation = "nav";
		public const string Dashboard = "dashboard";
		public const string SpecialFunc = "special";
		public const string Settings = "settings";
		public const string About = "about";
		public const string SpecialFuncDetails = "specfuncspage";
	}




	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null)
			: base(initializer)
		{
		}


		protected override void OnInitialized()
		{
			InitializeComponent();
			//NavigationService.NavigateAsync(Pages.Main);
			NavigationService.NavigateAsync($"/{Pages.Master}/{Pages.Navigation}/{Pages.Dashboard}");
		}

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<MainPage>(Pages.Main);


			Container.RegisterType<Services.ISettingsService, Services.SettingsService1>();


			Container.RegisterTypeForNavigation<MyMasterPage, MyMasterPageViewModel>(Pages.Master);
			Container.RegisterTypeForNavigation<MyNavigationPage>(Pages.Navigation);
			Container.RegisterTypeForNavigation<DashboardPage>(Pages.Dashboard);
			Container.RegisterTypeForNavigation<AboutPage>(Pages.About);
			Container.RegisterTypeForNavigation<SettingsPage, SettingsPageViewModel>(Pages.Settings);
			Container.RegisterTypeForNavigation<SpecialFuncDetailPage, SpecialFuncDetailsPageViewModel>(Pages.SpecialFuncDetails);


			if (IsPaidFor())
			{
				Container.RegisterTypeForNavigation<SpecialFuncsPaidPage, SpecialFuncPageViewModel>(Pages.SpecialFunc);
			}
			else
			{
				Container.RegisterTypeForNavigation<SpecialFuncPage, SpecialFuncPageViewModel>(Pages.SpecialFunc);
			}

		}



		/// <summary>
		/// this function will just check if the app has
		/// been upgraded to the paid version or not.
		/// </summary>
		/// <returns>true if paid/false if not</returns>
		private bool IsPaidFor()
		{
			return true;
		}



		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
