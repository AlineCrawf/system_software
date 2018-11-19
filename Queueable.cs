using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;


namespace PriorityQueue
{ 
[ContractClass(typeof(QueueContract<>))]
interface IQueueable<T>
{
    T Item();
    void Put(T t);
    void Remove();

    int Count { get; }
    void Clear();

    //temporary
    T[] ToArray();
}

[ContractClassFor(typeof(IQueueable<>))]

public abstract class QueueContract<T> : IQueueable<T>
{
    [Pure]
    public T Item()
    {
        Contract.Requires<Exception>(Count > 0, "Нарушение контракта: попытка доступа к пустой очереди");
        return default(T);
    }
    public void Put(T t)
    {
        Contract.Ensures(this.Count == Contract.OldValue<int>(this.Count) + 1);
    }
    public void Remove()
    {
        Contract.Requires<Exception>(Count > 0, "Нарушение контракта: попытка удаления из пустой очереди");
        Contract.Ensures(this.Count == Contract.OldValue<int>(this.Count) - 1);
    }

    public int Count
    {
        get
        {
            Contract.Ensures(0 <= Contract.Result<System.Int32>());
            return default(int);
        }
    }
    public void Clear()
    {
        Contract.Ensures(Count == 0);
    }

    public T[] ToArray()
    {
        return new T[1];
    }
}
}
