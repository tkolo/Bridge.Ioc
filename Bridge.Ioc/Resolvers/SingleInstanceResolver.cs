using System;

namespace Bridge.Ioc.Resolvers
{
    public class SingleInstanceResolver : IResolver
    {
        private readonly BridgeIoc _container;
        private readonly Type _targetType;
        private object _instance;

        
        public SingleInstanceResolver(object instance)
        {
            _instance = instance;
        }
        
        public SingleInstanceResolver(BridgeIoc container, Type targetType)
        {
            _container = container;
            _targetType = targetType;
        }

        public object Resolve()
        {
            return _instance ?? (_instance = ResolveHelper.ConstructObject(_container, _targetType));
        }
    }
}