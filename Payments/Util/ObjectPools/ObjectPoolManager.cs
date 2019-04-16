using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Util.ObjectPools
{
    /// <summary>
    /// 对象池
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObjectPoolManager<T> where T : class, new()
    {
        protected DefaultObjectPool<T> DefaultObjectPool;

        private object objPoolLock = new object();

        public ObjectPoolManager(int maximumRetained = 20)
        {
            if (DefaultObjectPool == null)
            {
                lock (objPoolLock)
                {
                    if (DefaultObjectPool == null)
                    {
                        var defaultPooledObjectPolicy = CreatePooledObjectPolicy();
                        DefaultObjectPool = new DefaultObjectPool<T>(defaultPooledObjectPolicy, maximumRetained);
                    }
                }
            }
        }

        protected virtual IPooledObjectPolicy<T> CreatePooledObjectPolicy()
        {
            var defaultPooledObjectPolicy = new DefaultPooledObjectPolicy<T>();
            return defaultPooledObjectPolicy;
        }


        public void Handle(Action<T> action)
        {
            var t = DefaultObjectPool.Get();
            try
            {
                action.Invoke(t);
            }
            catch
            {
                throw;
            }
            finally
            {
                DefaultObjectPool.Return(t);
            }


        }

        public TResult Handle<TResult>(Func<T, TResult> func) where TResult : class, new()
        {
            TResult result = null;
            var t = DefaultObjectPool.Get();
            try
            {
                result = func.Invoke(t);
            }
            catch
            {
                throw;
            }
            finally
            {
                DefaultObjectPool.Return(t);
            }
            return result;
        }


        public Task HandleAsync(Action<T> action)
        {
            var t = DefaultObjectPool.Get();
            try
            {
                action.Invoke(t);
            }
            catch
            {
                throw;
            }
            finally
            {
                DefaultObjectPool.Return(t);
            }
            return Task.CompletedTask;

        }

        public Task<TResult> HandleAsync<TResult>(Func<T, Task<TResult>> func) where TResult : class, new()
        {
            Task<TResult> result = null;
            var t = DefaultObjectPool.Get();
            try
            {
                result = func.Invoke(t);
            }
            catch
            {
                throw;
            }
            finally
            {
                DefaultObjectPool.Return(t);
            }
            return result;
        }


    }



    #region HttpClient
    public class HttpClientPooledObjectPolicy : PooledObjectPolicy<HttpClient>
    {
        private HttpClientHandler _handler;
        public HttpClientPooledObjectPolicy(HttpClientHandler handler)
        {
            _handler = handler;
        }

        public override HttpClient Create()
        {
            HttpClient client = null;
            if (_handler == null)
            {
                client = new HttpClient();
            }
            else
            {
                client = new HttpClient(_handler);
            }
            return client;
        }

        public override bool Return(HttpClient obj)
        {
            return true;
        }
    }


    public class HttpClientPoolManager : ObjectPoolManager<HttpClient>
    {
        protected HttpClientHandler ClientHandler;
        public HttpClientPoolManager(HttpClientHandler clientHandler)
        {
            ClientHandler = clientHandler;
        }
        protected override IPooledObjectPolicy<HttpClient> CreatePooledObjectPolicy()
        {
            var defaultPooledObjectPolicy = new HttpClientPooledObjectPolicy(ClientHandler);
            return defaultPooledObjectPolicy;
        }
    }

    #endregion
}
