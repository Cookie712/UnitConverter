using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter2f.units
{
    public class NauticalMile : Unit
    {
        public NauticalMile(double value)
        {
            baseValue = value;
            ratioToMeter = 1852;
        }

        public NauticalMile(Meter meter)
        {
            ratioToMeter = 1852;
            baseValue = meter.baseValue / ratioToMeter;
        }

        public double GetValue()
        {
            return baseValue;
        }
    }
}
