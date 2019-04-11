using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.UI.Models
{
    public class PaymentForModel
    {
        public class MonthlyPayment
        {
            public string MonthName { get; set; }
        }
        public class QuaterlyPayment
        {
            public string QuaterName { get; set; }
        }
        public class HalfYearlyPayment
        {
            public string HalfYearName { get; set; }
        }

        public class OnTimePayament
        {
            public string PaymentName { get; set; }
        }

        public List<MonthlyPayment> GetMonthlyPayment()
        {
            return new List<MonthlyPayment>()
            {
                new MonthlyPayment { MonthName="Jan" },
                new MonthlyPayment { MonthName="Feb" },
                new MonthlyPayment { MonthName="Mar" },
                new MonthlyPayment { MonthName="Apr" },
                new MonthlyPayment { MonthName="May" },
                new MonthlyPayment { MonthName="Jun" },
                new MonthlyPayment { MonthName="Jully" },
                new MonthlyPayment { MonthName="Aug" },
                new MonthlyPayment { MonthName="Sept" },
                new MonthlyPayment { MonthName="Oct" },
                new MonthlyPayment { MonthName="Nov" },
                new MonthlyPayment { MonthName="Dec" },
            };
        }
    }
}