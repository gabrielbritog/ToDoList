using Am4ToDo.Domain.Models;

namespace Am4ToDo.Domain.Interfaces.Repository
{
    public interface ITaskToDoRepository
    {
        public Task<TaskToDo> GetById(int id);
        public Task<TaskToDo> Update(TaskToDo item);
        public Task<TaskToDo> Register(TaskToDo item);
        public Task<List<TaskToDo>> GetAll();
        public Task<TaskToDo> Delete(int id);
    }
}
