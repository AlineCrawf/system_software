using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    class CPU
    {
        bool isFree;
        Process activProcess;

        public bool IsFree { get => isFree; }
        internal Process ActivProcess { get => activProcess; set => activProcess = value; }
        public void NextTime()
        {
            if (!IsFree)
                activProcess.WorkingTime++;
        }
        public void Clear()
        {
            isFree = true;
            activProcess = null;
        }
    }
}
