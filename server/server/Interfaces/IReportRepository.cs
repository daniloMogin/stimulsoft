using server.Model;
using System.Threading.Tasks;

namespace server.Interfaces
{
    public interface IReportRepository
    {
        Task SaveReport(Reports data);
        void UpdateReport(Reports data);
        Task<Reports> GetReportByName(string name);
    }
}
