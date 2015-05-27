using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Calculation
    {
        private const string DateFormat = "yyyy-MM-dd";

        private readonly List<string> _holidays;
        private readonly OpenHours _openHours;

        public Calculation(IEnumerable<DateTime> holidays, OpenHours openHours)
        {
            _holidays = dateListToStringList(holidays);
            _openHours = openHours;
        }

        public double getElapsedMinutes(DateTime startDate, DateTime endDate)
        {
            if (_openHours.StartHour == 0 || _openHours.EndHour == 0)
                throw new InvalidOperationException("Open hours cannot be started with zero hours or ended with zero hours");

            int hour = startDate.Hour;
            int minute = startDate.Minute;
            if (hour == 0 && minute == 0)
            {
                startDate = DateTime.Parse(string.Format("{0} {1}:{2}", startDate.ToString(DateFormat), _openHours.StartHour, _openHours.StartMinute));
            }
            hour = endDate.Hour;
            minute = endDate.Minute;
            if (hour == 0 && minute == 0)
            {
                endDate = DateTime.Parse(string.Format("{0} {1}:{2}", endDate.ToString(DateFormat), _openHours.EndHour, _openHours.EndMinute));
            }

            startDate = nextOpenDay(startDate);
            endDate = prevOpenDay(endDate);


            if (startDate > endDate)
                return 0;

            if (startDate.ToString(DateFormat).Equals(endDate.ToString(DateFormat)))
            {
                if (!isWorkingDay(startDate))
                    return 0;

                if (startDate.DayOfWeek == DayOfWeek.Saturday || startDate.DayOfWeek == DayOfWeek.Sunday ||
                    _holidays.Contains(startDate.ToString(DateFormat)))
                    return 0;

                if (isDateBeforeOpenHours(startDate))
                {
                    startDate = getStartOfDay(startDate);
                }
                if (isDateAfterOpenHours(endDate))
                {
                    endDate = getEndOfDay(endDate);
                }
                var endminutes = (endDate.Hour * 60) + endDate.Minute;
                var startminutes = (startDate.Hour * 60) + startDate.Minute;

                return endminutes - startminutes;

            }

            var endOfDay = getEndOfDay(startDate);
            var startOfDay = getStartOfDay(endDate);
            var usedMinutesinEndDate = endDate.Subtract(startOfDay).TotalMinutes;
            var usedMinutesinStartDate = endOfDay.Subtract(startDate).TotalMinutes;
            var tempStartDate = startDate.AddDays(1);
            var workingHoursInMinutes = (_openHours.EndHour - _openHours.StartHour) * 60;
            var totalUsedMinutes = usedMinutesinEndDate + usedMinutesinStartDate;

            for (DateTime day = tempStartDate.Date; day < endDate.Date; day = day.AddDays(1.0))
            {
                if (isWorkingDay(day))
                {
                    totalUsedMinutes += workingHoursInMinutes;
                }
            }

            return totalUsedMinutes;
        }
        public DateTime add(DateTime date, int minutes)
        {
            if (_openHours != null)
            {
                if (_openHours.StartHour == 0 || _openHours.EndHour == 0)
                    throw new InvalidOperationException("Open hours cannot be started with zero hours or ended with zero hours");

                date = nextOpenDay(date);
                var endOfDay = getEndOfDay(date);
                var minutesLeft = (int)endOfDay.Subtract(date).TotalMinutes;

                if (minutesLeft < minutes)
                {
                    date = nextOpenDay(endOfDay.AddMinutes(1));
                    date = nextOpenDay(date);
                    minutes -= minutesLeft;
                }
                var workingHoursInMinutes = (_openHours.EndHour - _openHours.StartHour) * 60;
                while (minutes > workingHoursInMinutes)
                {
                    date = getStartOfDay(date.AddDays(1));
                    date = nextOpenDay(date);
                    minutes -= workingHoursInMinutes;
                }
            }

            return date.AddMinutes(minutes);

        }


        private List<string> dateListToStringList(IEnumerable<DateTime> dates)
        {
            return dates.Select(piDate => piDate.ToString(DateFormat)).ToList();
        }


        private DateTime prevOpenDay(DateTime endDate)
        {
            if (_holidays.Contains(endDate.ToString(DateFormat)))
            {
                return prevOpenDayAfterHoliday(endDate);
            }
            if (endDate.DayOfWeek == DayOfWeek.Saturday)
            {
                return prevOpenDayAfterHoliday(endDate);
            }
            if (endDate.DayOfWeek == DayOfWeek.Sunday)
            {
                return prevOpenDayAfterHoliday(endDate);
            }
            if (isDateBeforeOpenHours(endDate))
            {
                return getStartOfDay(endDate);
            }
            if (isDateAfterOpenHours(endDate))
            {
                return getEndOfDay(endDate);
            }
            return endDate;
        }

        private bool isWorkingDay(DateTime date)
        {
            return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday &&
                   !_holidays.Contains(date.ToString(DateFormat));
        }




        private DateTime nextOpenDay(DateTime startDate)
        {
            if (_holidays.Contains(startDate.ToString(DateFormat)))
            {
                return nextOpenDayAfterHoliday(startDate);
            }
            if (startDate.DayOfWeek == DayOfWeek.Saturday)
            {
                return nextOpenDayAfterHoliday(startDate);
            }
            if (startDate.DayOfWeek == DayOfWeek.Sunday)
            {
                return nextOpenDayAfterHoliday(startDate);
            }
            if (isDateBeforeOpenHours(startDate))
            {
                return getStartOfDay(startDate);
            }
            if (isDateAfterOpenHours(startDate))
            {

                var nextDate = startDate.AddDays(1);

                if (_holidays.Contains(nextDate.ToString(DateFormat)))
                {
                    return nextOpenDayAfterHoliday(nextDate);
                }
                return getStartOfDay(nextDate);
            }
            return startDate;
        }

        private DateTime nextOpenDayAfterHoliday(DateTime holiday)
        {
            var nextDay = holiday.AddDays(1);
            if (nextDay.DayOfWeek == DayOfWeek.Saturday)
                nextDay = nextDay.AddDays(2);
            if (nextDay.DayOfWeek == DayOfWeek.Sunday)
                nextDay = nextDay.AddDays(1);
            while (_holidays.Contains(nextDay.ToString(DateFormat)))
            {
                nextDay = nextDay.AddDays(1);
            }
            return getStartOfDay(nextDay);
        }

        private DateTime prevOpenDayAfterHoliday(DateTime holiday)
        {
            var prevDay = holiday.AddDays(-1);
            if (prevDay.DayOfWeek == DayOfWeek.Saturday)
                prevDay = prevDay.AddDays(-1);
            if (prevDay.DayOfWeek == DayOfWeek.Sunday)
                prevDay = prevDay.AddDays(-2);
            while (_holidays.Contains(prevDay.ToString(DateFormat)))
            {
                prevDay = prevDay.AddDays(-1);
            }
            return getEndOfDay(prevDay);
        }

        private DateTime getStartOfDay(DateTime nextDate)
        {
            return DateTime.Parse(string.Format("{0} {1}:{2}", nextDate.ToString(DateFormat), _openHours.StartHour, _openHours.StartMinute));
        }

        private DateTime getEndOfDay(DateTime startDate)
        {
            return DateTime.Parse(string.Format("{0} {1}:{2}", startDate.ToString(DateFormat), _openHours.EndHour, _openHours.EndMinute));
        }

        private bool isDateBeforeOpenHours(DateTime startDate)
        {
            return startDate.Hour < _openHours.StartHour || (startDate.Hour == _openHours.StartHour && startDate.Minute < _openHours.StartMinute);
        }
        private bool isDateAfterOpenHours(DateTime startDate)
        {
            return startDate.Hour > _openHours.EndHour || (startDate.Hour == _openHours.EndHour && startDate.Minute > _openHours.EndMinute);
        }

    }
}
