using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WashingtonRedskins.Models
{
    public partial class RegistrationSummary
    {
        public uint Id { get; set; }
        public int Duration { get; set; }
        public uint UserId { get; set; }
        public uint StatusId { get; set; }
        public uint? DepartmentId { get; set; }
        public DateTime Date { get; set; }
        public DateTime DeletedAt { get; set; }
        public int YearWeek { get; set; }
        public int YearMonth { get; set; }

        public Departments Department { get; set; }
        public Statuses Status { get; set; }
        public Users User { get; set; }

        public static List<RegistrationSummary> list(DateTime start, bool groupByDay, bool groupByWeek, bool groupByMonth)
        {
            List<RegistrationSummary> regSum;
            using (var dbContext = new WashingtonRedskinsContext())
            {

                if (groupByMonth)
                {
                    regSum = dbContext.RegistrationSummary.Where(r => r.Date > start).GroupBy(s => new { s.YearMonth, s.UserId, s.StatusId, s.DepartmentId })
                            .Select(g =>
                                            new RegistrationSummary
                                            {
                                                UserId = g.Key.UserId,
                                                Duration = g.Sum(x => x.Duration),
                                                Id = g.Min(x => x.Id),
                                                YearMonth = g.Key.YearMonth,
                                                YearWeek = 0,
                                                DepartmentId = g.Key.DepartmentId,
                                                StatusId = g.Key.StatusId,
                                                Date = g.Min(x => x.Date)
                                            }
                                    ).ToList();
                }
                else if (groupByMonth)
                {
                    regSum = dbContext.RegistrationSummary.Where(r => r.Date > start).GroupBy(s => new { s.YearWeek, s.UserId, s.StatusId, s.DepartmentId })
                            .Select(g =>
                                            new RegistrationSummary
                                            {
                                                UserId = g.Key.UserId,
                                                Duration = g.Sum(x => x.Duration),
                                                Id = g.Min(x => x.Id),
                                                YearMonth = g.Key.YearWeek,
                                                YearWeek = 0,
                                                DepartmentId = g.Key.DepartmentId,
                                                StatusId = g.Key.StatusId,
                                                Date = g.Min(x => x.Date)
                                            }
                                    ).ToList();
                }
                else
                {
                    regSum = dbContext.RegistrationSummary.Where(r => r.Date > start).GroupBy(s => new { s.UserId, s.StatusId, s.DepartmentId })
                            .Select(g =>
                                            new RegistrationSummary
                                            {
                                                UserId = g.Key.UserId,
                                                Duration = g.Sum(x => x.Duration),
                                                Id = g.Min(x => x.Id),
                                                YearMonth = 0,
                                                YearWeek = 0,
                                                DepartmentId = g.Key.DepartmentId,
                                                StatusId = g.Key.StatusId,
                                                Date = g.Min(x => x.Date)
                                            }
                                    ).ToList();
                }

                return regSum;
            }
        }
    }
}

