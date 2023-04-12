using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Dapper;
using System.Data;

namespace Infrastructure.Repositories
{
	public class EmployeeRepository:IRepository<Employees>
	{
        private readonly DapperDBContext _DBContext;
		public EmployeeRepository()
		{
            _DBContext = new DapperDBContext();
		}

        public IEnumerable<Employees> GetAll()
        {
            using(IDbConnection conn = _DBContext.GetConnectition())
            {
                return conn.Query<Employees>("Select Id, FirstName, LastName, DepartmentId, Salary From Employees");
            }
        }
        public int Insert(Employees obj)
        {
            using (IDbConnection conn = _DBContext.GetConnectition())
            {
                return conn.Execute("Insert Into Employees Values(@FirstName, @LastName, @Salary, @DepartmentId)", obj);
            }
        }
        public int Update(Employees obj)
        {
            using (IDbConnection conn = _DBContext.GetConnectition())
            {
                return conn.Execute("Update Employees Set FirstName=@FirstName, LastName=@LastName, " +
                                    "DepartmentId=@DepartmentId, Salary=@Salary Where Id=@Id", obj);

            }
        }
        public int DeleteById(int id)
        {
            using (IDbConnection conn = _DBContext.GetConnectition())
            {
                return conn.Execute("Delete From Employees Where Id=@Id", new { Id = id });
            }
        }
        public Employees GetById(int id)
        {
            using (IDbConnection conn = _DBContext.GetConnectition())
            {
                return conn.QuerySingleOrDefault<Employees>("Select Id, FirstName, LastName,Salary, DepartmentId From Employees Where Id=@Id", new { Id = id });
            }
        }
    }
}

