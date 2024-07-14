using System;
using System.Collections.Generic;
using Modules.DAL.Runtime.Abstract.Data;

namespace Modules.DAL.Runtime.Implementation.Serialization
{
    public struct GameDataDto
    {
        public readonly Dictionary<Type, List<IEntity>> Data;

        public static GameDataDto FromGameData(IData data)
        {
            Dictionary<Type, List<IEntity>> result = new Dictionary<Type, List<IEntity>>();

            foreach (Type containedType in data.ContainedTypes)
                result.Add(containedType, data.Set(containedType));

            return new GameDataDto(result);
        }

        public GameDataDto(Dictionary<Type, List<IEntity>> data)
        {
            Data = data;
        }
    }
}