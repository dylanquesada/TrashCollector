using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Helpers
{
    public class Bill
    {
        private decimal MonthlyCost;

        public decimal GetMonthlyCharge(decimal charge, DayOfWeek pickupDay)
        {
            decimal total = 0;
            for (int i = 1; i <= DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); i++)
            {
                if (pickupDay == new DateTime(DateTime.Now.Year, DateTime.Now.Month, i).DayOfWeek)
                {
                    total += charge;
                }
            }
            return total;
        }
        public decimal AccountForVacation(decimal initial, decimal charge, DateTime start, DateTime end, DayOfWeek pickupDay)
        {
            for (int i = start.Day; i <= end.Day; i++)
            {
                if (pickupDay == new DateTime(DateTime.Now.Year, DateTime.Now.Month, i).DayOfWeek)
                {
                    initial -= charge;
                }
            }
            return initial;
        }
    }
}