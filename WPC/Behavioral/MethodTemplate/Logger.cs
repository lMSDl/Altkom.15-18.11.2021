using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.MethodTemplate
{
    public abstract class Logger<T, TService> where TService : IDisposable
    {
        public void Log(string message)
        {
            T info = ConvertMessage(message);
            using (var service = GetService())
            {
                LogMessage(service, info);
            }
            OnServiceClosed();
        }

        protected virtual void OnServiceClosed()
        {
        }

        protected abstract void LogMessage(TService service, T info);

        protected abstract TService GetService();

        protected virtual string PrepareMessage(string message)
        {
            return $"{DateTime.Now}: {message}";
        }
        protected abstract T ConvertMessage(string message);
    }
}
