using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prism.Navigation;
using Microsoft.Practices.Unity;

namespace App2.Test
{
	class TestNavigationService : INavigationService
	{
		public Task<bool> GoBackAsync(NavigationParameters parameters = null, bool? useModalNavigation = default(bool?), bool animated = true)
		{
			return Task.FromResult<bool>(true);
		}

		public Task NavigateAsync(string name, NavigationParameters parameters = null, bool? useModalNavigation = default(bool?), bool animated = true)
		{
			return Task.FromResult<object>(null);
		}

		public Task NavigateAsync(Uri uri, NavigationParameters parameters = null, bool? useModalNavigation = default(bool?), bool animated = true)
		{
			return Task.FromResult<object>(null);
		}
	}




	[TestClass]
	public class HelloViewModelTest
	{
		private const string TestNameValue = "mike";

		private IUnityContainer _container = null;

		public HelloViewModelTest()
		{
			_container = new UnityContainer();
			_container.RegisterInstance<INavigationService>(new TestNavigationService());
		}




		[TestMethod]
		public void TestButtonDisabled()
		{
			var vm = _container.Resolve<HelloViewModel>();

			/// make sure the Name property is blank and that means that
			/// the button should be disabled.
			vm.Name = null;
			bool canExecute = vm.CommandHello.CanExecute();
			Assert.IsFalse(canExecute, "hello button should be disabled");
		}


		[TestMethod]
		public void TestButtonEnabled()
		{
			var vm = _container.Resolve<HelloViewModel>();

			/// make sure the property has a value
			vm.Name = TestNameValue;
			bool canExecute = vm.CommandHello.CanExecute();
			Assert.IsTrue(canExecute, "hello button should be enabled");
		}


		[TestMethod]
		public void TestButtonExecution()
		{
			var vm = _container.Resolve<HelloViewModel>();

			/// supply a name value
			vm.Name = TestNameValue;
			vm.CommandHello.Execute();

			Assert.IsNotNull(vm.Result, "There should be a value");

			bool containsName = vm.Result.Contains(TestNameValue);
			Assert.IsTrue(containsName, "greeting should contain name");
		}


		[TestMethod]
		public void TestButtonExecutionNotValidName()
		{
			var vm = _container.Resolve<HelloViewModel>();

			// supply a name value
			vm.Name = TestNameValue;
			vm.CommandHello.Execute();

			bool containsName = vm.Result.Contains("mik3");
			Assert.IsFalse(containsName, "this should not be true");
		}
	}
}
