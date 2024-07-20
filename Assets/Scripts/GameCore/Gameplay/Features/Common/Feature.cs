using System.Collections.Generic;
using Scellecs.Morpeh;

namespace GameCore.Gameplay.Features.Common
{
    public abstract class Feature
    {
        private readonly List<IInitializer> _initializers = new();
        private readonly List<ISystem> _systems = new();
        private readonly List<ICleanupSystem> _cleanupSystems = new();

        protected void AddInitializer(IInitializer initializer) =>
            _initializers.Add(initializer);

        protected void AddSystem(ISystem system) =>
            _systems.Add(system);

        protected void AddCleanupSystem(ICleanupSystem cleanupSystem) =>
            _cleanupSystems.Add(cleanupSystem);

        public void Initialize(World world)
        {
            SystemsGroup systemsGroup = world.CreateSystemsGroup();

            foreach (IInitializer initializer in _initializers)
                systemsGroup.AddInitializer(initializer);

            foreach (ISystem system in _systems)
                systemsGroup.AddSystem(system);

            foreach (ICleanupSystem cleanupSystem in _cleanupSystems)
                systemsGroup.AddSystem(cleanupSystem);

            world.AddPluginSystemsGroup(systemsGroup);
        }
    }
}