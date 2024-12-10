using Microsoft.AspNetCore.Identity;

namespace shortenURL.Models
{
    public class Url
    {
        public int Id { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortCode { get; set; }
        public string UserId { get; set; }
        public virtual IdentityUser User { get; set; }
    }
}
