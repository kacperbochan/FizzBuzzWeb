using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public FizzBuzzForm FizzBuzz { get; set; }


        [Display(Name = "UserName")]
        [BindProperty(SupportsGet = true)]
        public string? Name { get; set; }
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

            if (ModelState.IsValid)// ciekawostka musiałem dodać ? po typie string dla zmiennej Name, jest to dla tego, że jeśli nie podało się nazwy urztkownika 
            {
                HttpContext.Session.SetString("Data",
                JsonConvert.SerializeObject(FizzBuzz));
                return RedirectToPage("./SavedInSession");
            }
            return Page();
            
        }

        private void CheckUserName()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";
            }
        }

        private void WordBuzz() {
            Word = "";
            if (FizzBuzz.Number is not null)
            {
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