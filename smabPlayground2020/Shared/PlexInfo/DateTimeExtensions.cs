using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smabPlayground2020.Shared.PlexInfo
{
    public static class DateTimeExtensions
    {
        public const string DD_MMMM_YYYY = "dd MMMM, yyyy";

		public static string ToDayLongMonthYearString(DateTime dateTime) => dateTime.ToString(DD_MMMM_YYYY);
	}
}
