using System;
using System.Collections;

namespace Labki3
{
    class Queue_ext : ArrayList
    {

        public void Enqueue(Object value)
        {
            this.Add(value);
        }
        public Object Dequeue()
        {
            Object obj = null;
            if (this.Count > 0)
            {
                obj = this[0];
                this.Remove(obj);
            }
            return obj;
        }
    }
    //Co należy zrobić w obydwu przypadkach, że kolejka działała nie na ArrayList tylko na tablicy? 
    class Queue_composition
    {
        IList arrayList;

        public Queue_composition(IList collection)
        {
            arrayList = collection;
        }
        public void Enqueue(Object value)
        {
            arrayList.Add(value);
        }
        public Object Dequeue()
        {
            Object obj = null;
            if (arrayList.Count > 0)
            {
                obj = arrayList[0];
                arrayList.Remove(obj);
            }
            return obj;
        }
    }

}
