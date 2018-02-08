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
            DayOfWeek today = DateTime.Now.DayOfWeek;
            for(int i = 0; i < DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), i++)
            {
                if(pickupDay == new DateTime(DateTime.Now.Year, DateTime.Now.Month, i).DayOfWeek)
                {
                    total += charge;
                }
            }
            return charge;
        }

    }
}