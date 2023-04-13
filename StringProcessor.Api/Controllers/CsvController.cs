using Microsoft.AspNetCore.Mvc;

namespace StringProcessor.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CsvController
{
	[HttpPost(Name = "lines-to-csv")]
	public string LinesToCsv([FromForm] string? lines)
	{
		return CsvProcessor.LinesToCsv(lines);
	}
}