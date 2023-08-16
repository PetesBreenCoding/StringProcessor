using StringProcessor;

const string dataPath = "C:\\Data\\StringProcessor";

var fileContent = await File.ReadAllTextAsync(Path.Combine(dataPath, "Input.txt"));
fileContent = CsvProcessor.LinesToCsv(fileContent);
await File.WriteAllTextAsync(Path.Combine(dataPath, "Output.txt"), fileContent);