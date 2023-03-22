using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FizzBuzzWeb.Forms
{
    public class FizzBuzzForm
    {
        [Display(Name = "PIN")]
        [Required, Range(1, 1000, ErrorMessage = "Oczekiwana wartość {0} z zakredu {1} i {2}."), ]
        public int? Number { get; set; }
    }
}
