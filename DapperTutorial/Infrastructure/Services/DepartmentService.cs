using System;
using Infrastructure.Repositories;
using ApplicationCore.Entities;
namespace Infrastructure.Services

{
	public class DepartmentService
	{
        private DepartmentRepository DeptRepo;
		public DepartmentService()
		{
            DeptRepo = new DepartmentRepository();

        }
		public Departments GetDepartmentById()
		{
            Console.WriteLine("Please Enter Department Id:");
            var d = DeptRepo.GetById(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine($"{d.Department_Name}\t{d.Location}");
            return d;
        }

        public void DeleteDepartmentById()
        {
            Console.WriteLine("Please Enter Department Id:");
            DeptRepo.DeleteById(Convert.ToInt32(Console.ReadLine()));
        }

        public void InsertDepartment()
        {
            Departments d = new Departments();
            Console.WriteLine("Please Enter Department Name:");
            d.Department_Name = Console.ReadLine();
            Console.WriteLine("Please Enter Department Location:");
            d.Location = Console.ReadLine();

            if (DeptRepo.Insert(d) > 0)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Fail");
            }
        }

        public void UpdateDepartment()
        {
            var d = GetDepartmentById();
            Console.WriteLine("Please Enter New Department Name:");

            d.Department_Name = Console.ReadLine();
            Console.WriteLine("Please Enter New Department Location:");
            d.Location = Console.ReadLine();
            DeptRepo.Update(d);

        }

        public void GetAllDepartment()
        {
            IEnumerable<Departments> deparments = DeptRepo.GetAll();
            foreach (Departments department in deparments)
            {
                Console.WriteLine($"{department.Id}\t {department.Department_Name} \t {department.Location}");
            }
        }

    }
}

