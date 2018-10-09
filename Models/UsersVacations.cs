using System;
using System.Collections.Generic;

namespace WashingtonRedskins.Models
{
    public partial class UsersVacations
    {
        public uint Id { get; set; }
        public DateTime? DeletedAt { get; set; }
        public uint? UserId { get; set; }
        public uint? VacationId { get; set; }

        public Users User { get; set; }
        public Vacations Vacation { get; set; }
    }
}
