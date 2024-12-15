using System;

// Author: [Aidan Davies, Kaifang Wang]
// Date: [Dec 15th, 2024]


namespace EmployeeDemoApp
{
	public class Customer
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Service {  get; set; }

		public Customer(int id, string name, string service)
		{
			Id = id;
			Name = name;
			Service = service;
		}
	}

}
