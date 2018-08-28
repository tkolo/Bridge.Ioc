using System;
using System.Collections.Generic;
using Bridge.Ioc.Resolvers;

namespace Bridge.Ioc
{
    public class BridgeIoc
    {
        private readonly Dictionary<Type, IResolver> _resolvers = new Dictionary<Type, IResolver>();

        #region Registration

        public void Register(Type type, IResolver resolver)
        {
            CheckAlreadyAdded(type);
            _resolvers.Add(type, resolver);
        }

        public void Register(Type type, Type impl)
        {
            CheckAlreadyAdded(type);

            var resolver = new TransientResolver(this, impl);
            _resolvers.Add(type, resolver);
        }

        public void Register<TType, TImplementation>() where TImplementation : class, TType
        {
            Register(typeof(TType), typeof(TImplementation));
        }

        public void Register(Type type)
        {
            Register(type, type);
        }

        public void Register<TType>() where TType : class
        {
            Register(typeof(TType));
        }

        public void RegisterSingleInstance(Type type, Type impl)
        {
            CheckAlreadyAdded(type);

            var resolver = new SingleInstanceResolver(this, impl);
            _resolvers.Add(type, resolver);
        }

        public void RegisterSingleInstance(Type type, object instance)
        {
            CheckAlreadyAdded(type);
            
            var resolver = new SingleInstanceResolver(instance);
            _resolvers.Add(type, resolver);
        }

        public void RegisterSingleInstance<TType, TImplementation>() where TImplementation : class, TType
        {
            RegisterSingleInstance(typeof(TType), typeof(TImplementation));
        }
        
        public void RegisterSingleInstance<TType>(object instance)
        {
            RegisterSingleInstance(typeof(TType), instance);
        }

        public void RegisterSingleInstance(Type type)
        {
            RegisterSingleInstance(type, type);
        }

        public void RegisterSingleInstance<TType>() where TType : class
        {
            RegisterSingleInstance(typeof(TType));
        }

        public void RegisterFunc<TType>(Func<TType> func)
        {
            CheckAlreadyAdded<TType>();

            var resolver = new FuncResolver(func.As<Func<object>>());
            _resolvers.Add(typeof(TType), resolver);
        }
        #endregion


        #region Resolve
        public TType Resolve<TType>() where TType : class
        {
            CheckNotRegistered<TType>();

            var resolver = _resolvers[typeof(TType)];
            return (TType)resolver.Resolve();
        }

        public object Resolve(Type type)
        {
            CheckNotRegistered(type);

            var resolver = _resolvers[type];
            return resolver.Resolve();
        }
        #endregion


        #region Private

        private void CheckAlreadyAdded(Type type)
        {
            if (_resolvers.ContainsKey(type))
                throw new InvalidOperationException($"{type.FullName} is already registered!");
        }

        private void CheckAlreadyAdded<TType>()
        {
            CheckAlreadyAdded(typeof(TType));
        }

        private void CheckNotRegistered(Type type)
        {
            if (!_resolvers.ContainsKey(type))
                throw new InvalidOperationException($"Cannot resolve {type.FullName}, it's not registered!");
        }

        private void CheckNotRegistered<TType>()
        {
            CheckNotRegistered(typeof(TType));
        }

        #endregion
    }
}