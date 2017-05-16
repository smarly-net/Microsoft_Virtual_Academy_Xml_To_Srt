using System;
using System.Collections.Generic;
using System.Linq;

using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Parser.Html;


using MVAXml2Subs.Model;

namespace MVAXml2Subs.Parser
{
	public class XmlParser
	{
		public IEnumerable<SubtitleModel> Parse(string xml)
		{
			var parser = new HtmlParser();
			var document = parser.Parse(xml);
			
			IHtmlCollection<IElement> elements = document.QuerySelectorAll("body div[region=\"subtitleArea\"] > p");

			List<SubtitleModel> result = new List<SubtitleModel>();

			foreach (var element in elements)
			{
				var begin = element.Attributes.FirstOrDefault(x => string.Equals(x.Name, "begin", StringComparison.OrdinalIgnoreCase))?.Value?.Trim();
				var end = element.Attributes.FirstOrDefault(x => string.Equals(x.Name, "end", StringComparison.OrdinalIgnoreCase))?.Value?.Trim();
				var value = element.TextContent?.Trim();

				if (string.IsNullOrEmpty(begin)
					||
					string.IsNullOrWhiteSpace(end)
					||
					string.IsNullOrWhiteSpace(value)
					)
				{
					continue;
				}

				result.Add(new SubtitleModel
				{
					Start = ParseTime(begin),
					End = ParseTime(end),
					Value = value,
				});
			}

			return result;
		}

		readonly string[] _timeFormats = {
			@"hh\:mm\:ss\,fff",
			@"hh\:mm\:ss\,ff",
			@"hh\:mm\:ss\,f",
			@"hh\:mm\:ss\",
			@"h\:mm\:ss\,fff",
			@"h\:mm\:ss\,ff",
			@"h\:mm\:ss\,f",
			@"h\:mm\:ss\",
			@"hh\:mm\:ss\:fff",
			@"hh\:mm\:ss\:ff",
			@"hh\:mm\:ss\:f",
			@"hh\:mm\:ss\",
			@"h\:mm\:ss\:fff",
			@"h\:mm\:ss\:ff",
			@"h\:mm\:ss\:f",
			@"h\:mm\:ss\",
		};


		public TimeSpan ParseTime(string str)
		{
			return TimeSpan.ParseExact(str, _timeFormats, null);
		}
	}
}