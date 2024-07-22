using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Runtime.Features.MiddlewarePipeline.Common
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct MiddlewarePipelineHolder : IComponent
    {
        public MiddlewarePipelineStorage Storage;
    }
}