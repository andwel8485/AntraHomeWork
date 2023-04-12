using System;
using Infrastructure.Services;
namespace DapperTutorial.Menu
{
	public class menu
	{
		private EmployeeService ES;
		private DepartmentService DS;
		public menu()
		{
            ES = new EmployeeService();
			DS = new DepartmentService();
        }

		private void EmployeeUpdate()
		{
            bool keepgoing = true;
            while (keepgoing)
            {
                Console.WriteLine("Option1: Add Employee\nOption2: Delete Employee\n" +
                                  "Option3: Update Employeee\nOption4: Search Employee\n" +
                                  "Option5: View all Employees\nOption6: Exit");


                int option = Convert.ToInt32(Console.ReadLine());


                switch (option)
                {
                    case 1:
                        ES.InsertEmployee();
                        break;
                    case 2:
                        ES.DeleteEmployeeById();
                        break;
                    case 3:
                        ES.UpdateEmployee();
                        break;
                    case 4:
                        ES.GetEmployeeById();
                        break;
                    case 5:
                        ES.GetAllEmployees();
                        break;
                    case 6:
                        keepgoing = false;
                        break;

                    default:
                        Console.WriteLine("There is no such option!");
                        break;

                }
            }
        }


        private void DepartmentUpdate()
		{
			bool keepgoing = true;
			while (keepgoing)
			{
				Console.WriteLine("Option1: Add Department\nOption2: Delete Department\n" +
                                  "Option3: Update Department\nOption4: Search Department\n" +
                                  "Option5: View all Departments\nOption6: Exit");


				int option = Convert.ToInt32(Console.ReadLine());


				switch (option)
				{
					case 1:
						DS.InsertDepartment();
						break;
					case 2:
						DS.DeleteDepartmentById();
						break;
					case 3:
						DS.UpdateDepartment();
						break;
					case 4:
						DS.GetDepartmentById();
						break;
					case 5:
						DS.GetAllDepartment();
						break;
					case 6:
						keepgoing = false;
						break;

					default:
						Console.WriteLine("There is no such option!");
						break;

				}
			}
        }

		public void run()
		{
            bool keepgoing = true;
            while (keepgoing)
            {
                Console.WriteLine("Option1: Department\nOption2: Employee\n" +
                                  "Option3: Exit\n");

                int option = Convert.ToInt32(Console.ReadLine());

				switch (option)
				{
					case 1:
						DepartmentUpdate();
						break;
					case 2:
						EmployeeUpdate();
						break;
					case 3:
						keepgoing = false;
						break;

					default:
						Console.WriteLine("There is no such option!");
						break;
				}

            }
        }
    }


	
}

