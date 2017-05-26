using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSample.Services
{
	public class SettingsService1 : ISettingsService
	{
		public bool ReadSettings()
		{
			Debug.WriteLine("SettingsService1.Read");
			return true;
		}

		public void SaveSettings()
		{
			Debug.WriteLine("SettingsService1.Save");
		}
	}
}
