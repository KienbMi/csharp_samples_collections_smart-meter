using System;

namespace SmartMeter.Core
{
    public class Day
    {
        private DateTime _date;
        private double _measurement;

        public Day(DateTime date, double measurment)
        {
            _date = date;
            _measurement = measurment;
        }

        public override string ToString()
        {
            //return $"_date: {_date.ToShortString}";
            return "";
        }
    }
}
