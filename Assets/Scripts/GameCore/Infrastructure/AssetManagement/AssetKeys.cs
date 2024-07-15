using System;
using System.Collections.Generic;
using GameCore.Controllers.Behaviours;

namespace GameCore.Infrastructure.AssetManagement
{
    public class AssetKeys
    {
        public static readonly Dictionary<Type, string> KeyByType = new()
        {
            [typeof(ConfigurationContainer)] = "ConfigurationContainer",
            [typeof(Curtain)] = "Curtain",
        };
    }
}