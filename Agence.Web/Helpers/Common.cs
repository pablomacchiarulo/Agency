using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agence.Web.Helpers
{
    public static class Common
    {
        public static SelectList GetMonthsSelectList()
        {
            List<int> months = new List<int>();
            for (int i = 1; i <= 12; i++) months.Add(i);
            months.Sort((x, y) => (y.CompareTo(x)));
            return new SelectList(months.ToArray(), "MesId");
        }

        public static SelectList GetYearsSelectList()
        {
            List<int> years = new List<int>();
            int end = DateTime.Now.AddYears(-10).Year;
            for (int i = 2005; i <= end; i++) years.Add(i);
            years.Sort((x, y) => (y.CompareTo(x)));
            return new SelectList(years, "AñoId");
        }

        public static int MonthDifference(this DateTime lValue, DateTime rValue)
        {
            return (lValue.Month - rValue.Month) + 12 * (lValue.Year - rValue.Year);
        }
    }
}