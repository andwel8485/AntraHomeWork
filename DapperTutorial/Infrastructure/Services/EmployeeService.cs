using System;
using Infrastructure.Repositories;
using ApplicationCore.Entities;
namespace Infrastructure.Services
{
	public class EmployeeService
	{
		private EmployeeRepository ERepo;
		public EmployeeService()
		{
			ERepo = new EmployeeRepository();
        }

        public Employees GetEmployeeById()
        {
            Console.WriteLine("Please Enter Employee Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            var e = ERepo.GetById(id);
            if (e == null)
            {
                Console.WriteLine("No such Id!!");
                return e;
            }
            Console.WriteLine($"{e.FirstName}\t{e.LastName}\t{e.departmentId}");
            return e;
        }

        public void DeleteEmployeeById()
        {
            Console.WriteLine("Please Enter Employee Id:");
            ERepo.DeleteById(Convert.ToInt32(Console.ReadLine()));
        }

        public void InsertEmployee()
        {
            Employees e = new Employees();
            Console.WriteLine("Please Enter Employee FirstName:");
            e.FirstName = Console.ReadLine();
            Console.WriteLine("Please Enter Employee LastName:");
            e.LastName = Console.ReadLine();
            Console.WriteLine("Please Enter Employee DepartmentId:");
            e.departmentId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter Employee Salary:");
            e.Salary = Convert.ToDecimal(Console.ReadLine());


            if (ERepo.Insert(e) > 0)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Fail");
            }
        }

        public void UpdateEmployee()
        {
            var e = GetEmployeeById();

            Console.WriteLine("Please Enter New Employee FirstName:");
            e.FirstName = Console.ReadLine();
            Console.WriteLine("Please Enter New Employee LastName:");
            e.LastName = Console.ReadLine();
            Console.WriteLine("Please Enter New Employee DepartmentId:");
            e.departmentId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter New Employee Salary:");
            e.Salary = Convert.ToDecimal(Console.ReadLine());
            ERepo.Update(e);

        }

        public void GetAllEmployees()
        {
            IEnumerable<Employees> employees = ERepo.GetAll();
            foreach (Employees employee in employees)
            {
                Console.WriteLine($"{employee.Id}\t {employee.FirstName} \t {employee.LastName}\t" +
                    $"{employee.departmentId}\t{employee.Salary}");
            }
        }
    }
}

