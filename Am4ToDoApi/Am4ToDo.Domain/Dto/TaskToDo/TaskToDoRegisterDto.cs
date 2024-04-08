using Am4ToDo.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Am4ToDo.Domain.Dto.TaskToDo
{
    public class TaskToDoRegisterDto
    {
        public string Name { get; set; }
        public TaskState TaskState { get; set; }
    }
}
