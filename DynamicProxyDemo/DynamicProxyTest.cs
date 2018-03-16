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
            var test = (ITest) SecurityInterceptor.Inject(new TestImpl());
            test.TestFunctionOne();
            test.TestFunctionTwo(new object(), new object());

            Console.ReadKey();
        }
    }

    public interface ITest
    {
        void TestFunctionOne();
        object TestFunctionTwo(object a, object b);
    }

    public class TestImpl : ITest
    {
        public void TestFunctionOne()
        {
            Console.WriteLine("In TestImpl.TestFunctionOne()");
        }

        public object TestFunctionTwo(object a, object b)
        {
            Console.WriteLine("In TestImpl.TestFunctionTwo( Object a, Object b )");
            return null;
        }
    }
}