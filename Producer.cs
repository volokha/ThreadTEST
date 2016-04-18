using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadTEST
{
    class Producer
    {
        public static AutoResetEvent producerArEvent = new AutoResetEvent(true);
        private Thread mainThread;

        public Process currentGenerationProcess; 

        private int id;

        static int taskNumber = 0;

        public Producer()
        {

        }
        public Producer(int id)
        {
            this.id = id;
        }

       public void Start()
        {
            mainThread = new Thread(Generate);
            mainThread.Start();
        }
        void Generate()
        {
            while (true)
            {
                
                    for (int i = 0; i < 10; i++)
                    {
                        producerArEvent.WaitOne();
                        producerArEvent.Reset();
                        Process process = new Process(id);
                        string s = "TASK" + taskNumber + "CREATED BY GENERATOR " + id;
                        
                        process.message = s;

                        currentGenerationProcess = process;
                        Thread.Sleep(100);

                        MyQ.Instance.Enqueue(process);
                        currentGenerationProcess = null;
                        
                        Console.WriteLine("GENERATOR " + id + " GENERATED " + taskNumber);
                        Thread.Sleep(100);
                        taskNumber++;
                        producerArEvent.Set();
                        Thread.Sleep(100);
                    }

                    return;
            }
            
        }
    }
}
