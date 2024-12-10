using Microsoft.AspNetCore.Mvc;
using shortenURL.Service;

namespace shortenURL.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UrlsController : ControllerBase
	{
		private readonly UrlShorteningService _urlService;

		public UrlsController(UrlShorteningService urlService)
		{
			_urlService = urlService;
		}

		[HttpPost("shorten")]
		public async Task<IActionResult> ShortenUrl([FromBody] string originalUrl)
		{
			if (string.IsNullOrWhiteSpace(originalUrl))
				return BadRequest("Invalid URL.");

			var shortCode = _urlService.GenerateShortCode(originalUrl);
			await _urlService.SaveUrlAsync(originalUrl, shortCode);

            return Ok(new { ShortenedUrl = $"http://localhost:7072/{shortCode}" });
        }

        [HttpGet("{shortCode}")]
		public IActionResult RedirectUrl(string shortCode)
		{
			var url = _urlService.GetOriginalUrl(shortCode);
			if (url == null)
				return NotFound("URL does not exist.");

			return Redirect(url.OriginalUrl);
		}
	}
}


