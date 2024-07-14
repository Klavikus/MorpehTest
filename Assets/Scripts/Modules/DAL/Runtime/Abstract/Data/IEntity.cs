using System;

namespace Modules.DAL.Runtime.Abstract.Data
{
    public interface IEntity: ICloneable, IEquatable<IEntity>
    {
        string Id { get; }
    }
}