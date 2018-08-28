using Bridge.Ioc.Test.Classes;
using Bridge.Ioc.Test.Classes.Impl;
using Bridge.Test.NUnit;

namespace Bridge.Ioc.Test
{
    [TestFixture]
    public class SingleInstance
    {
        [Test(Name = "RegisterSingleInstance<ITest,TheTest>()")]
        public void GenericInterface()
        {
            var container = new BridgeIoc();
            
            container.RegisterSingleInstance<ITest,TheTest>();

            var first = container.Resolve<ITest>();
            var second = container.Resolve<ITest>();

            Assert.AreEqual(first, second);
            Assert.AreEqual(first.Id, second.Id);
        }
        
        [Test(Name = "RegisterSingleInstance(typeof(ITest),typeof(TheTest))")]
        public void NonGenericInterface()
        {
            var container = new BridgeIoc();
            
            container.RegisterSingleInstance(typeof(ITest),typeof(TheTest));

            var first = container.Resolve<ITest>();
            var second = container.Resolve<ITest>();
            
            Assert.AreEqual(first, second);
            Assert.AreEqual(first.Id, second.Id);
        }
        
        [Test(Name ="container.RegisterSingleInstance<TheTest>()")]
        public void GenericClass()
        {
            var container = new BridgeIoc();
            
            container.RegisterSingleInstance<TheTest>();

            var first = container.Resolve<TheTest>();
            var second = container.Resolve<TheTest>();
            
            Assert.AreEqual(first, second);
            Assert.AreEqual(first.Id, second.Id);
            
        }
        
        [Test(Name ="container.RegisterSingleInstance(typeof(TheTest))")]
        public void NonGenericClass()
        {
            var container = new BridgeIoc();
            
            container.RegisterSingleInstance(typeof(TheTest));

            var first = container.Resolve<TheTest>();
            var second = container.Resolve<TheTest>();
            
            Assert.AreEqual(first, second);
            Assert.AreEqual(first.Id, second.Id);
        }
        
        [Test(Name ="RegisterInstance(new TheTest())")]
        public void InstanceResolve()
        {
            var container = new BridgeIoc();
            
            container.RegisterSingleInstance<TheTest>(new TheTest());

            var first = container.Resolve<TheTest>();
            var second = container.Resolve<TheTest>();
            
            Assert.AreEqual(first, second);
            Assert.AreEqual(first.Id, second.Id);
        }
        
        [Test(Name ="RegisterFunc(()=> theTest)")]
        public void FuncResolve()
        {
            var container = new BridgeIoc();
            var theTest = new TheTest();
            container.RegisterFunc(()=> theTest);

            var first = container.Resolve<TheTest>();
            var second = container.Resolve<TheTest>();
            
            Assert.AreEqual(first, second);
            Assert.AreEqual(first.Id, second.Id);
        }
    }
}