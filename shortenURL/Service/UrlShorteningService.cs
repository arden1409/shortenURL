using System.Threading.Tasks;
using shortenURL.Data;
using shortenURL.Models;

namespace shortenURL.Service
{
	public class UrlShorteningService
	{
		private readonly AppDbContext _context;

		public UrlShorteningService(AppDbContext context)
		{
			_context = context;
		}

		public string GenerateShortCode(string originalUrl)
		{
			// Logic tạo mã rút gọn
			return Guid.NewGuid().ToString().Substring(0, 8);
		}

		public async Task SaveUrlAsync(string originalUrl, string shortCode)
		{
			var url = new Url
			{
				OriginalUrl = originalUrl,
				ShortCode = shortCode
			};
			_context.Urls.Add(url);
			await _context.SaveChangesAsync();
		}

		public Url GetOriginalUrl(string shortCode)
		{
			return _context.Urls.FirstOrDefault(u => u.ShortCode == shortCode);
		}
	}
}

