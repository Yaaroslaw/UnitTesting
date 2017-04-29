using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;
using System.Threading;

namespace LogAndNotoficationUnitTestsNUNIT
{
    public class AsyncListProvider : IDbAsyncQueryProvider
    {
        private readonly IQueryProvider _provider;
        public AsyncListProvider(IQueryProvider provider)
        {
            _provider = provider;
        }
        public IQueryable CreateQuery(Expression expression)
        {
            return _provider.CreateQuery(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return _provider.CreateQuery<TElement>(expression);
        }

        public object Execute(Expression expression)
        {
            return _provider.Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return _provider.Execute<TResult>(expression);
        }

        public Task<object> ExecuteAsync(Expression expression, CancellationToken cancellationToken)
        {
            return Task.Run(() => Execute(expression), cancellationToken);
        }

        public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
        {
            return Task.Run(() => Execute<TResult>(expression), cancellationToken);
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
        public Expression Expression => Expression.Constant(_data.AsQueryable());

        public Type ElementType => typeof(T);

        public IQueryProvider Provider => new AsyncListProvider(_data.AsQueryable().Provider);

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

        public ObservableCollection<T> Local => new ObservableCollection<T>(_data);

        Expression IQueryable.Expression
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }

}
