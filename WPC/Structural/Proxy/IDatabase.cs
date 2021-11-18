using System.Threading.Tasks;

namespace WPC.Structural.Proxy
{
    public interface IDatabase
    {
        bool IsConnected { get; }
        Task<int?> RequestAsync(int parameter);
        void Connect();
        void Disconnect();
    }
}
