using Am4ToDo.Domain.Interfaces.Repository;
using Am4ToDo.Domain.Models;
using Am4ToDo.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using System.Numerics;
using System.Threading.Tasks;

namespace Am4ToDo.Infra.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel, new()
    {
        protected readonly Am4ToDoContext _context;
        protected readonly DbSet<T> _dbSet;
        public BaseRepository(Am4ToDoContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> Delete(int id)
        {
            try
            {
                
                var ToRemove = await _dbSet.FindAsync(id);
                if (ToRemove != null)
                {
                    _dbSet.Remove(ToRemove);
                    await _context.SaveChangesAsync();
                    return ToRemove;
                }
                else
                {
                    throw new Exception("Cliente não encontrado.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<T>> GetAll()
        {
            try
            {
                var response = await _dbSet.ToListAsync();
                return response;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<T> GetById(int id)
        {
            try
            {
                return await _dbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<T> Register(T item)
        {
            try
            {
                await _dbSet.AddAsync(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro durante o registro do cliente: " + e.Message);
            }
        }

        public async Task<T> Update(T item)
        {
            try
            {

                var existingEntity = await _dbSet.FindAsync(item.Id);
                if (existingEntity == null)
                {
                    throw new Exception("A entidade não foi localizada.");
                }

                _context.Entry(existingEntity).CurrentValues.SetValues(item);

                _dbSet.Update(existingEntity);
                await _context.SaveChangesAsync();

                return existingEntity;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
