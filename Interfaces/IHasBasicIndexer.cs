using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WashingtonRedskins
{
    public interface IHasBasicIndexer
    {
        object this[string propertyName] { get; set; }
    }
}
