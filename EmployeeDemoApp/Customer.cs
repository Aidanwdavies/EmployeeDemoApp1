using System;
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
