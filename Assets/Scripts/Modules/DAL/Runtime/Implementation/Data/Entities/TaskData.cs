using System;
using Modules.DAL.Runtime.Abstract.Data;

namespace Modules.DAL.Runtime.Implementation.Data.Entities
{
    public class TaskData : IEntity
    {
        public DateTime TargetDate;
        public DateTime CompletionDate;
        public string Name;
        public string Description;
        public bool IsCompleted;

        public TaskData(string id) =>
            Id = id;

        public string Id { get; }

        public object Clone()
        {
            return new TaskData(Id)
            {
                TargetDate = TargetDate,
                CompletionDate = CompletionDate,
                Name = Name,
                Description = Description,
                IsCompleted = IsCompleted
            };
        }
        
        public bool Equals(IEntity other) =>
            Id == other?.Id;
    }
}