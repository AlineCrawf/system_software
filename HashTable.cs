using System;
using System.Collections.Generic;
using PriorityQueue;

namespace PriorityQueue
{
    public class Modelka
    {
        private readonly int min;
        private readonly int max;

        public int Max => max;

        public int Min => min;
        public Modelka()
        {
            max = 10;
            min = 1;
        }
    }

    public class HashTable<T>:IQueueable<T>
    {
        private Modelka model;
        private LinkedList<T>[] list;
        private int highest;
        private int count;
        
        public HashTable()
        {
            model = new Modelka();
            list = new LinkedList<T>[model.Max - model.Min+1];
            for (int i = model.Min; i < model.Max; i++)
                list[i] = new LinkedList<T>();
        }

        public int Count { get => count; }

       
        public void Clear()
        {
            for(int i =0;i<=(model.Max - model.Min);i++)
            {
                list[i].Clear();
            }
            highest = 0;
        }

        public T Item()
        {
            return list[highest].First.Value;
        }        

        public void Put(T item)
        {
            int index = item.GetHashCode() % list.Length;
            //int index = Convert.ToInt32(item);
            list[index].AddLast(item);
            if (index > highest)
                highest = index;
            count++;
        }

        public void Remove()
        {
            list[highest].RemoveFirst();
            count--;
            if (list[highest].Count == 0)
                for (highest--; list[highest].Count == 0 && highest > 0; highest--) ;
            

        }

        public T[] ToArray()
        {
            throw new NotImplementedException();
        }
    }
}
