using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.CustomHelper
{
    public static class CustomHtmlHelper
    {
        public static string DisplayPostedDate(this HtmlHelper htmlHelper, DateTime postedDate)
        {
            var currentDate = DateTime.Now;
            var dd = currentDate - postedDate;
            //// published just now (like FB)
            if (dd.TotalMinutes < 1)
            {
                return "just now";
            }

            StringBuilder result = new StringBuilder();
            //// eg: published 45 minutes ago
            if (dd.TotalMinutes < 60)
            {
                var minutes = (int)Math.Floor(dd.TotalMinutes);
                result.Append(minutes == 1 ? minutes + " minute " : minutes + " minutes ");
                result.Append("ago");
                return result.ToString();
            }

            //// eg: published 3 hours ago
            if (dd.TotalHours < 24)
            {
                var hour = (int)Math.Floor(dd.TotalHours);
                result.Append(hour == 1 ? hour + " hour " : hour + " hours ");
                result.Append("ago");
                return result.ToString();
            }

            if (dd.TotalDays >= 1 && dd.TotalDays < 2)
            {

                result.Append("Yesterday at " + postedDate.ToString("hh:mm tt"));
                return result.ToString();
            }

            if (dd.TotalDays < 7)
            {
                result.Append(postedDate.DayOfWeek+" at " + postedDate.ToString("hh:mm tt"));
                return result.ToString();
            }

            return postedDate.ToString("dd-MM-yyyy") + " at "+ postedDate.ToString("hh:mm tt");
        }
    }
}