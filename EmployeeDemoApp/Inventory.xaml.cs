namespace EmployeeDemoApp
{
	public partial class Inventory : ContentPage
	{
		public InventoryViewModel ViewModel { get; set; }

		public Inventory()
		{
			InitializeComponent();

			// Set the ViewModel as the BindingContext
			ViewModel = new InventoryViewModel();
			BindingContext = ViewModel;
		}
	}
}