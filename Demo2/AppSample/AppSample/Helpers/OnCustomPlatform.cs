using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSample.Helpers
{
	/// <summary>
	/// this is a xaml helper that will allow us to specify different values
	/// to a property based on the platform.
	/// <button ...>
	///     <Button.Margin>
	///         <h:OnCustomPlatform x:TypeArguments="Thickness" Android="10,5,2,1" iOS="34, 20, 3,2" ... />
	///     </Button.Margin>
	/// </button>
	/// Using the above as a guide, we can specify different values for the button
	/// margin based on the platform.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class OnCustomPlatform<T>
	{
		/// <summary>
		/// these are the properties that you can specify in your XAML
		/// the implicit operator takes care of deciding which of the
		/// properties to use in the xaml.
		/// </summary>
		public T Android { get; set; }
		public T iOS { get; set; }
		public T WinPhone { get; set; }
		public T Windows { get; set; }
		public T Other { get; set; }


		public OnCustomPlatform()
		{
			Android = default(T);
			iOS = default(T);
			WinPhone = default(T);
			Windows = default(T);
			Other = default(T);
		}


		/// <summary>
		/// Xamarin has deprecated the TargetPlatform and device used
		/// in this function. Need to update to use what is current.
		/// </summary>
		/// <param name="onPlatform"></param>
#pragma warning disable CS0612 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete

		public static implicit operator T(OnCustomPlatform<T> onPlatform)
		{
			switch (Xamarin.Forms.Device.OS)
			{
				case Xamarin.Forms.TargetPlatform.Android:
					return onPlatform.Android;
				case Xamarin.Forms.TargetPlatform.iOS:
					return onPlatform.iOS;
				case Xamarin.Forms.TargetPlatform.WinPhone:
					return onPlatform.WinPhone;
				case Xamarin.Forms.TargetPlatform.Windows:
					return (Xamarin.Forms.Device.Idiom == Xamarin.Forms.TargetIdiom.Desktop) ? onPlatform.Windows : onPlatform.WinPhone;
				default:
					return onPlatform.Other;
			}
		}

#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning restore CS0612 // Type or member is obsolete


	}
}
