using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ConsoleApp6;
using System.Threading;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestSeveralThreads()
        {
            int value = 1;
            var thread1 = new Thread(() => value = Program.Main());
            thread1.Name = "Thread 1";
            var thread2 = new Thread(() => value = Program.Main());
            thread2.Name = "Thread 2";
            var thread3 = new Thread(() => value = Program.Main());
            thread3.Name = "Thread 3";
            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread1.Join();
            thread2.Join();
            thread3.Join();

            Console.WriteLine($"Result: {value}");

            Assert.AreEqual(-1, value);
        }

        [TestMethod]
        public void TestSingleThread()
        {
            int value = 1;
            var thread1 = new Thread(() => value = Program.Main());
            thread1.Name = "Thread 1";
            thread1.Start();
            thread1.Join();

            Console.WriteLine($"Result: {value}");

            Assert.AreEqual(0, value);
        }
    }
}
