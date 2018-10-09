using System;
using System.Collections.Generic;

namespace WashingtonRedskins.Models
{
    public partial class UserGroupsPriviliges
    {
        public uint Id { get; set; }
        public DateTime? DeletedAt { get; set; }
        public sbyte Isallowed { get; set; }
        public uint? PrivilegeId { get; set; }
        public uint? UserGroupId { get; set; }

        public Privileges Privilege { get; set; }
        public UserGroup UserGroup { get; set; }
    }
}
