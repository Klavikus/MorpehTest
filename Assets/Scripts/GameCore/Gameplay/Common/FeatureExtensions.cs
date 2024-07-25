using Scellecs.Morpeh;
using VContainer;

namespace GameCore.Gameplay.Common
{
    public static class FeatureExtensions
    {
        public static void AddFeature<T>(this World world, IObjectResolver objectResolver)
            where T : Feature, new() =>
            new T().Initialize(world, objectResolver);
    }
}