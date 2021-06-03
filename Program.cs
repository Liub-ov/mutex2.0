using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;

namespace ConsoleApp6
{
    public static class Program
    {
        const string mutex_id = "Global\\{a1b2c3d4e5}";

        public static int Main()
        {
            var threadNmae = Thread.CurrentThread.Name;
            Console.WriteLine($"Started by thread: {threadNmae}");
            using (var mutex = new Mutex(false, mutex_id))
            {
                    try
                    {
                        if (!mutex.WaitOne(TimeSpan.FromSeconds(5), false))
                        {
                            Console.WriteLine("Another instance of this program is running");

                            return -1;
                        }
                        else
                        {
                            var seconds = 5;
                            Console.WriteLine($"wait for {seconds} seconds");
                            Thread.Sleep(TimeSpan.FromSeconds(seconds));

                            return 0;
                        }
                    }
                    catch (AbandonedMutexException e)
                    {
                        Console.WriteLine($"Mutex '{mutex_id}' exception appeared:\n", e.Message);
                        throw e;
                    }
            }
        }
    }
}
