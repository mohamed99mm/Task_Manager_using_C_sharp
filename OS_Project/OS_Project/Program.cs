using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using static System.Console;
using System.Threading;
namespace OS_Project
{
    class Program
    {
         
        private static DateTime curTime;
        /*
         we gave the id of the process we want to kill to the function and this function kill it
          */
        public static void Kill_Process()
        {
            try
            {
                WriteLine("enter process id to terminate");
                int choice = int.Parse(Console.ReadLine());
                Process myProcess1 = new Process();
                myProcess1 = Process.GetProcessById(choice);
                myProcess1.Kill();
                Console.WriteLine(myProcess1.HasExited);
                Menu();
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Wrong id try Again");
                Kill_Process();
            }
        }
        /*
         we gave this function the id of the process we want to change periority 
         and inside it there is a menu of the perioritites we choose one of the them 
         like normal and the peririty of the function will be changed to normal
        */
        public static void Change_Periority(int choice2)
        {

            Process myProcess2 = new Process();
            myProcess2 = Process.GetProcessById(choice2);
            Console.WriteLine("Enter 1 for High");
            Console.WriteLine("Enter 2 for  Normal");
            Console.WriteLine("Enter 3  for BelowNormal");
            Console.WriteLine("Enter 4 for  RealTime");
            Console.WriteLine("Enter 5 for  AboveNormal");
            Console.WriteLine("Enter 6  for Idle");
            Console.WriteLine("Enter 7 to Return to the Menu Again");
            Console.WriteLine(" Enter 8 to exit the Program");
            int per = int.Parse(Console.ReadLine());
            switch (per)
            {
                case 1:
                myProcess2.PriorityClass = ProcessPriorityClass.High;
                WriteLine(myProcess2.PriorityClass);
                Thread.Sleep(1000);
                    Menu();
                    break;
                case 2:
                    myProcess2.PriorityClass = ProcessPriorityClass.Normal;
                    WriteLine(myProcess2.PriorityClass);
                    Thread.Sleep(1000);
                    Menu();
                    break;
                case 3:
                    myProcess2.PriorityClass = ProcessPriorityClass.BelowNormal;
                    WriteLine(myProcess2.PriorityClass);
                    Thread.Sleep(1000);
                    Menu();
                    break;
                case 4:
                    myProcess2.PriorityClass = ProcessPriorityClass.RealTime;
                    WriteLine(myProcess2.PriorityClass);
                    Thread.Sleep(1000);
                    Menu();
                    break;
                case 5:
                    myProcess2.PriorityClass = ProcessPriorityClass.AboveNormal;
                    WriteLine(myProcess2.PriorityClass);
                    Thread.Sleep(1000);
                    Menu();
                    break;
                case 6:
                    myProcess2.PriorityClass = ProcessPriorityClass.Idle;
                    WriteLine(myProcess2.PriorityClass);
                    Thread.Sleep(1000);
                    Menu();
                    break;
                case 7:
                    Menu();
                    break;
                   case 8:
                    break;
                       
            }
        }
        /* menu of the functions contained in this project */
         public static void Menu()
        {
       
            Console.WriteLine("                 Hello User                  ");
            Console.WriteLine(" Enter 1  to to show the  Processes List ");
            Console.WriteLine("Enter 2 to  kill running  Process");
            Console.WriteLine("Enter  3 to change the periority of Process" );
            Console.WriteLine("Enter any other number to End the Program");
            int n = int.Parse(Console.ReadLine());

             switch(n)
            {
                case 1:
                    BindToRunningProcesses();
                    break;
                case 2:
                    Kill_Process();
                    break;
                case 3:
                    WriteLine("enter process id to change periority");
                    int b = int.Parse(ReadLine());
                    Change_Periority(b);
                    break;
                default:
                    break;

            }
        }
        /* this function shows all processes running of the task maneger and the id and 
          CPU consumption of each process and the change of CPU consumption of each 
          process over time 
          */
        public static void BindToRunningProcesses()
        {
             
          Process[] localAll = Process.GetProcesses();
            Console.WriteLine("Press Any key to stop and Return to Menu");
            Thread.Sleep(300);

            while (!KeyAvailable)
            {
                Thread.Sleep(500);
                foreach (Process proc in localAll)
                {
                    try
                    {
                        /* this statment check if the process is still running or has exited */
                        if (proc.Id != 0 || !proc.HasExited)
                        {
                            curTime = DateTime.Now;
                            double CPUUsage = (proc.TotalProcessorTime.TotalMilliseconds
                                / curTime.Subtract(proc.StartTime).TotalMilliseconds
                                / Convert.ToDouble(Environment.ProcessorCount));
                            Console.WriteLine(" Process Name: {0}  :: Process ID : {1} CpuUsage {2:0.000000}%", proc.ProcessName, proc.Id, CPUUsage * 100);

                        }

                    }
                    catch (Exception s) { }

                }
            }
            
            Menu();
        }
        static void Main(string[] args)
        {
            Menu();

        }
    }
}
