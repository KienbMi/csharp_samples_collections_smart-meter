using System;

namespace SmartMeter.Core
{
    public class Day : IComparable<Day>
    {
        private DateTime _date;
        private double _measurement;

        public Day(DateTime date, double measurement)
        {
            _date = date;
            _measurement = measurement;
        }

        public override string ToString()
        {
            return $"{nameof(_date)}: {_date.Date}, {nameof(_measurement)}: {_measurement}";
        }

        public virtual string GetMarkDownRow()
        {
            return $"| {_date.ToShortDateString()} | {_measurement: #.000} |";
        }

        public int CompareTo(Day other)
        {
            if(other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            
            return _date.CompareTo(other._date);
        }
    }
}
