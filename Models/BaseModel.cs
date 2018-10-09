using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WashingtonRedskins
{
    public class BaseModel : IHasBasicIndexer
    {
        public object this[string propertyName]
        {
            get
            {
                return this.GetType().GetProperties();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
