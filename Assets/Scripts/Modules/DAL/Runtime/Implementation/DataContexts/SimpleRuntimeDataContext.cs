using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Modules.DAL.Runtime.Abstract.Data;
using Modules.DAL.Runtime.Abstract.DataContexts;

namespace Modules.DAL.Runtime.Implementation.DataContexts
{
    public class SimpleRuntimeDataContext : BaseDataContext
    {
        protected IData Data;

        protected SimpleRuntimeDataContext(IData data) : base(data)
        {
            Data = data;
        }

        public IEnumerable<Type> ContainedTypes => Data.ContainedTypes;

        public override UniTask Load() =>
            default;

        public override UniTask Save() =>
            default;

        public List<IEntity> Set(Type type) =>
            Data.Set(type);

        public void Clear() =>
            Data.Clear();

        public void CopyFrom(IDataContext dataContext)
        {
            if (dataContext == null)
                throw new ArgumentNullException(nameof(dataContext));

            if (dataContext.ContainedTypes.Equals(ContainedTypes) == false)
                throw new ArgumentException(nameof(dataContext));

            foreach (Type containedType in ContainedTypes)
                Data.InjectWithReplace(dataContext.Set(containedType));
        }
    }
}