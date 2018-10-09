using System;
using System.Collections.Generic;

namespace WashingtonRedskins.Models
{
    public partial class WorkHoursBreaks
    {
        public uint Id { get; set; }
        public uint? BreakId { get; set; }
        public DateTime? DeletedAt { get; set; }
        public uint? WorkHourId { get; set; }

        public Breaks Break { get; set; }
        public WorkHours WorkHour { get; set; }
    }
}
