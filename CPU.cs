using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadTEST
{
    class CPU
    {
        public Process currentProcess;
        private object threadLock = new object();

        AutoResetEvent CPUarEvent = new AutoResetEvent(true);

        //public AutoResetEvent arEvent = new AutoResetEvent(true);

        private int id;

        public bool isBusy = false;
        private Thread mainThread;

        public CPU() { }

        public CPU(int id)
        {
            this.id = id;
            mainThread = new Thread(Consume);
            mainThread.Name = "CPU_" + id;
        }

        public void Start()
        {      
            
            mainThread.Start();
            
        }
        void Consume()
        {

            while (true)
            {
                CPUarEvent.WaitOne();
                
            
                   
                    
                    if (MyQ.Instance.Count == 0)
                    {
                        //Console.WriteLine("CPU " + id + "");
                        //arEvent.WaitOne();
                        Thread.Sleep(1000);
                        Console.WriteLine("THERE'S NO DATA TO PROCEED FOR CPU# " + id);
                        CPUarEvent.WaitOne();
                        
                        
                       
                    }
                        
                    if (MyQ.Instance.Count != 0)
                    {
                        Process process = new Process();
                        

                        process = MyQ.Instance.Dequeue();
                        currentProcess = process;

                        
                       
                        isBusy = true;
                        Console.WriteLine("CPU" + id + " PROCESS " + process.message + " IS RUNNING");
                        //if ((process.generatedBy == 2) && (id == 1))
                        //{
                        //    Console.WriteLine("PROCESS IS LOST");
                        //}
                        //if ((process.generatedBy == 2) && (id == 2))
                        //{
                        //    Console.WriteLine("PROCESS IS ADDED TO QUEU");
                        //}
                        Random rnd = new Random();
                        Thread.Sleep(rnd.Next(1000));
                        Console.WriteLine("CPU" + id + " PROCESS" + process.message + " FINISHED");
                        isBusy = false;

                        CPUarEvent.Set();
                        //Thread.Sleep(1000);
                    }
                    
                }
               
            }
            
        }
    }
