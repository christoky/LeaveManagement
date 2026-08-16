using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Application.Services.Periods
{
    public class PeriodsService(ApplicationDbContext _context) : IPeriodsService
    {
        public async Task<Period> GetCurrentPeriod()
        {
            var curentDate = DateTime.Now;
            var period = await _context.Periods.SingleAsync(q => q.EndDate.Year == curentDate.Year);

            return period;
        }
    }
}
