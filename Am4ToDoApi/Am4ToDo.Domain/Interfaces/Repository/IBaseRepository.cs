using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Am4ToDo.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T>
    {
        public Task<T> GetById(int id);
        public Task<T> Register(T item);
        public Task<T> Update(T item);
        public Task<List<T>> GetAll();
        public Task<T> Delete(int id);
    }
}
