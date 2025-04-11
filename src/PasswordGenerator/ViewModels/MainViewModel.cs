using PasswordGenerator.Stores;
using System.ComponentModel;
using System.Windows.Input;

namespace PasswordGenerator.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		private readonly NavigationStore _navigationStore;

		public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

		public MainViewModel(NavigationStore navigationStore)
		{
			_navigationStore = navigationStore;
			_navigationStore.PropertyChanged += OnCurrentViewModelChanged;
		}

		private void OnCurrentViewModelChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(_navigationStore.CurrentViewModel))
				OnPropertyChanged(nameof(CurrentViewModel));
		}
	}
}
