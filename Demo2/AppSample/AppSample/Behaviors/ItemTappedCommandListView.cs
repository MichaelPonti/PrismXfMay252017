using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppSample.Behaviors
{
	/// <summary>
	/// a list view doesn't have a property that uses an ICommand when an item is tapped.
	/// So we have here is an attached property that can facilitate that between the list
	/// view and the view model.
	/// 
	/// We setup an attached proeprty taht contains an ICommand object. When you reference it
	/// in your Xaml you can can bind it to a property in your veiw model. Once the item has been
	/// bound it will setup an event handler that will be executed when the user taps an item
	/// </summary>
	public sealed class ItemTappedCommandListView
	{
		public static readonly BindableProperty ItemTappedCommandProperty =
			BindableProperty.CreateAttached(
				"ItemTappedCommand",
				typeof(ICommand),
				typeof(ItemTappedCommandListView),
				default(ICommand),
				BindingMode.OneWay,
				null,
				PropertyChanged);


		public static ICommand GetitemTappedCommand(BindableObject bindableObject)
		{
			return (ICommand) bindableObject.GetValue(ItemTappedCommandProperty);
		}

		public static void SetItemTappedCommand(BindableObject bindableObject, object value)
		{
			bindableObject.SetValue(ItemTappedCommandProperty, value);
		}



		private static void PropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var lv = bindable as ListView;
			if (lv != null)
			{
				lv.ItemTapped -= ListViewOnItemTapped;
				lv.ItemTapped += ListViewOnItemTapped;
			}
		}


		/// <summary>
		/// this is the workhorse. when the user taps the item, it will do the normal checks
		/// of making sure that we are seeing a list view. If the listview is stable and enabled
		/// we will get the selecteditem. this is the item view model. we will try nad get the 
		/// command property. If nothhing is null and the command is ok to execute, we will
		/// execute the command with the list item as the parameter.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private static void ListViewOnItemTapped(object sender, ItemTappedEventArgs e)
		{
			var list = sender as ListView;
			if (list != null && list.IsEnabled && !list.IsRefreshing)
			{
				list.SelectedItem = null;
				var command = GetitemTappedCommand(list);
				if (command != null && command.CanExecute(e.Item))
				{
					command.Execute(e.Item);
				}
			}
		}
	}
}
