﻿using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Modules.DAL.Runtime.Abstract.Data;
using Modules.DAL.Runtime.Abstract.DataContexts;

namespace Modules.DAL.Runtime.Implementation.DataContexts
{
    [Serializable]
    public abstract class BaseDataContext : IDataContext
    {
        protected IData Data;

        protected BaseDataContext(IData data)
        {
            Data = data;
        }

        public IEnumerable<Type> ContainedTypes => Data.ContainedTypes;

        public abstract UniTask Load();
        public abstract UniTask Save();

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