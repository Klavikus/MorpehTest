using System;
using Cysharp.Threading.Tasks;

namespace GameCore.Controllers.Implementation.Dto
{
    public struct LoadingInfo
    {
        public Func<IProgress<float>, UniTask> AsyncOperation;
        public string Description;
        public float Weight;
    }
}