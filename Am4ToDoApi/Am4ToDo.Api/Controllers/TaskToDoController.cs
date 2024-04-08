using Am4ToDo.Domain.Dto.TaskToDo;
using Am4ToDo.Domain.Interfaces.Service;
using Am4ToDo.Domain.ViewModels;
using Am4ToDo.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace Am4ToDo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskToDoController : ControllerBase
    {
        private readonly ITaskToDoService _taskToDoService;

        public TaskToDoController(ITaskToDoService taskToDoService)
        {
            _taskToDoService = taskToDoService;
        }
        [HttpPost]
        public async Task<ActionResult<ResponseViewModel<TaskToDoResponseDto>>> Register([FromBody] TaskToDoRegisterDto taskToDo)
        {
            try
            {
                return Ok(new ResponseViewModel(true, "Sucesso", await _taskToDoService.Register(taskToDo)));
            }
            catch (Exception e)
            {

                return BadRequest(new ResponseViewModel(false, e.Message, null));
            }
        }
        [HttpGet]
        public async Task<ActionResult<ResponseViewModel<List<TaskToDoResponseDto>>>> Get(int? id)
        {
            try
            {
                return Ok(new ResponseViewModel(true, "Sucesso", id != null ? await _taskToDoService.GetById(id.Value) : await _taskToDoService.GetAll()));
            }
            catch (Exception e)
            {

                return BadRequest(new ResponseViewModel(false, e.Message, null));
            }
        }
        [HttpPut]
        public async Task<ActionResult<ResponseViewModel<TaskToDoResponseDto>>> Update(TaskToDoUpdateDto taskToDo)
        {
            try
            {
                return Ok(new ResponseViewModel(true, "Sucesso", await _taskToDoService.Update(taskToDo)));
            }
            catch (Exception e)
            {

                return BadRequest(new ResponseViewModel(false, e.Message, null));
            }
        }
        [HttpDelete]
        public async Task<ActionResult<ResponseViewModel<TaskToDoResponseDto>>> Delete(int id)
        {
            try
            {               
                return Ok(new ResponseViewModel(true, "Sucesso", await _taskToDoService.Delete(id)));
            }
            catch (Exception e)
            {

                return BadRequest(new ResponseViewModel(false, e.Message, null));
            }
        }
    }
}
