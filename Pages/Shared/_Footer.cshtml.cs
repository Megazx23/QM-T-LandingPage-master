using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace QualityMatters.Pages.Shared
{
    public class _FooterModel : PageModel
    {
        private readonly IEmailService _emailService;

        public _FooterModel(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Message { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostSendEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Traza de depuración
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Message: {Message}");

            await _emailService.SendEmailAsync("megazx23@gmail.com", "New Message", $"From: {Email}\n\n{Message}");
            return RedirectToPage("/Index");
        }
    }
}
