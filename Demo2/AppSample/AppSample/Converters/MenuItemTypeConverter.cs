using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppSample.ViewModels;

namespace AppSample.Converters
{
	/// <summary>
	/// I love value converters!!!!
	/// I get to keep my viewmodel simple by using my business logic. For presenting
	/// I setup the IValueConverter so that it will take care of looking up the Image
	/// (which is in the presentation layer) and supplying it to the icon.
	/// IValueConverters are awesome.
	/// </summary>
	public class MenuItemTypeConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			MenuItemTypeEnum v = (MenuItemTypeEnum) value;
			switch (v)
			{
				case MenuItemTypeEnum.About:
					return ImageSource.FromResource("AppSample.Resources.menuabout.png");
				case MenuItemTypeEnum.Dashboard:
					return ImageSource.FromResource("AppSample.Resources.menudashboard.png");
				case MenuItemTypeEnum.Settings:
					return ImageSource.FromResource("AppSample.Resources.menusettings.png");
				case MenuItemTypeEnum.SpecialFunc1:
					return ImageSource.FromResource("AppSample.Resources.menuspecialfunc.png");
			}
			throw new ArgumentException();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
