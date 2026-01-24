//-- =============================================
//-- Author:		Michael Belcher
//-- Create Date: <8/26/2021>
//-- Last Modified Date: <9/3/2021>
//-- Description: Takes a DateTime item and returns it formatted
//-- Example Use: vm.InvestigationDateTime = DateTimeHelper.formatDateTime(vm.InvestigationDateTime);  
//-- =============================================

namespace MBDEVpro.Common.Helper
{

    public class DateTimeHelper
    {
        // Returns: "8/25/2021 11:28:00 AM"
        public static DateTime formatDateTime(DateTime dt)
        {
            var theTime = System.DateTime.Now.ToString("h:mm tt");
            var theDate = dt.ToShortDateString();
            var iDateTime = theDate + " " + theTime;
            var formattedDateTime = System.DateTime.Parse(iDateTime);
            return formattedDateTime;
        }


        // Returns: "8/25/2021 11:28 AM"
        public static string formatDateTimeNoSeconds(DateTime dt)
        {
            var formattedDateTime = dt.ToString("M/dd/yyyy h:mm tt");
            return formattedDateTime;
        }

        // Returns: "8/25/2021"
        public static string formatDateTimeNoTime(DateTime dt)
        {
            var formattedDateTime = dt.ToString("M/dd/yyyy");
            return formattedDateTime;
        }

        // Returns: "08/05/2021 1:28:00 AM"
        public static string formatDateTimeLeadingZeros(DateTime dt)
        {
            var formattedDateTime = string.Format("{0:MM/dd/yyyy}", dt);
            return formattedDateTime;
        }


    }
}



