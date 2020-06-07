using System;

namespace FPOSReports.BusinessObjects
{
    public class DateParameter
    {
        public DateParameter(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
