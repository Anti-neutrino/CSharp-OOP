using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntervalTree
{
    public enum ContainConstrains
    {
        None,
        IncludeStart,
        IncludeEnd,
        IncludStartAndEnd
    }

   public class Interval<T,D> :IComparable<Interval<T,D>> where D:IComparable<D>
   {
       private D start;
       private D end;
       private T data;

       public Interval(D start,D end,T data)
       {
           this.start = start;
           this.end = end;
           this.data = data;
       }

       public D Start
       {
           get { return start; }
           set { start = value; }
       }

       public D End
       {
           get { return end; }
           set { end = value; }
       }

       public T Data
       {
           get { return data; }
           set { data = value; }
       }

       public bool Contains(D data,ContainConstrains constrains)
       {
           bool isContained = false;

           switch(constrains)
           {
               case ContainConstrains.None:
                   isContained = Contains(data);break;
               case ContainConstrains.IncludeStart:
                   isContained = ContainsWithStart(data);break;
               case ContainConstrains.IncludeEnd:
                   isContained = ContainsWithEnd(data);break;
               case ContainConstrains.IncludStartAndEnd:
                   isContained=ContainsWithStartAndEnd(data);break;
               default: throw new ArgumentException("Invalid operation.");
           }

           return isContained;
       }

       private bool ContainsWithStart(D data)
       {
           return data.CompareTo(end) < 0 && data.CompareTo(start) >= 0;
       }

       private bool ContainsWithEnd(D data)
       {
           return data.CompareTo(end) <= 0 && data.CompareTo(start) > 0;
       }

       private bool ContainsWithStartAndEnd(D data)
       {
           return data.CompareTo(end) <= 0 && data.CompareTo(start) >= 0;
       }

       public bool Contains(D time)
       {
           return time.CompareTo(end) < 0 && time.CompareTo(start) > 0;
       }

       public bool Intersects(Interval<T,D> other)
       {
           return other.End.CompareTo(this.start) > 0 && other.Start.CompareTo(this.end) < 0;
       }

       public int CompareTo(Interval<T, D> other)
       {
          if(start.CompareTo(other.Start)<0)
          {
              return -1;
          }
          else if(start.CompareTo(other.Start)>0)
          {
              return 1;
          }
          else if(end.CompareTo(other.End)<0)
          {
              return -1;
          }
          else if(end.CompareTo(other.End)>0)
          {
              return 1;
          }

          return 0;
       }

       public override string ToString()
       {
           return string.Format("{0}--{1}", start, end);
       }
   }
}
