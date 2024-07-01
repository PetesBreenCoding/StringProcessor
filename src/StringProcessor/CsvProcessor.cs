using System.Linq;
using System.Text;

namespace StringProcessor
{
	public static class CsvProcessor
	{
		public static string LinesToCsv(string stringToProcess, char valueSeparator = ',',
			string surroundEachValueWith = null, bool toLower = false, bool newLineAfterEachValue = false,
			bool trimEachValue = true)
		{
			if (string.IsNullOrEmpty(stringToProcess))
				return string.Empty;

			var lines = stringToProcess
				.Split('\n')
				.Where(line => !string.IsNullOrWhiteSpace(line))
				.OrderBy(line => line)
				.ToList();

			var outputString = new StringBuilder();

			for (var index = 0; index < lines.Count; index++)
			{
				var outputValue = lines[index];

				if (trimEachValue)
					outputValue = outputValue.Trim();

				if (toLower)
					outputValue = outputValue.ToLower();

				if (!string.IsNullOrEmpty(surroundEachValueWith))
					outputValue = $"{surroundEachValueWith}{outputValue}{surroundEachValueWith}";

				if (index < lines.Count - 1)
					outputValue += valueSeparator;

				if (newLineAfterEachValue)
					outputString.AppendLine(outputValue);
				else
					outputString.Append(outputValue);
			}

			return outputString.ToString();
		}
	}
}