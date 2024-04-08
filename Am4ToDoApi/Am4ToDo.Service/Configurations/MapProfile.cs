using Am4ToDo.Domain.Dto.TaskToDo;
using Am4ToDo.Domain.Models;
using AutoMapper;

namespace Am4ToDo.Service.Configurations
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<TaskToDo, TaskToDoRegisterDto>().ReverseMap(); 
            CreateMap<TaskToDo, TaskToDoUpdateDto>().ReverseMap();
            CreateMap<TaskToDo, TaskToDoResponseDto>().ReverseMap();
            CreateMap<TaskToDoUpdateDto, TaskToDoResponseDto>().ReverseMap();

        }
    }
}
