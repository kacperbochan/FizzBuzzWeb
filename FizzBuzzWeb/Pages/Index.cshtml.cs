using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public FizzBuzzForm FizzBuzz { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        public string Word { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Word = "";
            CheckUserName();
        }

        public IActionResult OnPost()
        {
            CheckUserName();
            WordBuzz();

            if (!ModelState.IsValid)
            {
                return Page();
            }
            return RedirectToPage("./Privacy");
        }

        private void CheckUserName()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";
            }
        }

        private void WordBuzz() {
            if (FizzBuzz.Number is not null)
            {
                Word = "";
                if (FizzBuzz.Number % 3 == 0)
                {
                    Word += "Fizz";
                }
                if (FizzBuzz.Number % 5 == 0)
                {
                    Word += "Buzz";
                }
            }
        }
    }
}