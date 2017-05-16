using System;
using System.Collections;
using System.Collections.Generic;

using MVAXml2Subs.Coverter;
using MVAXml2Subs.Model;

using Xunit;

namespace MVAXml2Subs.Tests
{
	public class SrtConverterTests
	{
		[Fact]
		public void Create()
		{
			IEnumerable<SubtitleModel> set = new[]
			{
				new SubtitleModel
					{
						Start = new TimeSpan(0, 0, 0, 0, 200),
						End = new TimeSpan(0, 0, 0, 1, 900),
						Value = "Hello World!",
					}
			};

			SrtConverter converter = new SrtConverter();
			string result = converter.Create(set);

			string expect = @"1
00:00:00,200 --> 00:00:01,900
Hello World!";

			Assert.Equal(expect, result);
		}

		[Fact]
		public void ToTimeString()
		{
			SrtConverter converter = new SrtConverter();
			string result = converter.ToTimeString(new TimeSpan(0, 1, 2, 3, 400));
			Assert.Equal("01:02:03,400", result);
		}
	}
}
