using System;
using System.Linq;

namespace Bridge.Ioc.Resolvers
{
    public static class ResolveHelper
    {
        public static object ConstructObject(BridgeIoc container, Type type)
        {
            var constructor = type.GetConstructors().Single();
            var constructorParameters = constructor.GetParameters();
            var parameters = new object[constructorParameters.Length];
            for (var i = 0; i < constructorParameters.Length; i++)
            {
                parameters[i] = container.Resolve(constructorParameters[i].ParameterType);
            }

            return constructor.Invoke(parameters.ToArray());
        }
    }
}
