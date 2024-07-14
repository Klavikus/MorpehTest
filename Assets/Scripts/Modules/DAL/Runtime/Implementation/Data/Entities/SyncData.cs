using Modules.DAL.Runtime.Abstract.Data;

namespace Modules.DAL.Runtime.Implementation.Data.Entities
{
    public class SyncData : IEntity
    {
        public uint SyncCount;

        public SyncData()
        {
            Id = nameof(SyncData);
        }

        public string Id { get; }

        public object Clone() =>
            new SyncData() {SyncCount = SyncCount};
        
        public bool Equals(IEntity other) =>
            Id == other?.Id;
    }
}