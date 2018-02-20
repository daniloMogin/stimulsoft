using server.Model;
using System.Threading.Tasks;

namespace server.Interfaces
{
    public interface IReportRepository
    {
        Task SaveReport(Reports data);
        Task<object> UpdateReport(Reports data);
        Task<Reports> GetReportByName(string name);
    }
}
