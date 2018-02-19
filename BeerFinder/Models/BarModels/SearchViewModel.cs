using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeerFinder.Models.BarModels
{
    public class SearchViewModel
    {
        [Required]
        public List<BarViewModel> BarList;

        public SearchViewModel(List<BarViewModel> barList)
        {
            BarList = barList;
        }

        public SearchViewModel()
        {
        }
    }
}
