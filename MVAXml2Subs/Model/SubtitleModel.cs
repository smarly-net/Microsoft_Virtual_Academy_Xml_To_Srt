using System;

namespace MVAXml2Subs.Model
{
	public struct SubtitleModel
	{
		public TimeSpan Start { get; set; }
		public TimeSpan End { get; set; }
		public string Value { get; set; }
	}
}