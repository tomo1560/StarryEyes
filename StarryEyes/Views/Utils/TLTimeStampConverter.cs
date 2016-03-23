using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarryEyes.Views.Utils
{
	public class TLTimeStampConverter : OneWayConverter<DateTime, string>
	{
		protected override string ToTarget(DateTime input, object parameter)
		{
			var now = DateTime.UtcNow.Date;
			if(input >= now)
			{
				return input.ToString("HH:mm:ss");
			}
			now = now.AddDays(1 - now.Day);
			if(input >= now)
			{
				return input.ToString("dd HH:mm:ss");
			}
			now = now.AddMonths(1 - now.Month);
			if(input >= now)
			{
				return input.ToString("MM/dd HH:mm:ss");
			}

			return input.ToString("\\'yy/MM/dd HH:mm:ss");
		}
	}
}
