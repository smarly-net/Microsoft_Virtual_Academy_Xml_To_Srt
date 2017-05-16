using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using MVAXml2Subs.Model;

namespace MVAXml2Subs.Provider
{
	public class FileProvider
	{
		public IEnumerable<SubtitleFileInfo> ReadTxtFile(string txtFile)
		{
			IEnumerable<string> lines = File.ReadAllLines(txtFile).Select(x => x.Trim());

			List<SubtitleFileInfo> result = new List<SubtitleFileInfo>();

			foreach (var line in lines)
			{
				string[] elements = line.Split(new[]
										 {
											 "\" \""
										 }, StringSplitOptions.RemoveEmptyEntries);

				result.Add(new SubtitleFileInfo
				{
					Incoming = elements[0].Trim('"'),
					Outcoming = elements[1].Trim('"'),
				});
			}

			return result;
		}

		public string ReadFile(string file)
		{
			return File.ReadAllText(file);
		}

		public void WriteFile(string file, string value)
		{
			File.WriteAllText(file, value, Encoding.UTF8);
		}
	}
}