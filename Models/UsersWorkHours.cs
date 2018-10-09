using System;
using System.Collections.Generic;

namespace WashingtonRedskins.Models
{
    public partial class UsersWorkHours
    {
        public uint Id { get; set; }
        public DateTime? DeletedAt { get; set; }
        public uint UserId { get; set; }
        public uint WorkHourId { get; set; }

        public Users User { get; set; }
        public WorkHours WorkHour { get; set; }
    }
}
