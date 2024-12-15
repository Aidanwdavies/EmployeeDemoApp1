using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

// Author: [Aidan Davies, Kaifang Wang]
// Date: [Dec 15th, 2024]

public class InventoryViewModel : BaseViewModel
{
	public ObservableCollection<InventoryItemViewModel> OilItems { get; set; }
	public ObservableCollection<InventoryItemViewModel> TiresItems { get; set; }
	public ObservableCollection<InventoryItemViewModel> AirFiltersItems { get; set; }
	public ObservableCollection<InventoryItemViewModel> WindshieldItems { get; set; }
	public ObservableCollection<InventoryItemViewModel> ExhaustItems { get; set; }
	public ObservableCollection<InventoryItemViewModel> StereoItems { get; set; }

	public ICommand UpdateStockCommand { get; set; }

	public InventoryViewModel()
	{
		// Initialize your collections and commands here
		OilItems = new ObservableCollection<InventoryItemViewModel>();
		TiresItems = new ObservableCollection<InventoryItemViewModel>();
		AirFiltersItems = new ObservableCollection<InventoryItemViewModel>();
		WindshieldItems = new ObservableCollection<InventoryItemViewModel>();
		ExhaustItems = new ObservableCollection<InventoryItemViewModel>();
		StereoItems = new ObservableCollection<InventoryItemViewModel>();

		// Populate your collections with initial data
		InitializeInventory();

		// Initialize the command
		UpdateStockCommand = new Command<InventoryItemViewModel>(ExecuteUpdateStockCommand);
	}

	private void InitializeInventory()
	{
		// Add sample data to OilItems, TiresItems, and AirFiltersItems
		OilItems.Add(new InventoryItemViewModel { Name = "Synthetic Oil", Stock = 10 });
		TiresItems.Add(new InventoryItemViewModel { Name = "Tire Sets", Stock = 20 });
		AirFiltersItems.Add(new InventoryItemViewModel { Name = "Universal Air Filter", Stock = 15 });
		WindshieldItems.Add(new InventoryItemViewModel { Name = "Windshields", Stock = 30 });
		ExhaustItems.Add(new InventoryItemViewModel { Name = "Exhausts", Stock = 60 });
		StereoItems.Add(new InventoryItemViewModel { Name = "Stereos", Stock = 15 });
	}

	private void ExecuteUpdateStockCommand(InventoryItemViewModel item)
	{
		try
		{
			if (int.TryParse(item.NewStock.ToString(), out int newStockValue))
			{
				item.Stock = newStockValue;
			}
			else
			{
				DisplayError("Invalid input. Please enter a valid number.");
			}
		}
		catch (Exception ex)
		{
			DisplayError($"An error occurred: {ex.Message}");
		}
	}

	private async void DisplayError(string errorMessage)
	{
		// Implement the logic to display an error message, such as using a MessageBox or an alert
		// For example, if you are using Xamarin.Forms, you can use DisplayAlert:
		// await Application.Current.MainPage.DisplayAlert("Error", errorMessage, "OK");
		await Application.Current.MainPage.DisplayAlert("Error", errorMessage, "OK");
	}

}

public class InventoryItemViewModel : BaseViewModel
{
	private string _name;
	private int _stock;
	private int _newStock;

	public string Name
	{
		get => _name;
		set => SetProperty(ref _name, value);
	}

	public int Stock
	{
		get => _stock;
		set => SetProperty(ref _stock, value);
	}

	public int NewStock
	{
		get => _newStock;
		set => SetProperty(ref _newStock, value);
	}
}

// Base class implementing INotifyPropertyChanged
public class BaseViewModel : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler PropertyChanged;

	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
	{
		if (EqualityComparer<T>.Default.Equals(storage, value))
			return false;

		storage = value;
		OnPropertyChanged(propertyName);
		return true;
	}
}

