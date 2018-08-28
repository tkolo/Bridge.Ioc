using Bridge.Ioc.Test.Classes;
using Bridge.Ioc.Test.Classes.Impl;
using Bridge.Test.NUnit;

namespace Bridge.Ioc.Test
{
    [TestFixture]
    public class TransientInstance
    {
        [Test(Name = "Register<ITest,TheTest>()")]
        public void GenericInterface()
        {
            var container = new BridgeIoc();
            
            container.Register<ITest,TheTest>();

            var first = container.Resolve<ITest>();
            var second = container.Resolve<ITest>();

            Assert.AreNotEqual(first, second);
            Assert.AreNotEqual(first.Id, second.Id);
        }
        
        [Test(Name = "Register(typeof(ITest),typeof(TheTest))")]
        public void NonGenericInterface()
        {
            var container = new BridgeIoc();
            
            container.Register(typeof(ITest),typeof(TheTest));

            var first = container.Resolve<ITest>();
            var second = container.Resolve<ITest>();
            
            Assert.AreNotEqual(first, second);
            Assert.AreNotEqual(first.Id, second.Id);
        }
        
        [Test(Name = "Register<TheTest>()")]
        public void GenericClass()
        {
            var container = new BridgeIoc();
            
            container.Register<TheTest>();

            var first = container.Resolve<TheTest>();
            var second = container.Resolve<TheTest>();
            
            Assert.AreNotEqual(first, second);
            Assert.AreNotEqual(first.Id, second.Id);
            
        }
        
        [Test(Name = "Register(typeof(TheTest))")]
        public void NonGenericClass()
        {
            var container = new BridgeIoc();
            
            container.Register(typeof(TheTest));

            var first = container.Resolve<TheTest>();
            var second = container.Resolve<TheTest>();
            
            Assert.AreNotEqual(first, second);
            Assert.AreNotEqual(first.Id, second.Id);
        }
        
        [Test(Name = "RegisterFunc(()=> new TheTest())")]
        public void FuncResolve()
        {
            var container = new BridgeIoc();
            container.RegisterFunc(()=> new TheTest());

            var first = container.Resolve<TheTest>();
            var second = container.Resolve<TheTest>();
            
            Assert.AreNotEqual(first, second);
            Assert.AreNotEqual(first.Id, second.Id);
        }
    }
}