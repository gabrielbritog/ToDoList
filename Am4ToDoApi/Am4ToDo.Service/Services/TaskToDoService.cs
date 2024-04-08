using Am4ToDo.Domain.Dto.TaskToDo;
using Am4ToDo.Domain.Interfaces.Repository;
using Am4ToDo.Domain.Interfaces.Service;
using Am4ToDo.Domain.Models;
using Am4ToDo.Service.Global;
using AutoMapper;

namespace Am4ToDo.Service.Services
{
    public class TaskToDoService : Functions, ITaskToDoService
    {
        private readonly ITaskToDoRepository _repository;
        private readonly IMapper _mapper;
        public TaskToDoService(ITaskToDoRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<TaskToDoResponseDto> Delete(int id) => _mapper.Map<TaskToDoResponseDto>(await _repository.Delete(id));
        public async Task<List<TaskToDoResponseDto>> GetAll() => _mapper.Map<List<TaskToDoResponseDto>>(await _repository.GetAll());
        public async Task<TaskToDoResponseDto> GetById(int id) => _mapper.Map<TaskToDoResponseDto>(await _repository.GetById(id));
        public async Task<TaskToDoResponseDto> Register(TaskToDoRegisterDto item) 
        {
            try
            {
                var taskToDo = _mapper.Map<TaskToDo>(item);
                var response = await _repository.Register(taskToDo);
                return _mapper.Map<TaskToDoResponseDto>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao registrar uma tarefa.", ex);
            }
        }
        public async Task<TaskToDoResponseDto> Update(TaskToDoUpdateDto item)
        {
            try
            {
                var taskDb = _mapper.Map<TaskToDo>(await GetById(item.id));
                var itemConverted = _mapper.Map<TaskToDo>(item);
                if (taskDb == null) {
                    throw new Exception("A tarefa não foi localizada.");
                }                         
                PersistData(itemConverted, taskDb);
                var taskToUpdate = _mapper.Map<TaskToDo>(taskDb);
                var response = _mapper.Map<TaskToDoResponseDto>(await _repository.Update(taskToUpdate));

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao atualizar uma tarefa.", ex);
            }
        }
    }
}
