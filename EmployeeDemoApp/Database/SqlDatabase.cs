
using EmployeeDemoApp.Exceptions;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
// Author: [Aidan Davies, Kaifang Wang]
// Date: [Dec 15th, 2024]
// Alias for Employee class to resolve naming conflict
using AppEmployee = EmployeeDemoApp.Employee;
using AppCustomer = EmployeeDemoApp.Customer;

namespace EmployeeDemoApp.Database
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        // Constructor with parameters
        public Employee(int id, string name, bool isActive)
        {
            Id = id;
            Name = name;
            IsActive = isActive;
        }
    }
	public class Customer
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Service { get; set; }

        public Customer(int id, string name, string service)
		{
			Id = id;
			Name = name;
			Service = service;
		}
	}

	public class SQLiteDatabase
    {
        private SqliteConnection sqliteConnection;

        public SQLiteDatabase() { }

        public void Open()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder
            {
                DataSource = "demo.db"
            };

            string connectionString = connectionStringBuilder.ToString();

            try
            {
                this.sqliteConnection = new SqliteConnection(connectionString);
                this.sqliteConnection.Open();
            }
            catch (SqliteException ex)
            {
                Console.WriteLine($"Error connecting to SQLite: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");

                // Rethrow the exception with a more informative message.
                throw new Exception("Unable to connect to the SQLite database. Please check your connection settings.", ex);
            }
            catch (TypeInitializationException ex)
            {
                Console.WriteLine($"TypeInitializationException: {ex.Message}");
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
            }
        }

        public void Add(AppEmployee employee)
        {
            try
            {
                if (this.sqliteConnection == null)
                {
                    // Throw a custom exception if there is no database connection
                    throw new NoDatabaseConnectionException();
                }

                using (var transaction = this.sqliteConnection.BeginTransaction())
                {
                    var cmd = this.sqliteConnection.CreateCommand();
                    cmd.CommandText = "INSERT INTO employees (Id, Name, IsActive) VALUES (@Id, @Name, @IsActive)";
                    cmd.Parameters.AddWithValue("@Id", employee.Id);
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@IsActive", employee.IsActive);

                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
            catch (NoDatabaseConnectionException ex)
            {
                // Handle the exception specific to no database connection
                Console.WriteLine($"No database connection: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public List<AppEmployee> GetAllEmployees()
        {
            List<AppEmployee> employees = new List<AppEmployee>();

            try
            {
                if (this.sqliteConnection == null)
                {
                    // Throw a custom exception if there is no database connection
                    throw new NoDatabaseConnectionException();
                }

                var cmd = this.sqliteConnection.CreateCommand();
                cmd.CommandText = "SELECT Id, Name, IsActive FROM employees";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Provide values for the constructor parameters
                        AppEmployee employee = new AppEmployee(
                            id: Convert.ToInt32(reader["Id"]),
                            name: Convert.ToString(reader["Name"]),
                            isActive: Convert.ToBoolean(reader["IsActive"])
                        );

                        employees.Add(employee);
                    }
                }
            }
            catch (NoDatabaseConnectionException ex)
            {
                // Handle the exception specific to no database connection
                Console.WriteLine($"No database connection: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine($"Error: {ex.Message}");
            }

            return employees;
        }

		public void Add(AppCustomer customer)
		{
			try
			{
				if (this.sqliteConnection == null)
				{
					// Throw a custom exception if there is no database connection
					throw new NoDatabaseConnectionException();
				}

				using (var transaction = this.sqliteConnection.BeginTransaction())
				{
					var cmd = this.sqliteConnection.CreateCommand();
					cmd.CommandText = "INSERT INTO customers (Id, Name, Service) VALUES (@Id, @Name, @Service";
					cmd.Parameters.AddWithValue("@Id", customer.Id);
					cmd.Parameters.AddWithValue("@Name", customer.Name);
					cmd.Parameters.AddWithValue("@Service", customer.Service);

					cmd.ExecuteNonQuery();

					transaction.Commit();
				}
			}
			catch (NoDatabaseConnectionException ex)
			{
				// Handle the exception specific to no database connection
				Console.WriteLine($"No database connection: {ex.Message}");
			}
			catch (Exception ex)
			{
				// Handle other exceptions
				Console.WriteLine($"Error: {ex.Message}");
			}
		}

		public List<AppCustomer> GetAllCustomers()
		{
			List<AppCustomer> customers = new List<AppCustomer>();

			try
			{
				if (this.sqliteConnection == null)
				{
					// Throw a custom exception if there is no database connection
					throw new NoDatabaseConnectionException();
				}

				var cmd = this.sqliteConnection.CreateCommand();
				cmd.CommandText = "SELECT Id, Name, Service FROM customers";

				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						// Provide values for the constructor parameters
						AppCustomer customer = new AppCustomer(
							id: Convert.ToInt32(reader["Id"]),
							name: Convert.ToString(reader["Name"]),
							service: Convert.ToString(reader["Service"])
						);

						customers.Add(customer);
					}
				}
			}
			catch (NoDatabaseConnectionException ex)
			{
				// Handle the exception specific to no database connection
				Console.WriteLine($"No database connection: {ex.Message}");
			}
			catch (Exception ex)
			{
				// Handle other exceptions
				Console.WriteLine($"Error: {ex.Message}");
			}

			return customers;
		}



		public void Close()
        {
            if (this.sqliteConnection != null)
            {
                this.sqliteConnection.Close();
                this.sqliteConnection = null;
            }
        }
    }
}
