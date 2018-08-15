using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WageAnalyzer.Models;

namespace WageAnalyzer.Services
{
    public class FakeWageService : IWageService
    {
        private List<WageDetail> Wages { get; set; } = new List<WageDetail>();

        public async Task<bool> Login(string username, string password)
        {
            return true;
        }

        public async Task<List<WageListItem>> GetAll()
        {
            return Wages.Select(wage => new WageListItem
            {
                WageId = wage.WageId,
                CreatedUtc = wage.CreatedUtc,
                MoneyEarnedThatDay = wage.MoneyEarnedThatDay,
                HoursWorkedThatDay = wage.HoursWorkedThatDay
            }).OrderBy(o => o.CreatedUtc).ToList();
        }

        public async Task<WageDetail> GetById(int wageId)
        {
            return Wages.FirstOrDefault(note => note.WageId == wageId);
        }

        public async Task<bool> AddNew(WageCreate wage)
        {
            if ((wage.HoursWorkedThatDay == 0) || (wage.HoursWorkedThatDay <= 0)) return false;

            Wages.Add(new WageDetail
            {
                WageId = Wages.Any() ? Wages.Max(n => n.WageId) + 1 : 1,
                HoursWorkedThatDay = wage.HoursWorkedThatDay,
                MoneyEarnedThatDay = wage.MoneyEarnedThatDay,
                CreatedUtc = DateTimeOffset.UtcNow
            });

            return true;
        }

        public async Task<bool> Update(WageEdit wage)
        {
            var wageToUpdate = await GetById(wage.WageId);

            if (wageToUpdate == null) return false;

            wageToUpdate.HoursWorkedThatDay = wage.HoursWorkedThatDay;
            wageToUpdate.MoneyEarnedThatDay = wage.MoneyEarnedThatDay;
            wageToUpdate.ModifiedUtc = DateTimeOffset.UtcNow;

            return true;
        }

        public async Task<bool> Delete(int wageId)
        {
            var wageToUpdate = await GetById(wageId);

            if (wageToUpdate == null) return false;

            Wages.Remove(wageToUpdate);
            return true;
        }
    }
}
