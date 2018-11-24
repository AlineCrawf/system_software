using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{

    class Model
    {
        public Model(double it, int burstMin, int burstMax)
        {
            // создание компонентов модели
            clockGen = new ClockGenerator();
            cpu = new CPU();
            HashTable <Process> hashTable = new HashTable <Process>();
            readyQueue = new PriorityQueue <Process, HashTable<Process>> (hashTable);
            cpuScheduler = new CPUScheduler(cpu, readyQueue);
            processRand = new Random();

            // сохранение параметров системы
            intensityThreshold = it;
            this.burstMin = burstMin;
            this.burstMax = burstMax;
        }

        /// <summary>
        /// действия модели на такте работы
        /// </summary>
        public void NextTime()
        {
            clockGen.NextTime(); // увеличивается номер такта
            if (processRand.NextDouble() < intensityThreshold) // порог интенсивности
                                                               // поступления процессов не превышен
            {
                // создаётся новый процесс
                Process newProcess = new Process(clockGen.CurrentTact);
                // генерируется интервал обслуживания процесса процессором
                newProcess.BurstTime = processRand.Next(burstMin, burstMax + 1);
                // и помещается в очередь готовых процессов
                readyQueue.Put(newProcess);
            }
            // выполняется шаг работы центрального процессора
            cpu.NextTime();
            // если требуется перепланировка
            if (redevelopmentNeed())
                // вызвается планировщик центрального процессора
                cpuScheduler.NextTime();
        }
        public void Clear()
        {
            clockGen.Clear();
            cpu.Clear();
            readyQueue.Clear();
        }
        public ClockGenerator ClockGen
        {
            get
            {
                return clockGen;
            }
        }
        public CPU Cpu
        {
            get
            {
                return cpu;
            }
        }
        public CPUScheduler CpuScheduler
        {
            get
            {
                return cpuScheduler;
            }
        }
        public PriorityQueue<Process,HashTable<Process>> ReadyQueue
        {
            get
            {
                return readyQueue;
            }
        }
        public Random ProcessRand
        {
            get
            {
                return processRand;
            }
        }
        /// <summary>
        /// Компоненты модели
        /// </summary>

        /// <summary>
        /// Часы
        /// </summary>
        private ClockGenerator clockGen;

        /// <summary>
        /// центральный процессор
        /// </summary>
        private CPU cpu;

        /// <summary>
        /// планировщик центрального процессора
        /// </summary>
        private CPUScheduler cpuScheduler;

        /// <summary>
        /// очередь готовых процессов
        /// </summary>
        private PriorityQueue<Process,HashTable<Process>> readyQueue;

        /// <summary>
        /// генератор процессов
        /// </summary>
        private Random processRand;

        /// <summary>
        /// параметры модели
        /// </summary>

        /// <summary>
        /// Порог интенсивности поступления процессов
        /// </summary>
        private double intensityThreshold;

        /// <summary>
        /// Минимальная величина интервала обслуживания
        /// </summary>
        private int burstMin;

        /// <summary>
        /// Максимальная величина интервала обслуживания
        /// </summary>
        private int burstMax;

        // вспомогательный метод, определяющий, требуется ли перепланировка
        private bool redevelopmentNeed()
        {
            return (cpu.IsFree || cpu.ActivProcess.WorkTime ==
                        cpu.ActivProcess.BurstTime);
        }
    }

}

