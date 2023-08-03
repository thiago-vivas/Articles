using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DellentThiago.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IConfiguration _configuration;
        public string Message { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration; 
        }

        public void OnGet()
        {
            // retrieve nested App Service app setting
            Message = _configuration["exemploDeConfig"]?.ToString();

        }
    }
}