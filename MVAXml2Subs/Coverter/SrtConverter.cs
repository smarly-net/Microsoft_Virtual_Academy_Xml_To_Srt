using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using MVAXml2Subs.Model;

namespace MVAXml2Subs.Coverter
{
	public class SrtConverter
	{
		public string Create(IEnumerable<SubtitleModel> set)
		{
			StringBuilder result = new StringBuilder();
			for (int i = 0; i < set.Count(); i++)
			{
				var element1 = set.ElementAt(i);
				result.AppendLine((i + 1).ToString(CultureInfo.InvariantCulture));
				result.AppendLine(ToTimeString(element1.Start) + " --> " + ToTimeString(element1.End));
				result.AppendLine(element1.Value);
				result.AppendLine();
			}
			return result.ToString().TrimEnd();
		}

		public string ToTimeString(TimeSpan time)
		{
			return time.ToString(@"hh\:mm\:ss\,fff");
		}
	}
}