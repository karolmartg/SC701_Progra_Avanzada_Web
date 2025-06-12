using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW.Architecture.Extensions
{
    public static class DateTimeExtensions
    {
        public static int GenerateIdFromNow(this DateTime d)
        {
            var now = DateTime.Now;
            return now.Microsecond + (now.Second - now.Minute) * 1000;
        }
    }
}
