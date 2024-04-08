using Am4ToDo.Domain.Interfaces.Repository;
using Am4ToDo.Domain.Models;
using Am4ToDo.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Am4ToDo.Infra.Repository
{
    public class TaskToDoRepository : BaseRepository<TaskToDo>, ITaskToDoRepository
    {
        protected readonly Am4ToDoContext _context;
        protected readonly DbSet<TaskToDo> _dbSet;
        public TaskToDoRepository(Am4ToDoContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<TaskToDo>();
        }
        
    }
}
