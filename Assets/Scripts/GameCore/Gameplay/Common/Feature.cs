using System.Collections.Generic;
using Scellecs.Morpeh;
using VContainer;

namespace GameCore.Gameplay.Common
{
    public abstract class Feature
    {
        private readonly List<IInitializer> _initializers = new();
        private readonly List<ISystem> _systems = new();
        private readonly List<ICleanupSystem> _cleanupSystems = new();
        private readonly HashSet<IInjectable> _injectables = new();

        public void Initialize(World world, IObjectResolver objectResolver)
        {
            SystemsGroup systemsGroup = world.CreateSystemsGroup();

            foreach (IInjectable injectable in _injectables)
            {
                injectable.Inject(objectResolver);
            }

            foreach (IInitializer initializer in _initializers)
                systemsGroup.AddInitializer(initializer);

            foreach (ISystem system in _systems)
                systemsGroup.AddSystem(system);

            foreach (ICleanupSystem cleanupSystem in _cleanupSystems)
                systemsGroup.AddSystem(cleanupSystem);

            world.AddPluginSystemsGroup(systemsGroup);
        }

        protected void AddInitializer<T>()
            where T : IInitializer, new()
        {
            T initializer = new();
            CheckForInjectable(initializer);
            _initializers.Add(initializer);
        }

        protected void AddSystem<T>()
            where T : ISystem, new()
        {
            T system = new();
            CheckForInjectable(system);
            _systems.Add(system);
        }

        protected void AddCleanupSystem<T>()
            where T : ICleanupSystem, new()

        {
            T cleanupSystem = new();
            CheckForInjectable(cleanupSystem);
            _cleanupSystems.Add(cleanupSystem);
        }

        private void CheckForInjectable(object @object)
        {
            if (@object is IInjectable injectable)
                _injectables.Add(injectable);
        }
    }
}