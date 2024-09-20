using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter2f.units
{
    public class AstronomicalUnit : Unit
    {
        public AstronomicalUnit(double value)
        {
            baseValue = value;
            ratioToMeter = 149597870700;
        }

        public AstronomicalUnit(Meter meter)
        {
            ratioToMeter = 149597870700;
            baseValue = meter.baseValue / ratioToMeter;
        }

        public double GetValue()
        {
            return baseValue;
        }

    }
}
