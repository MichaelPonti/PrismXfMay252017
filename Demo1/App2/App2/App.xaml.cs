using Prism.Unity;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App2
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null)
			: base(initializer)
		{
		}


		protected override void OnInitialized()
		{
			InitializeComponent();
			NavigationService.NavigateAsync("Hello");
		}




		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<MainPage, HelloViewModel>("Hello");
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
