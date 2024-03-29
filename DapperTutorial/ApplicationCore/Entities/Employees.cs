﻿using System;
namespace ApplicationCore.Entities
{
	public class Employees
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public decimal Salary { get; set; }
		public int departmentId { get; set; }

        // navigation property: used to help reference values from related table
        public Departments departments { get; set; }

    }
}

