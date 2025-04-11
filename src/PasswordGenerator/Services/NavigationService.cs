using PasswordGenerator.Services.Interfaces;
using PasswordGenerator.Stores;
using PasswordGenerator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Services
{
	internal class NavigationService : INavigationService
	{
		private readonly NavigationStore _navigationStore;
		private readonly Func<ViewModelBase> _createViewModel;

		public NavigationService(NavigationStore navigationStore,Func<ViewModelBase> createViewModel)
		{
			_navigationStore = navigationStore;
			_createViewModel = createViewModel;
		}

		public void Navigate()
		{
			_navigationStore.CurrentViewModel = _createViewModel();
		}
	}
}
