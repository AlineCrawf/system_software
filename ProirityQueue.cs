using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace PriorityQueue
{
    
    class PriorityQueue<TItem, TStruct>
        where TItem : IComparable
        where TStruct : IQueueable<TItem>
    {
        public PriorityQueue(TStruct struc)
        {
            Contract.Requires<Exception>(struc != null, "Нарушение контракта: использование пустой ссылки для создания очереди");

            body = struc;
        }

        
        public TItem Item()
        {
            return body.Item();
        }
        public void Remove()
        {
            body.Remove();
        }
        
        public void Put(TItem t)
        {
            body.Put(t);
        }
       
        [Pure]
        public bool Empty()
        {
            return body.Count == 0;
        }

        public int Count
        {
            get
            {
                return body.Count;
            }
        }
        public void Clear()
        {
            body.Clear();
        }

        public TItem[] ToArray()
        {
            return body.ToArray();
        }

        private TStruct body;
    } 
}
