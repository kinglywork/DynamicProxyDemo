using System;

namespace DynamicProxyDemo
{
    /// <summary>
    /// </summary>
    public class TestBed
    {
        /// <summary>
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            TestStaticProxy();

            TestDynamicProxy();

            Console.ReadKey();
        }

        private static void TestStaticProxy()
        {
            var handler = new SecurityInterceptor(new TargetClass());
            var proxy = new TargetClassStaticProxy(handler, typeof(TargetClass));
            proxy.TestFunctionOne();
            proxy.TestFunctionTwo(new object(), new object());
        }

        private static void TestDynamicProxy()
        {
            var proxy = (ITest) SecurityInterceptor.Inject(new TargetClass());
            proxy.TestFunctionOne();
            proxy.TestFunctionTwo(new object(), new object());
        }
    }

    public interface ITest
    {
        void TestFunctionOne();
        object TestFunctionTwo(object a, object b);
    }

    public class TargetClass : ITest
    {
        public void TestFunctionOne()
        {
            Console.WriteLine("In TargetClass.TestFunctionOne()");
        }

        public object TestFunctionTwo(object a, object b)
        {
            Console.WriteLine("In TargetClass.TestFunctionTwo( Object a, Object b )");
            return null;
        }
    }

    public class TargetClassStaticProxy : ITest
    {
        private readonly IInvocationHandler _handler;
        private readonly Type _targetType;

        public TargetClassStaticProxy(IInvocationHandler handler, Type targetType)
        {
            _handler = handler;
            _targetType = targetType;
        }

        public void TestFunctionOne()
        {
            _handler.Invoke(this, _targetType.GetMethod("TestFunctionOne"), new object[] { });
        }

        public object TestFunctionTwo(object a, object b)
        {
            return _handler.Invoke(this, _targetType.GetMethod("TestFunctionTwo"), new object[] {a, b});
        }
    }
}