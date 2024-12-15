namespace EmployeeDemoApp
{
public partial class Dashboard : ContentPage
	{
		public Dashboard()
		{
			InitializeComponent();
		}
		// Event handler for when the 'New Appointment' button is clicked
		private async void NewAppointment_Clicked(object sender, EventArgs e)
		{
			// Placeholder for future navigation or logic to add a new appointment
			await Navigation.PushAsync(new CustomerPage());
		}

		// Event handler for when the 'New Service' button is clicked
		private async void NewService_Clicked(object sender, EventArgs e)
		{
			// Placeholder for future navigation or logic to add a new service request
			await Navigation.PushAsync(new CustomerPage());
		}
	}
}

