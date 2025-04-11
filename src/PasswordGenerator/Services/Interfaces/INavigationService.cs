using PasswordGenerator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Services.Interfaces
{
	public interface INavigationService
	{
		void NavigateTo<TViewModel>() where TViewModel : ViewModelBase;
	}
}
