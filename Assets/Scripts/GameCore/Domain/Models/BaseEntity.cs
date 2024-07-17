using System;
using Modules.DAL.Runtime.Abstract.Data;

namespace GameCore.Domain.Models
{
    [Serializable]
    public abstract class BaseEntity : IEntity
    {
        private string _id;

        protected BaseEntity(string id) =>
            _id = id;

        public string Id => _id;

        public object Clone() =>
            MemberwiseClone();

        public bool Equals(IEntity other) =>
            Id == other?.Id;
    }
}