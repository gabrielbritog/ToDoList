using Am4ToDo.Domain.Dto.TaskToDo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Am4ToDo.Domain.Interfaces.Service
{
    public interface ITaskToDoService
    {
        public Task<TaskToDoResponseDto> GetById(int id);
        public Task<TaskToDoResponseDto> Update(TaskToDoUpdateDto item);
        public Task<TaskToDoResponseDto> Register(TaskToDoRegisterDto item);
        public Task<List<TaskToDoResponseDto>> GetAll();
        public Task<TaskToDoResponseDto> Delete(int id);
    }
}
