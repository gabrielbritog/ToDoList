using Am4ToDo.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Am4ToDo.Domain.Models
{
    public class TaskToDo : BaseModel
    {
        public TaskState? TaskState { get; set; } = null;
    }
}
