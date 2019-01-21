﻿using System;
using System.Linq;
using Prism.Ioc;
using Unity;
using Unity.Resolution;

namespace Prism.Unity
{
    public class UnityContainerExtension : IContainerExtension<IUnityContainer>
    {
        public IUnityContainer Instance { get; }

        public UnityContainerExtension(IUnityContainer container) => Instance = container;

        public void FinalizeExtension() { }

        public void RegisterInstance(Type type, object instance)
        {
            Instance.RegisterInstance(type, instance);
        }

        public void RegisterInstance(Type type, object instance, string name)
        {
            Instance.RegisterInstance(type, name, instance);
        }

        public void RegisterSingleton(Type from, Type to)
        {
            Instance.RegisterSingleton(from, to);
        }

        public void RegisterSingleton(Type from, Type to, string name)
        {
            Instance.RegisterSingleton(from, to, name);
        }

        public void Register(Type from, Type to)
        {
            Instance.RegisterType(from, to);
        }

        public void Register(Type from, Type to, string name)
        {
            Instance.RegisterType(from, to, name);
        }

        public object Resolve(Type type)
        {
            return Instance.Resolve(type);
        }

        public object Resolve(Type type, string name)
        {
            return Instance.Resolve(type, name);
        }

        public object Resolve(Type type, params (Type Type, object Instance)[] parameters)
        {
            var overrides = parameters.Select(p => new DependencyOverride(p.Type, p.Instance)).ToArray();
            return Instance.Resolve(type, overrides);
        }

        public bool IsRegistered(Type type)
        {
            return Instance.IsRegistered(type);
        }

        public bool IsRegistered(Type type, string name)
        {
            return Instance.IsRegistered(type, name);
        }
    }
}
