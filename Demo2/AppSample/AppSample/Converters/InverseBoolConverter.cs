using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppSample.Converters
{
	/// <summary>
	/// have a xaml property that binds to a bool but your view model stores the inverse?
	/// Use this value converter to flip the bool value before feeding it into the 
	/// xaml property. You get to keep the business logic that makes sense.
	/// </summary>
	public class InverseBoolConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool v = (bool) value;
			return !v;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
