using EmployeeDemoApp.Database; // Assuming the namespace is correct and database setup is similar
using System.Collections.ObjectModel;

namespace EmployeeDemoApp
{
	public partial class CustomerPage : ContentPage
	{
		public List<Customer> AllCustomers { get; set; }
		public ObservableCollection<Customer> DisplayedCustomers { get; set; }
		public SQLiteDatabase Database { get; set; }

		public string CSVFilePath
		{
			get
			{
				/**
                 * Just using File.ReadAllLines("Data\\employees.csv") will result in trying to read the file from C:\Windows\System32\....
                 * Instead, we need to get the directory for the running executable and concat "Data\employees.csv" to that.
                 */
				string currentDir = AppDomain.CurrentDomain.BaseDirectory;
				string filePath = Path.Combine(currentDir, "Data\\customers.csv");


				return filePath;
			}
		}

		/// <summary>
		/// Gets the full path to the JSON file.
		/// </summary>
		public string JSONFilePath
		{
			get
			{
				string currentDir = AppDomain.CurrentDomain.BaseDirectory;
				string filePath = Path.Combine(currentDir, "Data\\customers.json");

				return filePath;
			}
		}

		public CustomerPage()
		{
			InitializeComponent();

			this.AllCustomers = new List<Customer>();
			this.DisplayedCustomers = new ObservableCollection<Customer>();


			/**
             * Required!
             * Tells components to use this instance of MainPage to pull and push data from.
             */
			this.BindingContext = this;

			// Create connection to database
			this.Database = new SQLiteDatabase();
			this.Database.Open();

			// Populates employees and statuses.
			this.LoadCustomersFromDatabase();


			// Display all employees
			this.RefreshCustomers();
		}

		private void LoadCustomersFromDatabase()
		{
			// Replace Employee with Customer
			this.AllCustomers.Clear();

		}


		private void RefreshCustomers()
		{
			DisplayedCustomers.Clear();
			foreach (Customer customer in AllCustomers)
			{
				DisplayedCustomers.Add(customer);
			}
		}

		private void FindButton_Clicked(object sender, EventArgs e)
		{
			// Modify the filtering logic to apply to Customer properties
			int expectedId;
			string expectedName;
			string expectedService;

			if (string.IsNullOrEmpty(this.findCustomerIdEntry.Text) == false)
			{
				expectedId = int.Parse(this.findCustomerIdEntry.Text);
			}
			else
			{
				expectedId = 0;
			}

			if (string.IsNullOrEmpty(this.findCustomerNameEntry.Text) == false)
			{
				expectedName = this.findCustomerNameEntry.Text;
			}
			else
			{
				expectedName = "";
			}

			if (string.IsNullOrEmpty(this.findCustomerServiceEntry.Text) == false)
			{
				expectedService = this.findCustomerServiceEntry.Text;
			}
			else
			{
				expectedService = "";
			}

			bool findCustomersWithId = false;
			bool findCustomersWithName = false;
			bool findCustomersWithService = false;

			if (expectedId > 0)
			{
				findCustomersWithId = true;
			}

			if (expectedName.Length > 0)
			{
				findCustomersWithName = true;
			}

			if (expectedService.Length > 0) { findCustomersWithService = true; }

			ObservableCollection<Customer> found = new ObservableCollection<Customer>();

			foreach (Customer customer in this.AllCustomers)
			{
				bool idMatches = true;
				bool nameMatches = true;
				bool serviceMatches = true;

				// Create variables from employee object.
				int actualId = customer.Id;
				string actualName = customer.Name;
				string actualService = customer.Service;

				// Check if trying to find ID and if ID doesn't match expected ID.
				if (findCustomersWithId && actualId != expectedId)
				{
					idMatches = false;
				}

				// Check if trying to find name and if name doesn't contain expected name.
				if (findCustomersWithName && !actualName.Contains(expectedName))
				{
					nameMatches = false;
				}

				// Check if trying to find service and if name doesn't contain expected service
				if (findCustomersWithService && !actualService.Contains(expectedService))
				{
					serviceMatches = false;
				}

				// Add employee if matches
				if (idMatches && nameMatches && serviceMatches)
				{
					found.Add(customer);
				}
			}
			this.DisplayedCustomers.Clear();

			foreach (Customer customer in found)
			{
				this.DisplayedCustomers.Add(customer);
			}
		}

		private void Home_Clicked(object sender, EventArgs e)
		{
			// Handle home navigation if needed
		}

		private void SubmitButton_Clicked(object sender, EventArgs e)
		{
			// Handle the submission of any forms or actions
		}

		private void AddButton_Clicked(object sender, EventArgs e)
		{
			// Get input field values
			int id;
			string name;
			string service;

			if (string.IsNullOrEmpty(this.addCustomerIdEntry.Text) == false)
			{
				id = int.Parse(this.addCustomerIdEntry.Text);
			}
			else
			{
				id = -1;
			}

			if (string.IsNullOrEmpty(this.addCustomerNameEntry.Text) == false)
			{
				name = this.addCustomerNameEntry.Text;
			}
			else
			{
				name = "";
			}

			if (string.IsNullOrEmpty(this.addCustomerServiceEntry.Text) == false)
			{
				service = this.addCustomerServiceEntry.Text;
			}
			else
			{
				service = " ";
			}

			// Check if a name was entered.
			if (string.IsNullOrEmpty(name))
			{
				DisplayAlert("Ooops!", "The name cannot be empty.", "OK");
				return;
			}


			if (string.IsNullOrEmpty(service))
			{
				DisplayAlert("Ooops!", "The service must be selected.", "OK");
				return;
			}

			// Add employee


			Customer customer = new Customer(id, name, service);

			// Add to database
			this.Database.Add(customer);

			// Add to existing list
			this.AllCustomers.Add(customer);

			// Tell user employee was added
			this.DisplayAlert("Success!", "Customer was added.", "OK");

			// Display list with new employee
			this.RefreshCustomers();
		}

	}
}

