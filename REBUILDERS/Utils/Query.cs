using System;
using Xamarin.UITest.Queries;

namespace Rebuilders.Utils
{
    public class Query
    {
        public Func<AppQuery, AppQuery> Operation { get; }
        public int Counter;
        public AppResult[] Results;

        public Query(string marked) 
            : this(x => x.Marked(marked))
        {
            
        }



        public Query(Func<AppQuery, AppQuery> operation)
        {
            Operation = operation;
        }

        public static implicit operator Func<AppQuery, AppQuery>(Query q)
        {
            return q.Operation;
        }

        public static implicit operator Query(AppResult v)
        {
            throw new NotImplementedException();
        }
    }
}
