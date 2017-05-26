using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSample.Services
{
	public interface ISettingsService
	{
		void SaveSettings();
		bool ReadSettings();
	}
}
