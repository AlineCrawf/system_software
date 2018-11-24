using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    class CPUScheduler
    {
        private CPU cpu;
        private PriorityQueue<Process, HashTable<Process>> queue;

        public CPUScheduler(CPU cpu ,PriorityQueue<Process,HashTable<Process>> queue)
        {
            this.cpu = cpu;
            this.queue = queue;
        }

        public void NextTime()
        {
            if (queue.Item() < cpu.ActivProcess)
            {
                queue.Put(cpu.ActivProcess);
                cpu.ActivProcess = queue.Item();
                queue.Remove();
                cpu.NextTime();
            }

            else
            {
                cpu.NextTime();
            }
        }
    }
}
