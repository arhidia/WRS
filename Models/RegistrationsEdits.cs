using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WashingtonRedskins.Models
{
    public class RegistrationsEdits
    {
        public uint Id { get; set; }
        public DateTime? Time { get; set; }

        public static void set(DateTime time)
        {
            using (var dbContext = new WashingtonRedskinsContext())
            {
                var regEdit = dbContext.RegistrationsEdits.Where(r => r.Time > time).FirstOrDefault();
                if (regEdit != null)
                {
                    regEdit.Time = time;
                    dbContext.SaveChanges();
                }
            }
        }

        public static RegistrationsEdits get()
        {
            RegistrationsEdits regEdit;

            using (var dbContext = new WashingtonRedskinsContext())
            {
                regEdit = dbContext.RegistrationsEdits.First();
            }

            return regEdit;
        }

        public static void add(RegistrationsEdits regEdit)
        {
            using (var DbContext = new WashingtonRedskinsContext())
            {
                DbContext.RegistrationsEdits.Add(regEdit);
                DbContext.SaveChanges();
            }
        }
    }
}
