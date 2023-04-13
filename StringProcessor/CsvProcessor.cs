namespace StringProcessor;

public static class CsvProcessor
{
	public static string LinesToCsv(string? stringToProcess, string? surroundWith = null, bool toLower = false, char valueSeperator = ',')
	{
		if (string.IsNullOrEmpty(stringToProcess))
			return string.Empty;

		var lines = stringToProcess
			.Split('\n')
			.Where(line => !string.IsNullOrWhiteSpace(line))
			.Select(line => line.Trim())
			.OrderBy(line => line)
			.ToList();

		return string.Join(',', lines);
	}
}