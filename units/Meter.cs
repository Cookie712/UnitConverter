using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter2f.units
{
    public class Meter : Unit
    {
        public Dictionary<string, double> meterMap = new Dictionary<string, double>();

        public Meter(double value, string unit)
        {
            InitializeMeterMap();
            baseValue = value * meterMap[unit];
            ratioToMeter = 1;
        }

        public Meter(Unit unit)
        {
            InitializeMeterMap();
            ratioToMeter = 1;
            baseValue = unit.baseValue * unit.ratioToMeter;
        }

        public double GetValue(string unit)
        {
            double value = baseValue / meterMap[unit];
            return value;
        }

        private void InitializeMeterMap()
        {
            meterMap.Add("um", 0.000001);
            meterMap.Add("mm", 0.001);
            meterMap.Add("cm", 0.01);
            meterMap.Add("m", 1);
            meterMap.Add("km", 1000);
        }
    }
}
