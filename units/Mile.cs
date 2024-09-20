using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter2f.units
{
    public class Mile : Unit
    {
        public Mile(double value)
        {
            baseValue = value;
            ratioToMeter = 1609;
        }

        public Mile(Meter meter)
        {
            ratioToMeter = 1609;
            baseValue = meter.baseValue / ratioToMeter;
        }

        public double GetValue()
        {
            return baseValue;
        }
    }
}
