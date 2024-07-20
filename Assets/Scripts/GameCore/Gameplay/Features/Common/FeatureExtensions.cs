using Scellecs.Morpeh;
using VContainer;

namespace GameCore.Gameplay.Features.Common
{
    public static class FeatureExtensions
    {
        public static void AddFeature<T>(this World world, IObjectResolver objectResolver)
            where T : Feature =>
            objectResolver.Resolve<T>().Initialize(world);
    }
}