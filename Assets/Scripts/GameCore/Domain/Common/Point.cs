using System;
using UnityEngine;

namespace GameCore.Domain.Common
{
    [Serializable]
    public struct Point
    {
        public Vector3 Position;
        public Vector3 Rotation;
    }
}