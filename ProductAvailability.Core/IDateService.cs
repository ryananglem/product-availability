using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAvailability.Core
{
    public interface IDateService
    {
        DateTime ParseLongDateFormat(string date);
    }
}
