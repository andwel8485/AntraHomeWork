using System;
using System.Collections;

namespace ApplicationCore.Contracts.Repositories
{
	public interface IRepository<T> where T:class
	{
        public IEnumerable<T> GetAll();
		public int Insert(T obj);
		public int Update(T obj);
        public int DeleteById(int id);
        public T GetById(int id);

    }
	

}

