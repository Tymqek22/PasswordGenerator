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
	public class NavigationService : INavigationService
	{
		private readonly NavigationStore _navigationStore;
		private readonly Func<Type,ViewModelBase> _createViewModel;

		public NavigationService(NavigationStore navigationStore,Func<Type,ViewModelBase> createViewModel)
		{
			_navigationStore = navigationStore;
			_createViewModel = createViewModel;
		}

		public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
		{
			_navigationStore.CurrentViewModel = _createViewModel(typeof(TViewModel));
		}
	}
}
