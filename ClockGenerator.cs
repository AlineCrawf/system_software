using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    class ClockGenerator
    {
        int currentTact;

        public ClockGenerator()
        {
            currentTact = 0;
        }

        public int CurrentTact { get => currentTact;}
        public void Clear()
        {
            currentTact = 0;
        }
        public void NextTime()
        {
            currentTact++;
        }
    }
}
