using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadTEST
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<String> mainQueue = new Queue<string>();

            Producer prod1 = new Producer(1);
            Producer prod2 = new Producer(2);

            prod1.Start();
            prod2.Start();

            Thread.Sleep(1000);

            CPU cpu1 = new CPU(1);
            CPU cpu2 = new CPU(2);

          
           

            


          //Thread.Sleep(100);


            cpu1.Start();
            cpu2.Start();

            while (true)
            {
                Thread.Sleep(1000);
                if ((cpu1.isBusy) && (cpu2.isBusy))
                {
                    Console.WriteLine("Process is DELETED");
                    
                }
                if ((prod2.currentGenerationProcess != null) && (cpu2.isBusy))
                {
                    Console.WriteLine("Process is moved to QUEUE");
                    
                }
                if ((prod1.currentGenerationProcess != null) && (cpu1.currentProcess.generatedBy == 2))
                {
                    Console.WriteLine("Process is LOST");
                    
                }
            }
           

           
            //MyQ.instance = null;

            Console.ReadKey();
           
        }
    }
}
