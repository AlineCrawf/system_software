using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PriorityQueue
{
    enum ProcessStatus { ready, activ};
    class Process: IComparable
    {
        string name;
        int ID = 0;
        int burstTime;
        int serviseTime;
        int admissionTime;
        int waitingTime;
        int workTime;
        int toQueue;
        ProcessStatus status;


        public int SetServiseTime { set => serviseTime = value; }
        public int GetID { get => ID;}
        public string GetName { get => name;}
        public int GetAdmissionTime1 { get => admissionTime;}
        public int WorkingTime { get => WorkingTime; set => WorkingTime = value; }
        public int ToQueue { get => toQueue; set => toQueue = value; }
        internal ProcessStatus Status { get => status; set => status = value; }
        public int BurstTime { get => burstTime; set => burstTime = value; }
        public int WorkTime { get => workTime; set => workTime = value; }

        public Process(int time)
        {
            Random rd = new Random();
            ID = rd.Next() % 1000;
            admissionTime = time;
            name = "P" + Convert.ToString(ID);
        }

        public int CompareTo(object obj)
        {
            return burstTime.CompareTo(obj);
        }

        public static  bool operator < (Process p1,Process p2)
        {
            return p1.burstTime < p2.burstTime;
        }

        public static bool operator > (Process p1, Process p2)
        {
            return p1.burstTime > p2.burstTime;
        }

        public int TimeEstimate( int time)
        {
            return 0;
        }
    }
}
