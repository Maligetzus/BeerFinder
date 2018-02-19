using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeerFinder.Models.BarModels
{
    public class IndexViewModel
    {
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }

        public AddViewModel AddViewModel { get; set; }
        public List<BarViewModel> BarViewModels { get; set; }
        public string Text { get; set; }
    }
}
