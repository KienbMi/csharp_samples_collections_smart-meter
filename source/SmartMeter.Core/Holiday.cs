using System;
using System.Collections.Generic;
using System.Text;

namespace SmartMeter.Core
{
    public class Holiday : Day
    {
        private string _holidayName;

        public Holiday(DateTime date, double measurement, string holidayName) : base(date, measurement)
        {
            _holidayName = holidayName;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(_holidayName)}: {_holidayName}";
        }

        public override string GetMarkDownRow()
        {
            return $"{base.GetMarkDownRow()} {_holidayName} |";
        }

    }
}
