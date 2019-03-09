using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Generic;
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
        private static DefaultObjectPool<T> _defaultObjectPool;
        static ObjectPoolManager()
        {
            var defaultPooledObjectPolicy = new DefaultPooledObjectPolicy<T>();
            _defaultObjectPool = new DefaultObjectPool<T>(defaultPooledObjectPolicy, 20);
        }


        public static void Handle(Action<T> action)
        {
            var t = _defaultObjectPool.Get();
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
                _defaultObjectPool.Return(t);
            }


        }

        public static TResult Handle<TResult>(Func<T, TResult> func) where TResult : class, new()
        {
            TResult result = null;
            var t = _defaultObjectPool.Get();
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
                _defaultObjectPool.Return(t);
            }
            return result;
        }


        public static Task HandleAsync(Action<T> action)
        {
            var t = _defaultObjectPool.Get();
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
                _defaultObjectPool.Return(t);
            }
            return Task.CompletedTask;

        }

        public static Task<TResult> HandleAsync<TResult>(Func<T, Task<TResult>> func) where TResult : class, new()
        {
            Task<TResult> result = null;
            var t = _defaultObjectPool.Get();
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
                _defaultObjectPool.Return(t);
            }
            return result;
        }


    }
}
