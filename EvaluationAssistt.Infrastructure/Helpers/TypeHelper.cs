using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Infrastructure.Helpers
{
    public class TypeHelper
    {
        public static DateTime DateTime(DateTime date, DateTimeType type)
        {
            switch (type)
            {
                case DateTimeType.Min:
                    return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);

                case DateTimeType.Max:
                    return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
            }

            return date;
        }

        public static DateTime DateTimeMonthRange(DateTime date, DateTimeType type)
        {
            switch (type)
            {
                case DateTimeType.Min:
                    return new DateTime(date.Year, date.Month, 1, 0, 0, 0);
                case DateTimeType.Max:
                    return new DateTime(date.Year, date.Month, System.DateTime.DaysInMonth(date.Year, date.Month), 23, 59, 59);
            }

            return date;
        }

        public enum DateTimeType
        {
            Max,
            Min
        }
    }
}
