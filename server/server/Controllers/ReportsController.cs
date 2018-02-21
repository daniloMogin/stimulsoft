using Microsoft.AspNetCore.Mvc;
using server.Infrastructure;
using server.Interfaces;
using server.Model;
using System;
using System.Threading.Tasks;

namespace server.Controllers
{
    [Produces("application/json")]
    [Route("api/Reports")]
    public class ReportsController : Controller
    {
        private readonly IReportRepository _reportRepository;

        public ReportsController(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        
        [HttpPost]
        public async Task<string> SaveReport([FromBody] Reports data)
        {
            var findReport = await GetReportByName(data.Name);

            if (findReport == null)
            {
                var saveReport = Save(data);

                return "Save done!!!";
            } else
            {
                Update(data);
                return "Update done!!!";
            }
        }

        private Task Save([FromBody] Reports data)
        {
            try
            {
                return _reportRepository.SaveReport(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Update([FromBody] Reports data)
        {
            try
            {
                _reportRepository.UpdateReport(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<Reports> GetReportByName(string id)
        {
            return await _reportRepository.GetReportByName(id);
        }
    }
}