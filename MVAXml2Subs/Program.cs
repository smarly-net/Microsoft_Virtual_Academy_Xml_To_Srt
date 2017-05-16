using System;
using System.Collections.Generic;

using MVAXml2Subs.Coverter;
using MVAXml2Subs.Model;
using MVAXml2Subs.Provider;

namespace MVAXml2Subs
{
	class Program
	{
		static void Main(string[] args)
		{
			string batchFile = args[0];

			FileProvider fileProvider = new FileProvider();
			IEnumerable<SubtitleFileInfo> subtilesInfos = fileProvider.ReadTxtFile(batchFile);

			MVAXml2Subs.Parser.XmlParser parser = new MVAXml2Subs.Parser.XmlParser();

			SrtConverter subtitleConverter = new SrtConverter();

			foreach (var subtitleFileInfo in subtilesInfos)
			{
				IEnumerable<SubtitleModel> lines = parser.Parse(fileProvider.ReadFile(subtitleFileInfo.Incoming));

				string subtitleText = subtitleConverter.Create(lines);

				fileProvider.WriteFile(subtitleFileInfo.Outcoming, subtitleText);
			}
		}
	}
}