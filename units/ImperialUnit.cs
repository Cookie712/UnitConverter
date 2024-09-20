using Converter2f.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Units
{
    public class ImperialUnit : Unit
    {
        public Dictionary<string, double> imperialMap = new Dictionary<string, double>();

        public ImperialUnit(double value, string unit)
        {
            InitializeImpMap();
            baseValue = value * imperialMap[unit];
        }
        public ImperialUnit(Meter meter)
        {
            ratioToMeter = 0.0254;
            baseValue = meter.baseValue / this.ratioToMeter;
        }

        private void InitializeImpMap()
        {
            imperialMap.Add("in", 1);
            imperialMap.Add("ft", 12);
            imperialMap.Add("yd", 36);
            imperialMap.Add("fm", 72);
        }
        public double GetValue(string unit)
        {
            double value = baseValue / imperialMap[unit];
            return value;
        }
    }
}
