using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Dapper;
using Infrastructure.Data;
using System.Data;
using System.Linq;

namespace Infrastructure.Repositories
{
	public class DepartmentRepository:IRepository<Departments>

	{
        private readonly DapperDBContext _dbContext;
		public DepartmentRepository()
		{
            _dbContext = new DapperDBContext();

        }

        public IEnumerable<Departments> GetAll()
        {
            using(IDbConnection conn = _dbContext.GetConnectition())
            {
                return conn.Query<Departments>("Select Id, Department_Name, Location From Departments");
            }
        }
        public int Insert(Departments obj)
        {
            using (IDbConnection conn = _dbContext.GetConnectition())
            {
                return conn.Execute("Insert Into Departments Values(@Department_Name, @Location)", obj);
            }
        }
        public int Update(Departments obj)
        {
            using (IDbConnection conn = _dbContext.GetConnectition())
            {
                return conn.Execute("Update Departments Set Department_Name = @Department_Name, Location=@Location Where Id=@Id", obj);

            }
        }
        public Departments GetById(int id)
        {
            using (IDbConnection conn = _dbContext.GetConnectition())
            {
                return conn.QuerySingleOrDefault<Departments>("Select Id, Department_Name, Location From Departments Where Id=@Id", new { Id = id });
            }
        }
        public int DeleteById(int id)
        {
            using (IDbConnection conn = _dbContext.GetConnectition())
            {
                return conn.Execute("Delete From Departments Where Id=@Id", new { Id = id });
            }
        }

    }
}

