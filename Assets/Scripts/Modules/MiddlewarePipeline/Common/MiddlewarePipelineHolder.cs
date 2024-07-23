using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Modules.MiddlewarePipeline.Common
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct MiddlewarePipelineHolder : IComponent
    {
        public MiddlewarePipelineStorage Storage;
    }
}