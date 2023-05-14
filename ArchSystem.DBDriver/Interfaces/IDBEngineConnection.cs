using ArchSystem.Dto.Models;

namespace DBDriver.Interfaces
{
    public interface IDBEngineConnection
    {
        IDBSource DBSource { get; }
        void CloseConnection();
    }
}
