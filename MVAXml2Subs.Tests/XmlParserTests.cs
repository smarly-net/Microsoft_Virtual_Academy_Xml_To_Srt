using System;
using System.Collections.Generic;
using System.Linq;

using MVAXml2Subs.Model;
using MVAXml2Subs.Parser;

using Xunit;

namespace MVAXml2Subs.Tests
{
	public class XmlParserTests
	{
		[Fact]
		public void Parse()
		{
			const string xml = @"<tt xml:lang=""en"" xmlns=""http://www.w3.org/ns/ttml"" xmlns:ttm=""http://www.w3.org/ns/ttml#metadata"" xmlns:tts=""http://www.w3.org/ns/ttml#styling"" xmlns:ttp=""http://www.w3.org/ns/ttml#parameter"">
  <body>
    <div region=""subtitleArea"">
      <p ttm:role=""caption"" xml:id=""subtitle1"" end=""00:00:04:00"" begin=""00:00:00:20""> [Music] </p>
      <p ttm:role=""caption"" xml:id=""subtitle2"" end=""00:00:20:28"" begin=""00:00:15:29""> Good morning, welcome to developing Microsoft Azure solutions. </p>
    </div>
  </body>
</tt>";

			XmlParser parser = new XmlParser();
			IEnumerable<SubtitleModel> result = parser.Parse(xml);

			Assert.Equal(2, result.Count());

			var sub1 = result.ElementAt(0);
			Assert.Equal(new TimeSpan(0,0,0,0,200), sub1.Start);
			Assert.Equal(new TimeSpan(0,0,0,4,000), sub1.End);
			Assert.Equal("[Music]", sub1.Value);

			var sub2 = result.ElementAt(1);
			Assert.Equal(new TimeSpan(0,0,0,15,290), sub2.Start);
			Assert.Equal(new TimeSpan(0,0,0,20,280), sub2.End);
			Assert.Equal("Good morning, welcome to developing Microsoft Azure solutions.", sub2.Value);
		}

		[Fact]
		public void GetTime()
		{
			XmlParser parser = new XmlParser();
			var result = parser.ParseTime("00:00:15:29");

			Assert.Equal( new TimeSpan(0,0,0,15,290), result);
		}


	}
}