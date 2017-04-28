using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAndNotoficationUnitTestsNUNIT
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    public class AsyncListProvider : System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
    {
        private IQueryProvider provider;
        public AsyncListProvider(IQueryProvider Provider)
        {
            provider = Provider;
        }
        public IQueryable CreateQuery(Expression expression)
        {
            return provider.CreateQuery(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return provider.CreateQuery<TElement>(expression);
        }

        public object Execute(Expression expression)
        {
            return provider.Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return provider.Execute<TResult>(expression);
        }

        public Task<object> ExecuteAsync(Expression expression, CancellationToken cancellationToken)
        {
            return Task.Run(() => Execute(expression), cancellationToken);
        }

        public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
        {
            return Task<TResult>.Run<TResult>(() => Execute<TResult>(expression), cancellationToken);
        }
    }

    public class FakeDbSet<T> : IDbSet<T> where T : class
    {
        private readonly List<T> _data;

        public FakeDbSet()
        {
            _data = new List<T>();
        }

        public FakeDbSet(params T[] entities)
        {
            _data = new List<T>(entities);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _data.GetEnumerator();
        }
        public Expression Expression
        {
            get { return Expression.Constant(_data.AsQueryable()); }
        }

        public Type ElementType
        {
            get { return typeof(T); }
        }

        public IQueryProvider Provider
        {
            get { return new AsyncListProvider(_data.AsQueryable().Provider); }
        }

        public T Find(params object[] keyValues)
        {
            throw new NotImplementedException("Wouldn't you rather use Linq .SingleOrDefault()?");
        }

        public T Add(T entity)
        {
            _data.Add(entity);
            return entity;
        }

        public T Remove(T entity)
        {
            _data.Remove(entity);
            return entity;
        }

        public T Attach(T entity)
        {
            _data.Add(entity);
            return entity;
        }

        public T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<T> Local
        {
            get { return new ObservableCollection<T>(_data); }
        }

        Expression IQueryable.Expression
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }

}
