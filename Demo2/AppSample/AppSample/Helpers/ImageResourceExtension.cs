using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSample.Helpers
{
	/// <summary>
	/// this is a xaml extension that will convert a string resource identifier in
	/// your xaml into an image source value that is pulled from the resource.
	/// </summary>
	[ContentProperty("Source")]
	public class ImageResourceExtension : IMarkupExtension
	{
		public string Source { get; set; }



		public object ProvideValue(IServiceProvider serviceProvider)
		{
			if (Source == null)
				return null;

			var imageSource = ImageSource.FromResource(Source);
			return imageSource;
		}
	}
}
