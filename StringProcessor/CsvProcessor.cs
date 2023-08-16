using System.Text;

namespace StringProcessor;

public static class CsvProcessor
{
	public static string LinesToCsv(string? stringToProcess, string? surroundEachValueWith = null, bool toLower = false, char valueSeparator = ',')
	{
		if (string.IsNullOrEmpty(stringToProcess))
			return string.Empty;

		var lines = stringToProcess
			.Split('\n')
			.Where(line => !string.IsNullOrWhiteSpace(line))
			.Select(line => line.Trim())
			.OrderBy(line => line)
			.ToList();

		var outputString = new StringBuilder();
		
		for (var index = 0; index < lines.Count; index++)
		{
			var outputValue = lines[index];
			
			if (toLower)
				outputValue = outputValue.ToLower();
			
			if (!string.IsNullOrEmpty(surroundEachValueWith))
				outputValue = $"{surroundEachValueWith}{outputValue}{surroundEachValueWith}";

			if (index < lines.Count - 1)
				outputValue += valueSeparator;

			outputString.Append(outputValue);
		}

		return outputString.ToString();
	}
}