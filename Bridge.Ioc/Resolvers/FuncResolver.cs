using System;

namespace Bridge.Ioc.Resolvers
{
    public class FuncResolver : IResolver
    {
        public Func<object> Resolver { get; set; }

        public FuncResolver(Func<object> resolveFunc)
        {
            Resolver = resolveFunc;
        }

        public object Resolve()
        {
            return Resolver();
        }
    }
}