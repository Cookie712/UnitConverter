using Converter.Units;
using Converter2f.units;

namespace Converter2f
{
    public static class Menu
    {
        public static void showMainMenu()
        {
            Console.WriteLine("Wybierz jednostke zrodlowa:");
            showUnits();
            string sourceUnit = getUserChoosenUnit();
            Console.WriteLine("Podaj wartosc jednostki:");
            double sourceValue = double.Parse(Console.ReadLine());

            Console.WriteLine("Wybierz jednostke docelowa:");
            showUnits();
            string targetUnit = getUserChoosenUnit();

            if (checkIsBothImperialUnits(sourceUnit, targetUnit))
            {
                ImperialUnit imperialUnit = new ImperialUnit(sourceValue, sourceUnit);
                Console.WriteLine($"{sourceValue} {sourceUnit} to " +
                    $"{imperialUnit.GetValue(targetUnit)} {targetUnit}");
            }
            else
            {
                Meter meter = getMeterFromSourceUnit(sourceValue, sourceUnit);
                Console.WriteLine($"{sourceValue} {sourceUnit} to " +
                    $"{getTargetUnitValue(meter, targetUnit)} {targetUnit}");
            }
        }

        private static double getTargetUnitValue(Meter meter, string targetUnit)
        {
            switch (targetUnit)
            {
                case "ly":
                    return new LightYear(meter).baseValue;
                case "au":
                    return new AstronomicalUnit(meter).baseValue;
                case "mile":
                    return new Mile(meter).baseValue;
                case "NM":
                    return new NauticalMile(meter).baseValue;
                default:
                    if (new ImperialUnit(1, "in").imperialMap.ContainsKey(targetUnit))
                    {
                        return new ImperialUnit(meter).GetValue(targetUnit);
                    }
                    else
                    {
                        return meter.GetValue(targetUnit);
                    }
            }
        }

        private static Meter getMeterFromSourceUnit(double sourceValue, string sourceUnit)
        {
            switch (sourceUnit)
            {
                case "ly":
                    return new Meter(new LightYear(sourceValue));
                case "au":
                    return new Meter(new AstronomicalUnit(sourceValue));
                case "mile":
                    return new Meter(new Mile(sourceValue));
                case "NM":
                    return new Meter(new NauticalMile(sourceValue));
                default:
                    if (new ImperialUnit(1, "in").imperialMap.ContainsKey(sourceUnit))
                    {
                        return new Meter(new ImperialUnit(sourceValue, sourceUnit));
                    }
                    else if (new Meter(1, "m").meterMap.ContainsKey(sourceUnit))
                    {
                        return new Meter(sourceValue, sourceUnit);
                    }
                    else
                    {
                        Console.WriteLine("Blad");
                        return null;
                    }

            }
        }

        private static bool checkIsBothImperialUnits(string sourceUnit, string targetUnit)
        {
            ImperialUnit imperialUnit = new ImperialUnit(1, "in");
            return imperialUnit.imperialMap.ContainsKey(sourceUnit) &&
                imperialUnit.imperialMap.ContainsKey(targetUnit);
        }

        private static string getUserChoosenUnit()
        {
            int firstChoice = int.Parse(Console.ReadLine());
            string resultUnit = "None";

            switch (firstChoice)
            {
                case 1:
                    resultUnit = getMetricUnit();
                    break;
                case 2:
                    resultUnit = getImperialUnit();
                    break;
                case 3:
                    resultUnit = "mile";
                    break;
                case 4:
                    resultUnit = "NM";
                    break;
                case 5:
                    resultUnit = " au";
                    break;
                case 6:
                    resultUnit = "ly";
                    break;
                default:
                    Console.WriteLine("Bledny wybor");
                    break;
            }

            return resultUnit;
        }

        private static string getMetricUnit()
        {
            Meter meter = new Meter(1, "m");
            List<string> meterUnits = meter.meterMap.Keys.ToList();

            for (int i = 0; i < meterUnits.Count; i++)
            {
                Console.WriteLine($"{i + 1} {meterUnits[i]}");
            }

            int userChoice = int.Parse(Console.ReadLine());
            return meterUnits[userChoice - 1];
        }

        private static string getImperialUnit()
        {
            ImperialUnit imperialUnit = new ImperialUnit(1, "in");
            List<string> imperialUnits = imperialUnit.imperialMap.Keys.ToList();

            for (int i = 0; i < imperialUnits.Count; i++)
            {
                Console.WriteLine($"{i + 1} {imperialUnits[i]}");
            }

            int userChoice = int.Parse(Console.ReadLine());
            return imperialUnits[userChoice - 1];
        }

        private static void showUnits()
        {
            Console.WriteLine("1.Metryczne");
            Console.WriteLine("2.Imperialne");
            Console.WriteLine("3.Mile");
            Console.WriteLine("4.MileMorskie");
            Console.WriteLine("5.Jednostka astronomiczna");
            Console.WriteLine("6.Lata swietlne");
        }
    }
}

