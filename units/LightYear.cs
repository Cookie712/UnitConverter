using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter2f.units
{
    public class LightYear : Unit
    {
        public LightYear(double value)
        {
            baseValue = value;
            ratioToMeter = 9460730777119564;
        }

        public LightYear(Meter meter)
        {
            ratioToMeter = 9460730777119564;
            baseValue = meter.baseValue / ratioToMeter;
        }

        public double GetValue()
        {
            return baseValue;
        }
    }
}
