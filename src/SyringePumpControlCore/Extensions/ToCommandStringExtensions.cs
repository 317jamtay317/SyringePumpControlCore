using System;
using SyringePumpControlCore.Models;
using SyringePumpControlCore.Models.CommandConstants;

namespace SyringePumpControlCore.Extensions
{
    public static class ToCommandStringExtensions
    {
        public static string ToCommandString(this PumpDirection direction)
        {
            return direction == PumpDirection.Infuse
                ? PumpDirectionConversions.Infuse
                : PumpDirectionConversions.Withdraw;
        }

        public static string ToCommandString(this Units unit)
        {
            return unit == Units.Microliters ? UnitConversions.Microliters : UnitConversions.Milliliters;
        }

        public static string ToCommandString(this RateUnits rateUnits)
        {
            switch (rateUnits)
            {
                case RateUnits.MicrolitersPerMinutes:
                    return UnitRateConversions.MicrolitersPerMinute;
                case RateUnits.MicrolitersPerHour:
                    return UnitRateConversions.MicrolitersPerHour;
                case RateUnits.MillilitersPerMinute:
                    return UnitRateConversions.MilliLiterPerMinute;
                case RateUnits.MilliLitersPerHour:
                    return UnitRateConversions.MillilitersPerHour;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}