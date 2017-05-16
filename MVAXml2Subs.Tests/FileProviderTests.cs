using System.Collections.Generic;
using System.Linq;

using MVAXml2Subs.Model;
using MVAXml2Subs.Provider;

using Xunit;

namespace MVAXml2Subs.Tests
{
	public class FileProviderTests
	{
		[Fact]
		public void ReadTxtFile()
		{
			FileProvider provider = new FileProvider();
			IEnumerable<SubtitleFileInfo> result = provider.ReadTxtFile("1.txt");

			Assert.Equal(2, result.Count());

			var fileInfo1 = result.ElementAt(0);
			Assert.Equal("01.xml", fileInfo1.Incoming);
			Assert.Equal("01.en.srt", fileInfo1.Outcoming);

			var fileInfo2 = result.ElementAt(1);
			Assert.Equal("02.xml", fileInfo2.Incoming);
			Assert.Equal("02.en.srt", fileInfo2.Outcoming);
		}
	}
}