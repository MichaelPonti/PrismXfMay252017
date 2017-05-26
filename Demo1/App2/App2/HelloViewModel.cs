using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
	public class HelloViewModel : BindableBase
	{
		public HelloViewModel()
		{
		}


		private string _name = null;
		public string Name
		{
			get { return _name; }
			set
			{
				/// the set property returns true if the property
				/// was actually changed.
				if (SetProperty<string>(ref _name, value))
				{
					/// since the property was changed, lets tell the
					/// button to re-evaluate whether it is enabled or not
					CommandHello.RaiseCanExecuteChanged();
				}
			}
		}



		private string _result = null;
		public string Result
		{
			get { return _result; }
			set { SetProperty<string>(ref _result, value); }
		}


		private DelegateCommand _commandHello = null;
		public DelegateCommand CommandHello
		{
			get
			{
				return _commandHello ??
					(_commandHello = new DelegateCommand(CommandHelloExecute, CommandHelloCanExecute));
			}
		}


		/// <summary>
		/// if the CommandHello button is tapped, construct a greeting 
		/// and store it in the Result property
		/// </summary>
		private void CommandHelloExecute()
		{
			Result = $"Hello {Name}!!!";
		}

		/// <summary>
		/// We should only tap the command button if there
		/// is something specified in the name property.
		/// </summary>
		/// <returns></returns>
		private bool CommandHelloCanExecute()
		{
			return !String.IsNullOrWhiteSpace(Name);
		}

	}

}
