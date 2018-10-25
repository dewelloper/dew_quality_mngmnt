using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace EvaluationAssistt.Infrastructure.Extensions
{
    public static class TypeExtensions
    {
        private static CultureInfo culture = new CultureInfo("tr-TR");

        public static string ToMonthName(this DateTime dateTime)
        {
            return culture.DateTimeFormat.GetMonthName(dateTime.Month);
        }

        public static string ToShortMonthName(this DateTime dateTime)
        {
            return culture.DateTimeFormat.GetAbbreviatedMonthName(dateTime.Month);
        }
    }
}
