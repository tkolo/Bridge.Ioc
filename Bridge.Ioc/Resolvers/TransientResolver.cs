using System;

namespace Bridge.Ioc.Resolvers
{
    public class TransientResolver : IResolver
    {
        private readonly BridgeIoc _container;
        private readonly Type _targetType;

        public TransientResolver(BridgeIoc container, Type targetType)
        {
            _container = container;
            _targetType = targetType;
        }

        public object Resolve()
        {
            return ResolveHelper.ConstructObject(_container, _targetType);
        }
    }
}
